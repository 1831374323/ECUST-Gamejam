using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Buff/ShieldHealBuff")]
    public class ShieldHealBuffSO : BuffSO
    {
        public List<float> rate = new List<float>();
    }
}
