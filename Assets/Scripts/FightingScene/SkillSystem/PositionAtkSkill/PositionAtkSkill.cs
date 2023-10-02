using FightingScene.UnitSystem;
using UnityEngine;
using System;

namespace EcustGamejam
{
    public abstract class PositionAtkSkill : SkillBase
    {
        public override void SkillApply(UnitMono skillUser, UnitMono target)
        {
            base.SkillApply(skillUser, target);

            float atkValue = GetAtkValue();

            //克制关系
            if (PositionManager.Instance.GetCounterRelation(skillUser, target)
                == PositionManager.CounterRelation.Counter)
            {
                Debug.Log("触发克制");
                atkValue *= 1.6f;
            }
            else if (PositionManager.Instance.GetCounterRelation(skillUser, target)
                == PositionManager.CounterRelation.Countered)
            {
                Debug.Log("触发被克制");
                atkValue *= 0.5f;
            }

            //暴击
            if (FightingManager.Instance.criticalState)
            {

                if (UnityEngine.Random.Range(0, 100) <= skillUser.criticalHitRate)
                {
                    Debug.Log("触发暴击");
                    atkValue *= skillUser.criticalStrikeRate;

                }
            }

            target.SetHp((int)-atkValue);
        }

        protected abstract float GetAtkValue();


        public override void SkillDisable(UnitMono skillUser, UnitMono target)
        {
            base.SkillDisable(skillUser, target);
        }
    }
}