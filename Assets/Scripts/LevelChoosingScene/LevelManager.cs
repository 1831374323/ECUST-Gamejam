using System;
using System.Collections.Generic;
using EcustGamejam;
using UnityEngine;
using UnityEngine.UI;
using Frame.Core;

namespace LevelChoosingScene
{
    public class LevelManager : SingletonBase<LevelManager>
    {
        [SerializeField,Tooltip("关卡")] private List<LevelMono> levels = new List<LevelMono>();
        [SerializeField,Tooltip("关卡按钮")] private List<Button> levelButtons = new List<Button>();
        [SerializeField, Tooltip("关卡UI")] private GameObject levelUI;
        [SerializeField,Tooltip("关卡信息")] private Text levelInfoText;
        [SerializeField,Tooltip("敌人图片")] private Image enemyImage;
        [SerializeField,Tooltip("敌人信息")] private Text enemyInfoText;
        [SerializeField,Tooltip("敌人信息")] private LevelMono currentLevel;
        
        private void Start()
        {
            for (int i = 0; i < levels.Count; i++)//给按钮绑定事件
            {
                if (levelButtons[i] != null)
                {
                    int tmp = i;
                    levelButtons[i].onClick.AddListener(() => { SetLevel(tmp); });
                }
            }
            
            SetLevel(PlayerPrefs.GetInt("LevelID", 0));
        }

        /// <summary>
        /// 设置关卡函数,记录
        /// </summary>
        /// <param name="id"></param>
        public void SetLevel(int id)
        {
            levelInfoText.text = levels[id].description;
            enemyInfoText.text = levels[id].enemyDescription;
            enemyImage.sprite = levels[id].enemySprite;
            currentLevel = levels[id];
            PlayerPrefs.SetInt("LevelID", id);
        }

        /// <summary>
        /// 传输关卡信息,进入关卡
        /// </summary>
        public void SendLevelInfo()
        {
            GameManager.Instance.level = currentLevel;
            GameManager.Instance.LoadScene(GameManager.SceneName.FightingScene);
            //Debug.Log(currentLevel);
        }
        
        public void Exist()
        {
            GameManager.Instance.LoadScene(GameManager.SceneName.StartScene);
        }
        
    }
}
