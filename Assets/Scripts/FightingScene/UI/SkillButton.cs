using FightingScene.UnitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EcustGamejam
{
    public class SkillButton : MonoBehaviour
    {

        public int level;
        private UnitMono player;
        private UnitMono enemy;

        private void Start()
        {
            player = GameObject.Find("Player").GetComponent<UnitMono>();
            enemy = GameObject.Find("Enemy").GetComponent<UnitMono>();
        }

        public void OnAtkClick()
        {
            if (PositionManager.Instance.positions[player.currentPosition].
                    Attackskill!=null)
            {
                PositionManager.Instance.positions[player.currentPosition].
                    Attackskill.SkillApply(player, enemy, level);
            }
            
        }

        public void OnDefenceClick()
        {
            if (PositionManager.Instance.positions[player.currentPosition].
                   defenceSkill != null)
            {
                PositionManager.Instance.positions[player.currentPosition].
                    defenceSkill.SkillApply(player, enemy, level);
            }
        }
    }
}