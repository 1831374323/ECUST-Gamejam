using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Skill/KunAtk")]
    public class KunAtkSkill : PositionAtkSkill
    {
        [SerializeField]
        List<int> atkValue = new List<int>();
        protected override float GetAtkValue(int level)
        {
            int hpValue;
            int shieldValue;
            int result = atkValue[level];
            m_target.GetComingDamage(atkValue[level], out hpValue, out shieldValue);
            if (m_target.shield > atkValue[level] * 1.5)
            {
                result = (int)(atkValue[level] * 1.5f);

            }
            else if (shieldValue > 0)
            {
                result = (int)(atkValue[level] - shieldValue / 1.5 + shieldValue);
            }
            Debug.Log($"坤进行{level}阶攻击,对护盾额外造成{result-hpValue-shieldValue}伤害");
            return result;
        }

    }
}
