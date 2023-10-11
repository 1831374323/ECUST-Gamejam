using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Skill/Def/KanDef")]
    public class KanDefSkill : PositionDefenceSkill
    {
        public ShieldHealBuffSO shieldHealBuffSO;
        [SerializeField]
        List<int> defValue = new List<int>();
        protected override float GetDefValue(int level)
        {
            Debug.Log($"������{level}�׷���");
            ShieldHealBuff shieldHealBuff = new ShieldHealBuff(shieldHealBuffSO);
            shieldHealBuff.AddBuff(base.m_skillUser);
            return defValue[level];
        }

    }
}
