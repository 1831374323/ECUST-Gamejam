using FightingScene.UnitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    public abstract class PositionAtkSkill : SkillBase
    {
        public override void SkillApply(UnitMono skillUser, UnitMono target)
        {
            base.SkillApply(skillUser, target);

            int atkValue = GetAtkValue();


            target.SetHp(-atkValue);
        }

        protected abstract int GetAtkValue();


        public override void SkillDisable(UnitMono skillUser, UnitMono target)
        {
            base.SkillDisable(skillUser, target);
        }
    }
}