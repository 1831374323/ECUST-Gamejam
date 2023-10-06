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
            Debug.Log("这是" + this.m_name + "的调用技能：本回合的攻击将产生额外的百分之20伤害");
            m_PastIncreaseValue = player.increaseValue;
            player.increaseValue *= 1.2f;
            m_PastIncreaseValue -= player.increaseValue;
        }
        public override void SkillDisable(UnitMono player,UnitMono enemy)
        {
            Debug.Log("这是" + this.m_name + "的停止调用技能：");
            player.increaseValue += m_PastIncreaseValue;
        }
        
    }
}
