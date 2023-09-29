using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frame.Core;
using FightingScene.Managers;
using FightingScene.CoinSystem;

namespace EcustGamejam
{
    public class PositionManager : SingletonBase<PositionManager>
    {
        List<Coin> coinResult = new List<Coin>();
        int currentPositionID = 0;

        void Start()
        {


        }

        // Update is called once per frame
        void Update()
        {

        }

        public int GetPositionResultID()
        {

            coinResult = CoinManager.Instance.GetCoinsResult();
            foreach (Coin coin in coinResult)
            {
                if (coin.statu && coin.isChosen)
                {
                    if (currentPositionID < 8)
                    {
                        currentPositionID++;
                    }
                    else
                    {
                        currentPositionID = 0;
                    }
                }
            }

            return currentPositionID;
        }
    }
}