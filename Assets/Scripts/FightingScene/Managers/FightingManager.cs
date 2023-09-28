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
            //�ı�����
            //�ж��ٶ�
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
    }
}