using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Skill/LiAtk")]
    public class LiAtkSkill : PositionAtkSkill
    {
        [SerializeField]
        List<int> atkValue = new List<int>();
        public BurningBuffSO burningBuffSO;
        protected override float GetAtkValue(int level)
        {
            Debug.Log($"Àë½øÐÐ{level}½×¹¥»÷");

            BurningBuff burningBuff = new BurningBuff(burningBuffSO);
            burningBuff.AddBuff(base.m_target);

            return atkValue[level];
        }

    }
}
