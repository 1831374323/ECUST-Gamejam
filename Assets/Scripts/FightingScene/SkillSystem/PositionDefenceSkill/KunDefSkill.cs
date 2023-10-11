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
            if (m_target.currentPosition == 2 || m_target.currentPosition == 6)
            {
                Debug.Log($"������{level}�׷���,����Ч������");
                return 2 * defValue[level];
            }

            else
            {
                Debug.Log($"������{level}�׷���");
                return defValue[level];
            }
        }

    }
}
