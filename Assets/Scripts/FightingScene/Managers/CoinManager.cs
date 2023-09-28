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
        
        [Tooltip("战斗界面的钱币UI文本")] public List<Text> coinTextList = new List<Text>();
        [SerializeField, Tooltip("战斗界面硬币UI")] private GameObject coinFightUI;

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
            coinFightUI.SetActive(true);
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
        /// 同步战斗界面的钱币UI
        /// </summary>
        private void SetFightCoinUI()
        {
            List<Coin> coins = GetCoinsResult();
            
            for (int i = 0; i < coinList.Count; i++)
            {
                coinTextList[i].text = coins[i].coinText.text;
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
        /// 开始硬币回合
        /// </summary>
        public void OnCoinTurnStart()
        {
            coinUI.SetActive(true);
            rollButton.GetComponent<Button>().interactable = true;
            coinFightUI.SetActive(false);
        }
        
        /// <summary>
        /// 结束硬币回合
        /// </summary>
        public void OnCoinTurnEnd()
        {
            coinUI.SetActive(false);
            coinFightUI.SetActive(true);
            SetFightCoinUI();
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