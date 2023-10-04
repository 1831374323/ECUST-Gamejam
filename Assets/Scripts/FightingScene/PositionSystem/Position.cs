using EcustGamejam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Position", menuName = "MyData/Position")]
public class Position : ScriptableObject
{
    public int id;
    public string m_name;
    public string color;
    public PositionAtkSkill Attackskill;
    public PositionDefenceSkill defenceSkill;
    public WuXing wuXing;
}
