using EcustGamejam;
using FightingScene.UnitSystem;
using UnityEngine;

namespace FightingScene.SkillSystem.SpellSkill.Passive
{
    [CreateAssetMenu(fileName = "PassiveSpellSkillPig",menuName = "ScriptableObject/Skill/SpellSkill/Passive/Pig",order = 4)]

    public class PassiveSpellSkillPig : SkillBase
    {
        public override void SkillApply(UnitMono player,UnitMono enemy)
        {
            FightingUIManager.Instance.UpDateBehaviourText(this.m_name + "的技能触发：立即回复二十点生命");
            player.SetHp(20);
        }
        public override void SkillDisable(UnitMono player,UnitMono enemy)
        {
            FightingUIManager.Instance.UpDateBehaviourText(this.m_name + "的技能停止");
        }
    }
}
