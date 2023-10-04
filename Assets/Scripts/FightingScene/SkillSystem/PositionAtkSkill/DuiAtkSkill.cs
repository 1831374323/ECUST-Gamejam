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
        public DamageReduceBuffSO damageReduceBuffSO;

        protected override float GetAtkValue(int level)
        {
            DamageReduceBuff damageReduceBuff = new DamageReduceBuff(damageReduceBuffSO);
            damageReduceBuff.AddBuff(m_target, level);

            Debug.Log($"�ҽ���{level}�׹���");
            return atkValue[level];
        }

    }
}
