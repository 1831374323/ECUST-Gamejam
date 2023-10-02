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
        /// ���ݵ�ǰǮ�ҽ���ı�λ��
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
        /// ��ȡ���ƹ�ϵ
        /// </summary>
        /// <param name="attacker">����������</param>
        /// <param name="attacked">��������</param>
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