using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frame.Core;
using FightingScene.Managers;
using FightingScene.CoinSystem;
using FightingScene.UnitSystem;

namespace EcustGamejam
{
    public class PositionManager : SingletonBase<PositionManager>
    {
        List<Coin> coinResult = new List<Coin>();
        [SerializeField]
        public List<Position> positions = new List<Position>();

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
        public void ChangePosition(UnitMono unit)
        {

            coinResult = CoinManager.Instance.GetCoinsResult();
            foreach (Coin coin in coinResult)
            {
                if (coin.statu && coin.isChosen)
                {
                    if (unit.currentPosition < 7)
                    {
                        unit.currentPosition++;
                    }
                    else
                    {
                        unit.currentPosition = 0;
                    }
                }
            }

        }

        /// <summary>
        /// 获取克制关系
        /// </summary>
        /// <param name="attacker">发动攻击者</param>
        /// <param name="attacked">被攻击者</param>
        /// <returns></returns>
        public CounterRelation GetCounterRelation(UnitMono attacker, UnitMono attacked)
        {
            if (positions[attacker.currentPosition].wuXing.counterID == positions[attacked.currentPosition].wuXing.id)
            {
                return CounterRelation.Counter;
            }
            else if (positions[attacker.currentPosition].wuXing.counteredID == positions[attacked.currentPosition].wuXing.id)
            {
                return CounterRelation.Countered;
            }
            else
            {
                return CounterRelation.None;
            }
        }

        public enum CounterRelation
        {
            None,
            Counter,
            Countered,
        }
    }
}