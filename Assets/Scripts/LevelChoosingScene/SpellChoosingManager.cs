using System;
using System.Collections.Generic;
using FightingScene.SpellSystem;
using UnityEngine;
using UnityEngine.UI;
using Frame.Core;
using Managers;

namespace LevelChoosingScene
{
    public class SpellChoosingManager : SingletonBase<SpellChoosingManager>
    {
        [SerializeField, Tooltip("符咒1")] public ChoosingSpell spell1;
        [SerializeField, Tooltip("符咒2")] public ChoosingSpell spell2;
        [SerializeField, Tooltip("符咒选择UI")] private GameObject spellUI;
        [SerializeField, Tooltip("符咒列表")] public List<ChoosingSpell> spellChoosingObjects = new List<ChoosingSpell>();
        [Tooltip("符咒列表")] public List<Spells> spells ;
        [SerializeField, Tooltip("当前符咒孔位")] private ChoosingSpell currentSpell;
        
        
        private void Start()
        {
            spellUI.SetActive(false);
            //依次设置符咒以及按钮事件
            for (int i = 0; i < spells.Count ; i++)
            {
                spellChoosingObjects[i].spellButton.GetComponent<Image>().sprite = spells[i].spellSprite;
                spellChoosingObjects[i].spellName.text = spells[i].name;
                spellChoosingObjects[i].spellID = spells[i].id;
                int tmp = i;
                spellChoosingObjects[i].spellButton.onClick.AddListener(() =>
                {
                    ChooseSpell(tmp);
                    AudioManager.instance.PlaySound(1);//添加音效
                });

            }
        }

        /// <summary>
        /// 通过一号符咒位选择符咒函数UI激活函数
        /// </summary>
        public void SpellChooseUI1()
        {
            AudioManager.instance.PlaySound(2);//添加音效
            spellUI.SetActive(!spellUI.activeSelf);
            for (int i = 0; i < spells.Count; i++)
            {
                spellChoosingObjects[i].spellButton.interactable = !spellChoosingObjects[i].isChoosing;
            }
            currentSpell = spell1;
        }
        /// <summary>
        /// 通过二号符咒位选择符咒函数UI激活函数
        /// </summary>
        public void SpellChooseUI2()
        {
            AudioManager.instance.PlaySound(2);//添加音效
            spellUI.SetActive(!spellUI.activeSelf);
            for (int i = 0; i < spells.Count; i++)
            {
                spellChoosingObjects[i].spellButton.interactable = !spellChoosingObjects[i].isChoosing;
            }
            currentSpell = spell2;
        }
        
        /// <summary>
        /// 关闭符咒UI函数
        /// </summary>
        public void SpellChooseUI()
        {
            AudioManager.instance.PlaySound(1);//添加音效
            spellUI.SetActive(!spellUI.activeSelf);
        }
        
        /// <summary>
        /// 选择符咒函数
        /// </summary>
        /// <param name="id"></param>
        public void ChooseSpell(int id)
        {
            if (currentSpell.spellID >= 0)//如果当前符咒位已经有一个符咒了，就替换，把被替换的符咒设置为未选
            {
                if (ConvertID(currentSpell.spellID) >= 0)
                {
                    spellChoosingObjects[ConvertID(currentSpell.spellID)].isChoosing = false;
                }
            }
            spellUI.SetActive(!spellUI.activeSelf);//激活UI
            //选择符咒
            currentSpell.spellName.text = spellChoosingObjects[id].spellName.text;
            currentSpell.spellButton.GetComponent<Image>().sprite = spells[id].spellSprite;
            currentSpell.spellID = spells[id].id;
            spellChoosingObjects[id].isChoosing = true;
        }
        
        /// <summary>
        /// 通过符咒装备栏上记录的符咒ID来返回列表中符咒真正的ID，失败就返回-1
        /// </summary>
        /// <param name="spellID"></param>
        /// <returns></returns>
        public int ConvertID(int spellID)
        {
            int i = 0;
            for (i = 0; i < spellChoosingObjects.Count; i++)
            {
                if (spellChoosingObjects[i].spellID == spellID)
                {
                    return i;
                }
            }
            return -1;
        }
        
    }
    [Serializable]
    public class ChoosingSpell
    {
        public bool isChoosing;
        public int spellID;
        public Button spellButton;
        public Text spellName;
    }
}
