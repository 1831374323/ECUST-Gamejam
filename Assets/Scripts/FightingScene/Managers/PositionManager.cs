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

        void Start()
        {
            

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void GetPositionResult()
        {
            coinResult = CoinManager.Instance.GetCoinsResult();
        }
    }
}