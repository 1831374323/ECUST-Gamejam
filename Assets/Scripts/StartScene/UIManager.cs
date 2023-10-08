using System;
using EcustGamejam;
using Frame.Core;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace StartScene
{
    public class UIManager : SingletonBase<UIManager>
    {
        [SerializeField, Tooltip("制作人员UI")] private GameObject makerUI;
        
        /// <summary>
        /// 开始游戏函数
        /// </summary>
        public void EnterGame()
        {
            AudioManager.instance.PlaySound(0);
            GameManager.Instance.LoadScene(GameManager.SceneName.LevelScene);
        }

        public void NewEnterGame()
        {
            PlayerPrefs.DeleteAll();
            EnterGame();
        }

        /// <summary>
        /// 打开关闭制作者UI函数
        /// </summary>
        public void OpenCloseMakerUI()
        {
            makerUI.SetActive(!makerUI.activeSelf);
        }
    }
}
