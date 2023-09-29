using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frame.Core;
using System;
using FightingScene.Managers;
using FightingScene.UnitSystem;

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

        public UnitMono player;
        public UnitMono enemy;

        Action OnPlayerRoundStartAction;
        Action OnPlayerRoundEndAction;

        Action OnEnemyRoundStartAction;
        Action OnEnemyRoundEndAction;

        void Start()
        {
            CoinManager.Instance.onCoinTurnEndAction += CoinRoundOver;

            OnPlayerRoundStartAction += PlayerRoundStart;
            OnPlayerRoundEndAction += PlayerRoundEnd;

            OnEnemyRoundEndAction += EnemyRoundEnd;

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

            }
        }
        #region -------------CoinRound-------------
        
        private void CoinRoundOver()
        {
            //Debug.Log("我知道了现在硬币回合结束");
            //改变属性
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
            OnPlayerRoundStartAction.Invoke();
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
            OnPlayerRoundEndAction.Invoke();
        }

        private void PlayerRoundEnd()
        {
            isRoundOver = true;
        }

        #endregion

        #region -------------EnemyRound-------------

        public void OnEnemyRoundStart()
        {
            OnEnemyRoundStartAction.Invoke();
        }

        public void OnEnemyRoundEnd()
        {
            OnEnemyRoundEndAction.Invoke();
        }


        private void EnemyRoundEnd()
        {
            isRoundOver = true;
        }

        #endregion

    }
}