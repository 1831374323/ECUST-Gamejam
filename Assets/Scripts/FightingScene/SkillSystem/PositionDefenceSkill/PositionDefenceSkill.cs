using FightingScene.UnitSystem;
using UnityEngine;
using System;

namespace EcustGamejam
{
    public abstract class PositionDefenceSkill : PositionSkill
    {
        protected UnitMono m_skillUser;
        protected UnitMono m_target;
        public override void SkillApply(UnitMono skillUser, UnitMono target, int level)
        {

            base.SkillApply(skillUser, target, level);
            m_skillUser = skillUser;
            m_target = target;

            if (MpCost.Count > level)
            {
                if (!skillUser.SetMp(-MpCost[level]))
                {
                    Debug.Log("蓝量不足");
                    return;
                }
            }

            float defValue = GetDefValue(level);

            //克制关系
            if (PositionManager.Instance.GetCounterRelation(skillUser, target)
                == PositionManager.CounterRelation.Counter)
            {
                Debug.Log("触发克制");
                defValue *= 1.2f;
            }
            else if (PositionManager.Instance.GetCounterRelation(skillUser, target)
                == PositionManager.CounterRelation.Countered)
            {
                Debug.Log("触发被克制");
                defValue *= 0.8f;
            }

            ////暴击
            //if (FightingManager.Instance.criticalState)
            //{

            //    if (UnityEngine.Random.Range(0, 100) <= skillUser.criticalHitRate)
            //    {
            //        Debug.Log("触发暴击");
            //        defValue *= skillUser.criticalStrikeRate;

            //    }
            //}

            skillUser.shield += (int)(defValue * skillUser.shieldIncreaseValue);
        }

        /// <summary>
        /// 返回获得的护盾并执行其他效果
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        protected abstract float GetDefValue(int level);


        public override void SkillDisable(UnitMono skillUser, UnitMono target, int level)
        {
            base.SkillDisable(skillUser, target, level);
        }
    }
}