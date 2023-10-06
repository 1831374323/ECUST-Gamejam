using EcustGamejam;
using UnityEngine;
using FightingScene.UnitSystem;

namespace FightingScene.SkillSystem.SpellSkill.Passive
{
    [CreateAssetMenu(fileName = "PassiveSpellSkillMouse",menuName = "ScriptableObject/Skill/SpellSkill/Passive/Mouse",order = 5)]

    public class PassiveSpellSkillMouse : SkillBase
    {
        private int m_HalfLostHp;
        private int m_PastSpeed;
        public override void SkillApply(UnitMono player,UnitMono enemy)
        {
            Debug.Log("这是" + this.m_name + "的调用技能：本回合回复已损失生命值的一半");
            m_PastSpeed = player.speed;
            player.speed *= 2;
            m_PastSpeed -= player.speed;

            m_HalfLostHp = (player.maxHp - player.CurrentHp) / 2;
            player.SetHp(m_HalfLostHp);
        }
        public override void SkillDisable(UnitMono player,UnitMono enemy)
        {
            Debug.Log("这是" + this.m_name + "的停止调用技能：");
            player.speed += m_PastSpeed;
        }
    }
}
