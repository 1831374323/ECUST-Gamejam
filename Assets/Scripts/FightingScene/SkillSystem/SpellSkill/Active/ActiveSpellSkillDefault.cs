using EcustGamejam;
using FightingScene.UnitSystem;
using UnityEngine;

namespace FightingScene.SkillSystem.SpellSkill.Active
{
    [CreateAssetMenu(fileName = "ActiveSpellSkillDefault",menuName = "ScriptableObject/Skill/SpellSkill/Active/Default",order = 0)]
    public class ActiveSpellSkillDefault : SkillBase
    {
        public override void SkillApply(UnitMono player,UnitMono enemy)
        {
            Debug.Log("这是" + this.m_name + "的调用主动技能：");
        }
        public override void SkillDisable(UnitMono player,UnitMono enemy)
        {
            Debug.Log("这是" + this.m_name + "的停止调用主动技能：");
        }
    }
}
