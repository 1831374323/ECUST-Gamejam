using EcustGamejam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyData/Buff/BurningBuff")]
public class BurningBuffSO : BuffSO
{
    public List<int> probability = new List<int>();
    public int burningValue;
}
