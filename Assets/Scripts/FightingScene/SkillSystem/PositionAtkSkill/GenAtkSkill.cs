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
            Debug.Log($"艮进行{level}阶攻击,额外造成{m_skillUser.cureMp/5}伤害");
            return atkValue[level]+m_skillUser.cureMp/5;
        }

    }
}