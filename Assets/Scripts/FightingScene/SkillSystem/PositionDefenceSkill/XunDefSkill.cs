using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Skill/Def/XunDef")]
    public class XunDefSkill : PositionDefenceSkill
    {
        [SerializeField]
        List<int> defValue = new List<int>();
        protected override float GetDefValue(int level)
        {
            Debug.Log($"Ùã½øÐÐ{level}½×·ÀÓù");
            return defValue[level];
        }

    }
}
