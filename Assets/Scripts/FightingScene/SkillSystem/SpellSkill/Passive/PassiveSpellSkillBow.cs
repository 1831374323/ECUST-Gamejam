using EcustGamejam;
using UnityEngine;
using FightingScene.UnitSystem;

namespace FightingScene.SkillSystem.SpellSkill.Passive
{
    [CreateAssetMenu(fileName = "PassiveSpellSkillBow",menuName = "ScriptableObject/Skill/SpellSkill/Passive/Bow",order = 6)]

    public class PassiveSpellSkillBow : SkillBase
    {
        private float m_PastShieldIncreaseValue;
        public override void SkillApply(UnitMono player,UnitMono enemy)
        {
            FightingUIManager.Instance.UpDateBehaviourText(this.m_name + "的技能触发：本回合护盾值额外增加50%");
            m_PastShieldIncreaseValue = player.shieldIncreaseValue;
            player.shieldIncreaseValue *= 1.5f;
            m_PastShieldIncreaseValue -= player.shieldIncreaseValue;
        }
        public override void SkillDisable(UnitMono player,UnitMono enemy)
        {
            FightingUIManager.Instance.UpDateBehaviourText(this.m_name + "停止作用");
            player.shieldIncreaseValue += m_PastShieldIncreaseValue;
        }
    }
}
