using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Skill/Def/GenDef")]
    public class GenDefSkill : PositionDefenceSkill
    {
        [SerializeField]
        List<int> defValue = new List<int>();
        protected override float GetDefValue(int level)
        {
            Debug.Log($"ôÞ½øÐÐ{level}½×·ÀÓù");
            return defValue[level]+(int)(m_skillUser.maxMp*0.1);
        }

    }
}