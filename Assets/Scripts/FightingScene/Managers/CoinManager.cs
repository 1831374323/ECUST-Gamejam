using System.Collections.Generic;
using FightingScene.CoinSystem;
using Frame.Core;
using UnityEngine;
using UnityEngine.UI;

namespace FightingScene.Managers
{
    public class CoinManager : SingletonBase<CoinManager>
    {
        [SerializeField,Tooltip("玩家所选择钱币")]
        public List<GameObject> coinList = new List<GameObject>();

        [SerializeField, Tooltip("投掷硬币UI")] private GameObject coinUI;
        [Tooltip("投掷钱币按钮")] public Button rollButton;
        
        /// <summary>
        /// 生成六个硬币？
        /// </summary>
        private void Start()
        {
            //Coin tmpCoin = Instantiate(...);
            //coinList.Add(tmpCoin);
            //一开始UI不出现
            coinUI.SetActive(false);
        }
        
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
                }
            }
        }

        /// <summary>
        /// 获取硬币投掷结果
        /// </summary>
        /// <returns> coins列表</returns>
        public List<Coin> GetCoinsResult()
        {
            List<Coin> coins = new List<Coin>();
            foreach (GameObject obj in coinList)
            {
                Coin coin = obj.GetComponent<Coin>();
                coins.Add(coin);
            }
            return coins;
        }
        
        /// <summary>
        /// 硬币效果计算函数
        /// </summary>
        private void DoCoinEffect()
        {

        }
        
        /// <summary>
        /// 开始或者结束硬币回合
        /// </summary>
        public void OnCoinTurnStartEnd()
        {
            coinUI.SetActive(!coinUI.activeSelf);
            rollButton.GetComponent<Button>().interactable = true;
        }
        
        /// <summary>
        /// 禁止使用投掷按钮
        /// </summary>
        public void DisableButton()
        {
            rollButton.GetComponent<Button>().interactable = false;
        }
        
    }
    
}