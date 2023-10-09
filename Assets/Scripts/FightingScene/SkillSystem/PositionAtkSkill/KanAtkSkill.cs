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
        public List<int> stealHp= new List<int>();
        protected override float GetAtkValue(int level)
        {
            int hpValue;
            int shieldValue;
            base.m_target.GetComingDamage(atkValue[level], out hpValue, out shieldValue);
            m_skillUser.SetHp((int)(hpValue * stealHp[level] * 0.01f));
            
            return atkValue[level];
        }

    }
}
