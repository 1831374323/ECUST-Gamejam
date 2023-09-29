using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frame.Core;
using System;
using FightingScene.Managers;

namespace EcustGamejam
{
    public class FightingManager : SingletonBase<FightingManager>
    {
        [SerializeField]
        private RoundState roundState = RoundState.CoinRound;
        private List<RoundState> nextStates = new List<RoundState>();
        private bool isRoundOver = false;
        void Start()
        {
            CoinManager.Instance.onCoinTurnEndAction += CoinRoundOver;
            CoinManager.Instance.onCoinTurnStartAction += () => { Debug.Log("知道硬币回合开始啦");};
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
                nextStates.Clear();
                nextStates.Add(RoundState.CoinRound);

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
                            break;
                        case RoundState.EnemyRound:
                            break;
                        case RoundState.PlayerRound2:
                            break;
                        default:
                            break;
                    }
                    yield return new WaitUntil(() => isRoundOver);
                    isRoundOver = false;
                }


            }
        }

        private void CoinRoundOver()
        {
            Debug.Log("我知道了现在硬币回合结束");
            //改变属性
            //判断速度
            //if ()
            {
                nextStates.Add(RoundState.PlayerRound);
                nextStates.Add(RoundState.EnemyRound);
                nextStates.Add(RoundState.PlayerRound2);
            }
            //else if ()
            {
                nextStates.Add(RoundState.PlayerRound);
                nextStates.Add(RoundState.EnemyRound);
            }
            //else
            {
                nextStates.Add(RoundState.EnemyRound);
                nextStates.Add(RoundState.PlayerRound);
            }
            isRoundOver = true;
        }

        public Action OnCoinTurnStart;
    }
}