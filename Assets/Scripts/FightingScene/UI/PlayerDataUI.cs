using FightingScene.UnitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EcustGamejam
{
    public class PlayerDataUI : MonoBehaviour
    {
        public Text text;
        private EnemySO data;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            UnitMono player;
            player = FightingManager.Instance.player;

            text.text = 
                        
                        $"�ٶȣ�{player.speed}\r\n" +
                        $"ÿ�غϻ�������{player.cureMp}\r\n";
        }
    }
}