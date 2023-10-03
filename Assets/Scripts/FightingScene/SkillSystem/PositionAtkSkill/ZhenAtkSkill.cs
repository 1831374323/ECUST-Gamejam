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
        protected override float GetAtkValue(int level)
        {
            Debug.Log($"�����{level}�׹���");
            return atkValue[level];
        }
    }
}