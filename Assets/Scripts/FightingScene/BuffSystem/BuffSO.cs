using FightingScene.UnitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    public class BuffSO : ScriptableObject
    {
        public string m_name;
        public int existTurn;
        public Buff.ApplyTime applyTime;
        public Buff.Type type;
        public Sprite icon;
        public string description;
    }
}