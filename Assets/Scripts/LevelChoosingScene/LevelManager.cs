using System.Collections.Generic;
using EcustGamejam;
using UnityEngine;
using UnityEngine.UI;
using Frame.Core;
using Managers;

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
        [SerializeField,Tooltip("暴击符咒ID")] private int specialSpellId;


        private void Start()
        {
            GameManager.Instance.spellID.Clear();//重置符咒位
            GameManager.Instance.level = null;//重置传入关卡
            GameManager.Instance.enemySO = null;//重置敌人SO

            
            for (int i = 0; i < levels.Count; i++)//给按钮绑定事件,附加音效
            {
                if (levelButtons[i] != null)
                {
                    int tmp = i;
                    levelButtons[i].onClick.AddListener(() => { SetLevel(tmp); AudioManager.instance.PlaySound(0);});
                    if (i > PlayerPrefs.GetInt("MaxLevelID", 0)) 
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
            enemyInfoText.text = levels[id].enemy.description;
            if(levels[id].enemy!=null) {enemyImage.sprite = levels[id].enemy.image;}
            currentLevel = levels[id];
        }

        /// <summary>
        /// 传输关卡和符咒选择信息,进入关卡
        /// </summary>
        public void SendLevelInfo()
        {
            AudioManager.instance.PlaySound(0);//给按钮添加音效
            if (currentLevel != null){GameManager.Instance.level = currentLevel; } //提交关卡SO
            if(currentLevel.enemy!=null){GameManager.Instance.enemySO = currentLevel.enemy;}//提交敌人SO

            GameManager.Instance.spellID.Add(SpellChoosingManager.Instance.ConvertID(SpellChoosingManager.Instance.spell1.spellID)); 
            GameManager.Instance.spellID.Add(SpellChoosingManager.Instance.ConvertID(SpellChoosingManager.Instance.spell2.spellID)); 
            
            GameManager.Instance.spellID.Add(specialSpellId);//添加暴击符咒
            GameManager.Instance.LoadScene(GameManager.SceneName.FightingScene);
        }
        
        /// <summary>
        /// 返回按钮
        /// </summary>
        public void Exist()
        {
            AudioManager.instance.PlaySound(0);//给按钮添加音效
            GameManager.Instance.LoadScene(GameManager.SceneName.StartScene);
        }
        
    }
}
