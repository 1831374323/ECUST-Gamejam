using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Skill/DuiAtk")]
    public class DuiAtkSkill : PositionAtkSkill
    {
        [SerializeField]
        List<int> atkValue = new List<int>();
        protected override float GetAtkValue(int level)
        {
            Debug.Log($"�ҽ���{level}�׹���");
            return atkValue[level];
        }

    }
}
