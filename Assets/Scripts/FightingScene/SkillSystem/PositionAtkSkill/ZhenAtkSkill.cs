using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Skill/ZhenAtk")]
    public class ZhenAtkSkill : PositionAtkSkill
    {
        [SerializeField]
        List<int> atkValue = new List<int>();
        public ParalysisBuffSO paralysisBuffSO;
        protected override float GetAtkValue(int level)
        {
            ParalysisBuff paralysisBuff = new ParalysisBuff(paralysisBuffSO);
            paralysisBuff.AddBuff(m_target,level);

            Debug.Log($"�����{level}�׹���");

            return atkValue[level];
        }
    }
}