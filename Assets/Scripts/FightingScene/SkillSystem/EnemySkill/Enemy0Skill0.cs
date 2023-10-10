using FightingScene.UnitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Skill/Enemy/Enemy0")]
    public class Enemy0Skill0 : EnemySkillBase
    {
        public int damageValue;
        public int shieldValue;

        public override void SkillApply(UnitMono skillUser, UnitMono target)
        {
            base.SkillApply(skillUser, target);
            Debug.Log("ººƒ‹ Õ∑≈");
            FightingManager.Instance.DoDamage(damageValue ,target);
            skillUser.shield += (int)(shieldValue * skillUser.shieldIncreaseValue);
        }

        public override void SkillBuffedApply(UnitMono skillUser, UnitMono target)
        {
            base.SkillBuffedApply(skillUser, target);
            FightingManager.Instance.DoDamage(damageValue*2, target);
            skillUser.shield += (int)(shieldValue * skillUser.shieldIncreaseValue*2);
        }

        public override void SkillDisable(UnitMono skillUser, UnitMono target)
        {
            base.SkillDisable(skillUser, target);
            
        }

        
    }
}