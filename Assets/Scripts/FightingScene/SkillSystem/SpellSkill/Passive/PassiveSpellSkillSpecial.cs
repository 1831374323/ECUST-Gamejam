using EcustGamejam;
using FightingScene.UnitSystem;
using UnityEngine;

namespace FightingScene.SkillSystem.SpellSkill.Passive
{
    [CreateAssetMenu(fileName = "PassiveSpellSkillSpecial",menuName = "ScriptableObject/Skill/SpellSkill/Passive/Special",order = 2)]
    public class PassiveSpellSkillSpecial : SkillBase
    {
        public override void SkillApply(UnitMono player,UnitMono enemy)
        {
            Debug.Log("这是" + this.m_name + "的调用技能：允许暴击");
            FightingManager.Instance.ChangeCriticalState(true);
        }
        public override void SkillDisable(UnitMono player,UnitMono enemy)
        {
            Debug.Log("这是" + this.m_name + "的停止调用技能：禁止暴击");
            FightingManager.Instance.ChangeCriticalState(false);
        }
    }
}
