using FightingScene.UnitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Skill/Enemy/Enemy0")]
    public class Enemy0Skill0 : SkillBase
    {
        public int damageVakue;
        public int shieldValue;

        public override void SkillApply(UnitMono skillUser, UnitMono target)
        {
            base.SkillApply(skillUser, target);
            FightingManager.Instance.DoDamage(damageVakue ,target);
            skillUser.shield += (int)(shieldValue * skillUser.shieldIncreaseValue);
        }

        public override void SkillDisable(UnitMono skillUser, UnitMono target)
        {
            base.SkillDisable(skillUser, target);
        }

        
    }
}