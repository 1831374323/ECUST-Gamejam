using System.Collections.Generic;
using FightingScene.CoinSystem;
using Frame.Core;
using UnityEngine;

namespace FightingScene.Managers
{
    public class CoinManager : SingletonBase<CoinManager>
    {
        [SerializeField,Tooltip("玩家所选择钱币")]
        public List<GameObject> coinList = new List<GameObject>();

        /*/// <summary>
        /// 生成六个硬币？
        /// </summary>
        private void Start()
        {
            Coin tmpCoin = Instantiate(...);
            coinList.Add(tmpCoin);
        }*/
        
        /// <summary>
        /// 遍历硬币列表，直接调用硬币自带的随机函数
        /// </summary>
        public void RollChosenCoins()
        {
            foreach (GameObject obj in coinList)
            {
                Coin coin = obj.GetComponent<Coin>();
                if (coin.isChosen)
                {
                    coin.DoRandom();
                    coin.coinText.text = (coin.statu == true) ? "正" : "反";
                    //coin.isChosen = false;
                }
            }
        }

        /// <summary>
        /// 获取硬币投掷结果
        /// </summary>
        /// <returns> coins列表</returns>
        List<Coin> GetCoinsResult()
        {
            List<Coin> coins = new List<Coin>();
            foreach (GameObject obj in coinList)
            {
                Coin coin = obj.GetComponent<Coin>();
                coins.Add(coin);
            }
            return coins;
        }
        
        private void DoCoinEffect()
        {

        }


    }


}