using System;
using System.Collections.Generic;
using EcustGamejam;
using FightingScene.CoinSystem;
using Frame.Core;
using UnityEngine;
using UnityEngine.UI;
using FightingScene.UnitSystem;
using UnityEngine.Serialization;

namespace FightingScene.Managers
{
    public class CoinManager : SingletonBase<CoinManager>
    {
        [SerializeField, Tooltip("玩家所选择钱币")]
        public List<GameObject> coinList = new List<GameObject>();

        [SerializeField, Tooltip("硬币正面图")] private Sprite coinSpriteFront;
        [SerializeField, Tooltip("硬币反面图")] private Sprite coinSpriteBack;
        
        [Tooltip("战斗界面的钱币UI文本")] public List<Text> coinTextList = new List<Text>();
        [Tooltip("战斗界面的钱币UI图片")] public List<Image> coinImageList = new List<Image>();
        [SerializeField, Tooltip("战斗界面硬币UI")] private GameObject coinFightUI;

        [SerializeField, Tooltip("投掷硬币UI")] private GameObject coinUI;
        [Tooltip("投掷钱币按钮")] public Button rollButton;
        [Tooltip("进入战斗按钮")] public Button enterFightButton;

        [Tooltip("硬币回合")]public Action onCoinTurnEndAction;
        public Action onCoinTurnStartAction;
        
        [Tooltip("投掷一个硬币扣除的蓝量")] public int tempMp;
        [Tooltip("投掷所有硬币扣除的蓝量")] private int m_TrueMp;
        
        [Tooltip("玩家")] public UnitMono player;
        [Tooltip("敌人")] public UnitMono enemy;
        
        /// <summary>
        /// Awake里存放并设置委托事件
        /// </summary>
        private void Awake()
        {
            onCoinTurnEndAction += CoinTurnEnd;
            onCoinTurnStartAction += CoinTurnStart;
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            //一开始硬币回合UI不出现
            coinUI.SetActive(false);
            //战斗中硬币状态栏出现
            coinFightUI.SetActive(true);
            //进入战斗按钮在投掷钱币之前不会出现
            enterFightButton.interactable = false;
        }

        /// <summary>
        /// 遍历硬币列表，直接调用硬币自带的随机函数，仅在第一回合不扣蓝
        /// </summary>
        public void RollChosenCoins()
        {
            m_TrueMp = 0;
            foreach (GameObject obj in coinList)
            {
                Coin coin = obj.GetComponent<Coin>();
                if (coin.isChosen)
                {
                    m_TrueMp += tempMp;//计算耗蓝
                    coin.DoRandom();
                    coin.coinText.text = (coin.statu == true) ? "正" : "反";
                    coin.GetComponent<Image>().sprite=(coin.statu == true) ? coinSpriteFront : coinSpriteBack;
                }
            }
            //不是第一回合就消蓝，选的硬币越多耗蓝越多
            if (!FightingManager.Instance.isFirstRound)
            {
                bool isSuccess = player.SetMp(-m_TrueMp);
                //Debug.Log("MP:"+m_TrueMp);
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
                coinImageList[i].sprite = coins[i].GetComponent<Image>().sprite;
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
        /// 禁止使用投掷按钮
        /// </summary>
        public void DisableButton()
        {
            rollButton.interactable = false;
            enterFightButton.interactable = true;
        }

        /// <summary>
        /// 开始硬币回合
        /// </summary>
        private void CoinTurnStart()
        {
            coinUI.SetActive(true);
            rollButton.interactable = true;
            coinFightUI.SetActive(false);
            enterFightButton.interactable = false;
            bool isSuccess = player.SetMp(player.cureMp);
        }

        /// <summary>
        /// 结束硬币回合
        /// </summary>
        private void CoinTurnEnd()
        {
            coinUI.SetActive(false);
            coinFightUI.SetActive(true);
            SetFightCoinUI();
        }
        
        public void OnCoinTurnEnd()
        {
            onCoinTurnEndAction.Invoke();
        }
        
        public void OnCoinTurnStart()
        {
            onCoinTurnStartAction.Invoke();
        }
        
    }

}