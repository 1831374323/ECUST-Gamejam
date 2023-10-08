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
        /// <summary>
        /// 开始游戏函数
        /// </summary>
        ///
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
    }
}
