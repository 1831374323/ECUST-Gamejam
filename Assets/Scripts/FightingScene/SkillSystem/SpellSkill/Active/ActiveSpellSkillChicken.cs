using EcustGamejam;
using FightingScene.UnitSystem;
using UnityEngine;

namespace FightingScene.SkillSystem.SpellSkill.Active
{
    [CreateAssetMenu(fileName = "ActiveSpellSkillChicken",menuName = "ScriptableObject/Skill/SpellSkill/Active/Chicken",order = 0)]
    public class ActiveSpellSkill : SkillBase
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
