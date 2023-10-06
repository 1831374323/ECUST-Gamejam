using EcustGamejam;
using UnityEngine;
using FightingScene.UnitSystem;

namespace FightingScene.SkillSystem.SpellSkill.Passive
{
    [CreateAssetMenu(fileName = "PassiveSpellSkillBow",menuName = "ScriptableObject/Skill/SpellSkill/Passive/Bow",order = 6)]

    public class PassiveSpellSkillBow : SkillBase
    {
        public override void SkillApply(UnitMono player,UnitMono enemy)
        {
            Debug.Log("这是" + this.m_name + "的调用技能：");
        }
        public override void SkillDisable(UnitMono player,UnitMono enemy)
        {
            Debug.Log("这是" + this.m_name + "的停止调用技能：");
        }
    }
}
