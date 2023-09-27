using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    public class FightingUIManager : SingletonBase<FightingUIManager>
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LoadLevelScene()
        {
            GameManager.Instance.LoadScene(GameManager.SceneName.LevelScene);
        }
    }
}