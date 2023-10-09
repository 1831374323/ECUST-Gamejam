using EcustGamejam;
using FightingScene.UnitSystem;
using UnityEngine;

namespace FightingScene.SkillSystem.SpellSkill.Passive
{
    [CreateAssetMenu(fileName = "PassiveSpellSkillMonkey",menuName = "ScriptableObject/Skill/SpellSkill/Passive/Monkey",order = 3)]

    public class PassiveSpellSkillMonkey : SkillBase
    {
        private int m_PastSpeed;
        public override void SkillApply(UnitMono player,UnitMono enemy)
        {
            FightingUIManager.Instance.UpDateBehaviourText(this.m_name + "的技能触发：速度翻倍 如果本回合暴击会使得暴击伤害由1.5变为2.0倍");
            m_PastSpeed = player.speed;
            player.speed *= 2;
            player.criticalStrikeRate = 2.0f;
        }
        public override void SkillDisable(UnitMono player,UnitMono enemy)
        {
            FightingUIManager.Instance.UpDateBehaviourText(this.m_name + "的技能停止");
            player.speed -= m_PastSpeed;
            player.criticalStrikeRate = 1.5f;
        }
    }
}
