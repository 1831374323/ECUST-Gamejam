using EcustGamejam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyData/Buff/BurningBuff")]
public class BurningBuffSO : BuffSO
{
    public int burningValue;

    /*
     

    （卦位直接伤害*克制系数*暴击倍率+卦位buff伤害+符咒伤害）*（增伤系数*减伤系数）

    
     
     */
}
