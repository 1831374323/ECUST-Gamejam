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

            //���ƹ�ϵ
            if (PositionManager.Instance.GetCounterRelation(skillUser, target)
                == PositionManager.CounterRelation.Counter)
            {
                Debug.Log("��������");
                atkValue *= 1.6f;
            }
            else if (PositionManager.Instance.GetCounterRelation(skillUser, target)
                == PositionManager.CounterRelation.Countered)
            {
                Debug.Log("����������");
                atkValue *= 0.5f;
            }

            //����
            if (FightingManager.Instance.criticalState)
            {

                if (UnityEngine.Random.Range(0, 100) <= skillUser.criticalHitRate)
                {
                    Debug.Log("��������");
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