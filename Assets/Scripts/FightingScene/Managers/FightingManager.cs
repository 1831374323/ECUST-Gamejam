using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frame.Core;
using System;
using FightingScene.Managers;
using FightingScene.UnitSystem;
using FightingScene.CoinSystem;
using FightingScene.SpellSystem;

namespace EcustGamejam
{
    public class FightingManager : SingletonBase<FightingManager>
    {

        [SerializeField]
        private RoundState roundState = RoundState.CoinRound;
        [SerializeField]
        private List<RoundState> nextStates = new List<RoundState>();
        public bool isFirstRound = true;
        private bool isRoundOver = false;
        public bool criticalState = false;

        public UnitMono player;
        public UnitMono enemy;

        [SerializeField]
        List<m_Spell> m_spells = new List<m_Spell>();

        #region -------------Actions-------------

        public Action OnPlayerRoundStartAction;
        public Action OnPlayerRoundEndAction;

        public Action OnEnemyRoundStartAction;
        public Action OnEnemyRoundEndAction;

        #endregion

        void Start()
        {
            CoinManager.Instance.onCoinTurnEndAction += CoinRoundOver;

            OnPlayerRoundStartAction += PlayerRoundStart;
            OnPlayerRoundEndAction += PlayerRoundEnd;

            OnEnemyRoundStartAction = null;
            OnEnemyRoundEndAction += EnemyRoundEnd;

            SpellInitial();

            StartCoroutine(RoundControllor());
        }

        // Update is called once per frame
        void Update()
        {

        }

        public enum RoundState
        {
            CoinRound = 0,
            PlayerRound = 1,
            EnemyRound = 2,
            PlayerRound2 = 3,
        }

        //流程化回合控制
        IEnumerator RoundControllor()
        {
            while (this != null)
            {
                //初始化
                nextStates.Clear();
                nextStates.Add(RoundState.CoinRound);

                //进行回合阶段
                while (nextStates.Count > 0)
                {
                    roundState = nextStates[0];
                    nextStates.RemoveAt(0);
                    switch (roundState)
                    {
                        case RoundState.CoinRound:
                            CoinManager.Instance.OnCoinTurnStart();
                            break;
                        case RoundState.PlayerRound:
                            OnPlayerRoundStart();
                            break;
                        case RoundState.EnemyRound:
                            OnEnemyRoundStart();
                            break;
                        case RoundState.PlayerRound2:
                            OnPlayerRoundStart();
                            break;
                        default:
                            break;
                    }
                    yield return new WaitUntil(() => isRoundOver);
                    isRoundOver = false;
                }

                if (isFirstRound)
                {
                    isFirstRound = false;
                }

                //注销符咒效果
                for (int i = 0; i < 3; i++)
                {
                    if (m_spells.Count > i)
                    {
                        if (m_spells[i].isApplyed)
                        {
                            SpellManager.Instance.SpellDisable(m_spells[i].id);
                            m_spells[i].isApplyed = false;
                        }
                    }
                }
            }
        }

        #region -------------Spell-------------
        [Serializable]
        class m_Spell
        {
            public int id;
            public bool isApplyed;
        }

        void SpellInitial()
        {
            for (int i = 0; i < 3; i++)
            {
                m_Spell m_spell = new m_Spell();
                m_spell.isApplyed = false;
                if (GameManager.Instance.spellID.Count > i)
                {
                    m_spell.id = GameManager.Instance.spellID[i];
                }
                m_spells.Add(m_spell);
            }
        }
        #endregion

        #region -------------CoinRound-------------改变符咒、卦位、确定回合顺序

        private void CoinRoundOver()
        {

            //符咒效果生效
            List<Coin> coinResult = CoinManager.Instance.GetCoinsResult();

            for (int i = 0; i < 3; i++)
            {
                if (coinResult.Count > 2 * i + 1 && m_spells.Count > i)
                {
                    if (coinResult[2 * i].isChosen && coinResult[2 * i].statu
                        && coinResult[2 * i + 1].isChosen && coinResult[2 * i + 1].statu)
                    {
                        SpellManager.Instance.SpellApply(m_spells[i].id);

                        m_spells[i].isApplyed = true;
                    }
                }
            }

            //改变卦位
            PositionManager.Instance.ChangePosition(player);
            //判断速度,根据速度确定回合顺序
            if (player.speed >= enemy.speed * 2)
            {
                nextStates.Add(RoundState.PlayerRound);
                nextStates.Add(RoundState.EnemyRound);
                nextStates.Add(RoundState.PlayerRound2);
            }
            else if (player.speed < enemy.speed * 2 && player.speed >= enemy.speed)
            {
                nextStates.Add(RoundState.PlayerRound);
                nextStates.Add(RoundState.EnemyRound);
            }
            else
            {
                nextStates.Add(RoundState.EnemyRound);
                nextStates.Add(RoundState.PlayerRound);
            }
            isRoundOver = true;
        }
        #endregion

        #region -------------PlayerRound-------------
        public void OnPlayerRoundStart()
        {
            OnPlayerRoundStartAction?.Invoke();
        }

        private void PlayerRoundStart()
        {
            if (roundState == RoundState.PlayerRound2)
            {
                player.SetMp(0);
            }
        }

        public void OnPlayerRoundEnd()
        {
            OnPlayerRoundEndAction?.Invoke();
        }

        private void PlayerRoundEnd()
        {
            isRoundOver = true;
        }

        #endregion

        #region -------------EnemyRound-------------

        public void OnEnemyRoundStart()
        {
            OnEnemyRoundStartAction?.Invoke();
        }

        public void OnEnemyRoundEnd()
        {
            OnEnemyRoundEndAction?.Invoke();
        }


        private void EnemyRoundEnd()
        {
            isRoundOver = true;
        }

        #endregion

        public void ChangeCriticalState(bool state)
        {
            criticalState = state;
        }
    }
}