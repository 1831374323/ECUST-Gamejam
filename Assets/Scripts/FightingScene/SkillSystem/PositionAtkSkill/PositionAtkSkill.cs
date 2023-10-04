using FightingScene.UnitSystem;
using UnityEngine;
using System;

namespace EcustGamejam
{
    public abstract class PositionAtkSkill : PositionSkill
    {
        protected UnitMono m_skillUser;
        protected UnitMono m_target;
        public override void SkillApply(UnitMono skillUser, UnitMono target, int level)
        {

            base.SkillApply(skillUser, target, level);

            m_skillUser= skillUser;
            m_target= target;

            if (MpCost.Count > level)
            {
                if (!skillUser.SetMp(-MpCost[level]))
                {
                    Debug.Log("��������");
                    return;
                }
            }

            float atkValue = GetAtkValue(level);

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

            FightingManager.Instance.DoDamage((int)atkValue, target);
        }

        /// <summary>
        /// ������ɵ��˺���ִ������Ч��
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        protected abstract float GetAtkValue(int level);


        public override void SkillDisable(UnitMono skillUser, UnitMono target, int level)
        {
            base.SkillDisable(skillUser, target, level);
        }
    }
}