using FightingScene.UnitSystem;
using Managers;
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
        public Text describeText;

        private void Start()
        {
            player = GameObject.Find("Player").GetComponent<UnitMono>();
            enemy = GameObject.Find("Enemy").GetComponent<UnitMono>();
        }

        public void OnAtkClick()
        {
            if (FightingManager.Instance.m_roundState == FightingManager.RoundState.PlayerRound ||
                FightingManager.Instance.m_roundState == FightingManager.RoundState.PlayerRound2)
            {
                if (PositionManager.Instance.positions[player.currentPosition].
                        attackskill != null)
                {
                    PositionManager.Instance.positions[player.currentPosition].
                        attackskill.SkillApply(player, enemy, level);
                    AudioManager.instance.PlaySound(0);
                }
            }
            
        }

        public void OnDefenceClick()
        {
            if (FightingManager.Instance.m_roundState == FightingManager.RoundState.PlayerRound ||
                FightingManager.Instance.m_roundState == FightingManager.RoundState.PlayerRound2)
            {
                if (PositionManager.Instance.positions[player.currentPosition].
                   defenceSkill != null)
                {
                    PositionManager.Instance.positions[player.currentPosition].
                        defenceSkill.SkillApply(player, enemy, level);
                    AudioManager.instance.PlaySound(0);
                }
            }
        }

        public void OnPointerEnterAtk()
        {
            describeText.gameObject.SetActive(true);
            describeText.text = PositionManager.Instance.positions[player.currentPosition].attackskill.describe;
        }

        public void OnPointerEnterDef()
        {
            describeText.gameObject.SetActive(true);
            describeText.text = PositionManager.Instance.positions[player.currentPosition].defenceSkill.describe;
        }

        public void OnPointerExit()
        {
            describeText.gameObject.SetActive(false);
        }
    }
}