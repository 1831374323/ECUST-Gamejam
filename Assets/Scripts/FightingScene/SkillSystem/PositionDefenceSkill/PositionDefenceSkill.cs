using FightingScene.UnitSystem;
using UnityEngine;
using System;

namespace EcustGamejam
{
    public abstract class PositionDefenceSkill : PositionSkill
    {
        public override void SkillApply(UnitMono skillUser, UnitMono target, int level)
        {

            base.SkillApply(skillUser, target, level);

            if (MpCost.Count > level)
            {
                if (!skillUser.SetMp(-MpCost[level]))
                {
                    Debug.Log("��������");
                    return;
                }
            }

            float defValue = GetDefValue(level);

            //���ƹ�ϵ
            if (PositionManager.Instance.GetCounterRelation(skillUser, target)
                == PositionManager.CounterRelation.Counter)
            {
                Debug.Log("��������");
                defValue *= 1.2f;
            }
            else if (PositionManager.Instance.GetCounterRelation(skillUser, target)
                == PositionManager.CounterRelation.Countered)
            {
                Debug.Log("����������");
                defValue *= 0.8f;
            }

            ////����
            //if (FightingManager.Instance.criticalState)
            //{

            //    if (UnityEngine.Random.Range(0, 100) <= skillUser.criticalHitRate)
            //    {
            //        Debug.Log("��������");
            //        defValue *= skillUser.criticalStrikeRate;

            //    }
            //}

            //target.SetHp((int)-defValue);
        }

        /// <summary>
        /// ������ɵ��˺���ִ������Ч��
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