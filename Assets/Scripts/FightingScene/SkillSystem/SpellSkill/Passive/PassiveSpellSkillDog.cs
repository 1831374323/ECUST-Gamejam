using EcustGamejam;
using FightingScene.UnitSystem;
using UnityEngine;

namespace FightingScene.SkillSystem.SpellSkill.Passive
{
    [CreateAssetMenu(fileName = "PassiveSpellSkillDog",menuName = "ScriptableObject/Skill/SpellSkill/Passive/Dog",order = 1)]
    public class PassiveSpellSkillDog : SkillBase
    {
        private float m_PastIncreaseValue;
        public override void SkillApply(UnitMono player,UnitMono enemy)
        {
            FightingUIManager.Instance.UpDateBehaviourText(this.m_name + "的技能触发：本回合的攻击将产生额外的百分之20伤害");
            m_PastIncreaseValue = player.increaseValue;
            player.increaseValue *= 1.2f;
            m_PastIncreaseValue -= player.increaseValue;
        }
        public override void SkillDisable(UnitMono player,UnitMono enemy)
        {
            FightingUIManager.Instance.UpDateBehaviourText(this.m_name + "的技能停止");
            player.increaseValue += m_PastIncreaseValue;
        }
        
    }
}
