using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Skill/Def/ZhenDef")]
    public class ZhenDefSkill : PositionDefenceSkill
    {
        [SerializeField]
        List<int> defValue = new List<int>(); 
        public ParalysisBuffSO paralysisBuffSO;
        protected override float GetDefValue(int level)
        {         
            ParalysisBuff paralysisBuff = new ParalysisBuff(paralysisBuffSO);
            paralysisBuff.AddBuff(m_target, level);
            Debug.Log($"Õð½øÐÐ{level}½×·ÀÓù");
            return defValue[level];
        }

    }
}
