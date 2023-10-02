using EcustGamejam;
using FightingScene.UnitSystem;
using UnityEngine;

namespace FightingScene.SkillSystem.SpellSkill.Active
{
    [CreateAssetMenu(fileName = "ActiveSpellSkillDog",menuName = "ScriptableObject/Skill/SpellSkill/Active/Dog",order = 1)]
    public class ActiveSpellSkillDog : SkillBase
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
