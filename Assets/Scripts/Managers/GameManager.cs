using System.Collections;
using System.Collections.Generic;
using Frame.Core;
using LevelChoosingScene;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EcustGamejam
{
    public class GameManager : SingletonBase<GameManager>
    {
        public List<int> spellID= new List<int>();
        public LevelScriptObject level;
        public EnemySO enemySO;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this.gameObject);
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public enum SceneName
        {
            StartScene = 0,
            LevelScene = 1,
            FightingScene = 2,
        }
        public void LoadScene(SceneName name)
        {
            switch (name)
            {
                case SceneName.StartScene:
                    {
                        SceneManager.LoadScene("StartScene");
                        break;
                    }
                case SceneName.LevelScene:
                    {
                        SceneManager.LoadScene("LevelScene");
                        break;
                    }
                case SceneName.FightingScene:
                    {
                        SceneManager.LoadScene("FightingScene");
                        break;
                    }
            }
        }
        
        public void LevelVectory()
        {
            FightingUIManager.Instance.levelOver.SetActive(true);
            FightingUIManager.Instance.levelOver.transform.Find("Text").GetComponent<Text>().text = "��Ϸʤ��";
            PlayerPrefs.SetInt("MaxLevelID", level.levelId);
        }

        public void LevelDefeat()
        {
            FightingUIManager.Instance.levelOver.SetActive(true);
            FightingUIManager.Instance.levelOver.transform.Find("Text").GetComponent<Text>().text = "��Ϸʧ��";
        }

    }
}
