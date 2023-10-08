using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Skill/KanAtk")]
    public class KanAtkSkill : PositionAtkSkill
    {
        [SerializeField]
        List<int> atkValue = new List<int>();
        protected override float GetAtkValue(int level)
        {
            //Debug.Log($"¿²½øÐÐ{level}½×¹¥»÷");
            
            return atkValue[level];
        }

    }
}
