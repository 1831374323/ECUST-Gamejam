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
            FightingUIManager.Instance.UpDateBehaviourText("特殊效果触发，本次攻击可能触发暴击效果");
            FightingManager.Instance.ChangeCriticalState(true);
        }
        public override void SkillDisable(UnitMono player,UnitMono enemy)
        {
            FightingUIManager.Instance.UpDateBehaviourText("暴击停止");
            FightingManager.Instance.ChangeCriticalState(false);
        }
    }
}
