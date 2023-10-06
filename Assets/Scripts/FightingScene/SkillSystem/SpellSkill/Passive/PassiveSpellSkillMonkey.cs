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
            Debug.Log("这是" + this.m_name + "的调用技能：速度翻倍 如果本回合暴击会使得暴击伤害由1.5变为2.0倍");
            m_PastSpeed = player.speed;
            player.speed *= 2;
            player.criticalStrikeRate = 2.0f;
        }
        public override void SkillDisable(UnitMono player,UnitMono enemy)
        {
            Debug.Log("这是" + this.m_name + "的停止调用技能：");
            player.speed -= m_PastSpeed;
            player.criticalStrikeRate = 1.5f;
        }
    }
}
