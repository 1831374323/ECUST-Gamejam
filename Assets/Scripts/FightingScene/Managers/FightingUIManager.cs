using System.Collections;
using System.Collections.Generic;
using FightingScene.UnitSystem;
using Frame.Core;
using UnityEngine;
using UnityEngine.UI;

namespace EcustGamejam
{
    public class FightingUIManager : SingletonBase<FightingUIManager>
    {
        public Image hpBar;
        public Image mpBar;
        UnitMono player;
        UnitMono enemy;

        // Start is called before the first frame update
        void Start()
        {
            player=FightingManager.Instance.player;
            enemy=FightingManager.Instance.enemy;
        }

        // Update is called once per frame
        void Update()
        {
            UpdateUI();
        }

        public void LoadLevelScene()
        {
            GameManager.Instance.LoadScene(GameManager.SceneName.LevelScene);
        }

        void UpdateUI()
        {
            
            hpBar.fillAmount= (float)player.CurrentHp/player.maxHp;

            mpBar.fillAmount=(float)player.CurrentMP/player.maxMp;
        }
    }
}