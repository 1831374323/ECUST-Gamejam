using FightingScene.UnitSystem;
using UnityEngine;
using System;

namespace EcustGamejam
{
    public abstract class PositionDefenceSkill : PositionSkill
    {
        //技能释放者
        protected UnitMono m_skillUser;
        //非技能释放者，而非技能目标
        protected UnitMono m_target;
        public override void SkillApply(UnitMono skillUser, UnitMono target, int level)
        {
            string behaviourText = $"释放{level+1}阶{m_name}";
            base.SkillApply(skillUser, target, level);
            m_skillUser = skillUser;
            m_target = target;

            if (MpCost.Count > level)
            {
                if (!skillUser.SetMp(-MpCost[level]))
                {
                    FightingUIManager.Instance.UpDateBehaviourText("蓝量不足");
                    return;
                }
            }

            float defValue = GetDefValue(level);

            //克制关系
            if (PositionManager.Instance.GetCounterRelation(skillUser, target)
                == PositionManager.CounterRelation.Counter)
            {
                behaviourText += ",效果拔群！！！";
                defValue *= 1.2f;
            }
            else if (PositionManager.Instance.GetCounterRelation(skillUser, target)
                == PositionManager.CounterRelation.Countered)
            {
                behaviourText += ",效果微弱...O.o";
                defValue *= 0.8f;
            }

            skillUser.shield += (int)(defValue * skillUser.shieldIncreaseValue);
            
            FightingUIManager.Instance.UpDateBehaviourText(behaviourText);
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