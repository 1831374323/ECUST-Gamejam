using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Skill/GenAtk")]
    public class GenAtkSkill : PositionAtkSkill
    {
        [SerializeField]
        List<int> atkValue = new List<int>();
        protected override float GetAtkValue(int level)
        {
            Debug.Log($"�޽���{level}�׹���,�������{m_skillUser.cureMp/5}�˺�");
            return atkValue[level]+m_skillUser.cureMp/5;
        }

    }
}