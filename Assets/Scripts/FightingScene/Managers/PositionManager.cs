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
        [SerializeField]
        public List<Position> positions= new List<Position>();
        [SerializeField]
        int currentPositionID = 0;
        public int CurrentPositionID { get { return currentPositionID; } }

        void Start()
        {


        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// 根据当前钱币结果改变位置
        /// </summary>
        public void ChangePosition()
        {

            coinResult = CoinManager.Instance.GetCoinsResult();
            foreach (Coin coin in coinResult)
            {
                if (coin.statu && coin.isChosen)
                {
                    if (currentPositionID < 7)
                    {
                        currentPositionID++;
                    }
                    else
                    {
                        currentPositionID = 0;
                    }
                }
            }

        }
    }
}