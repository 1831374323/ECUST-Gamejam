using System.Collections.Generic;
using EcustGamejam;
using UnityEngine;
using UnityEngine.UI;
using Frame.Core;

namespace LevelChoosingScene
{
    public class LevelManager : SingletonBase<LevelManager>
    {
        [SerializeField,Tooltip("关卡")] private List<LevelScriptObject> levels = new List<LevelScriptObject>();
        [SerializeField,Tooltip("关卡按钮")] private List<Button> levelButtons = new List<Button>();
        [SerializeField, Tooltip("关卡UI")] private GameObject levelUI;
        [SerializeField,Tooltip("关卡信息")] private Text levelInfoText;
        [SerializeField,Tooltip("敌人图片")] private Image enemyImage;
        [SerializeField,Tooltip("敌人信息")] private Text enemyInfoText;
        [SerializeField,Tooltip("敌人信息")] private LevelScriptObject currentLevel;


        private void Start()
        {
            for (int i = 0; i < levels.Count; i++)//给按钮绑定事件
            {
                if (levelButtons[i] != null)
                {
                    int tmp = i;
                    levelButtons[i].onClick.AddListener(() => { SetLevel(tmp); });
                    if (i > PlayerPrefs.GetInt("MaxtLevelID", 9)) 
                    {
                        levelButtons[i].interactable = false;
                    }
                }
            }

            if (GameManager.Instance.level != null)
            {
                SetLevel(GameManager.Instance.level.levelId);
            }
            else
            {
                SetLevel(0);
            }
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
            
        }

        /// <summary>
        /// 传输关卡和符咒选择信息,进入关卡
        /// </summary>
        public void SendLevelInfo()
        {
            GameManager.Instance.level = currentLevel;
            if (SpellChoosingManager.Instance.spell1.spellID > 0) {GameManager.Instance.spellID.Add(SpellChoosingManager.Instance.spell1.spellID); }
            if (SpellChoosingManager.Instance.spell2.spellID > 0) {GameManager.Instance.spellID.Add(SpellChoosingManager.Instance.spell2.spellID); }
            //Debug.Log(SpellChoosingManager.Instance.spell1.spellID+" "+SpellChoosingManager.Instance.spell2.spellID);
            GameManager.Instance.LoadScene(GameManager.SceneName.FightingScene);
        }
        
        /// <summary>
        /// 返回按钮
        /// </summary>
        public void Exist()
        {
            GameManager.Instance.LoadScene(GameManager.SceneName.StartScene);
        }
        
    }
}
