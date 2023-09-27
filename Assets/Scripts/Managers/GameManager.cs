using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EcustGamejam
{
    public class GameManager : SingletonBase<GameManager>
    {

        void Awake()
 
        {
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

    }
}
