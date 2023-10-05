using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Skill/Def/KunDef")]
    public class KunDefSkill : PositionDefenceSkill
    {
        [SerializeField]
        List<int> defValue = new List<int>();
        protected override float GetDefValue(int level)
        {
            Debug.Log($"À¤½øÐÐ{level}½×·ÀÓù");
            return defValue[level];
        }

    }
}
