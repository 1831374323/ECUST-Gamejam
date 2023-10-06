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
            Debug.Log("这是" + this.m_name + "的调用技能：本回合护盾值额外增加50%");
            m_PastShieldIncreaseValue = player.shieldIncreaseValue;
            player.shieldIncreaseValue *= 1.5f;
            m_PastShieldIncreaseValue -= player.shieldIncreaseValue;
        }
        public override void SkillDisable(UnitMono player,UnitMono enemy)
        {
            Debug.Log("这是" + this.m_name + "的停止调用技能：");
            player.shieldIncreaseValue += m_PastShieldIncreaseValue;
        }
    }
}
