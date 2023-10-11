using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Skill/ZhenAtk")]
    public class ZhenAtkSkill : PositionAtkSkill
    {
        [SerializeField]
        List<int> atkValue = new List<int>();
        public List<int> probability = new List<int>();

        public ParalysisBuffSO paralysisBuffSO;
        protected override float GetAtkValue(int level)
        {
            ParalysisBuff paralysisBuff = new ParalysisBuff(paralysisBuffSO);

            if (Random.Range(0, 100) < probability[level])
            {
                paralysisBuff.AddBuff(m_target, level);
            }

            return atkValue[level];
        }
    }
}