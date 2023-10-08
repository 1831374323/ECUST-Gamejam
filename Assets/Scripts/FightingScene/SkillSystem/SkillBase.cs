using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using FightingScene.UnitSystem;

namespace EcustGamejam
{
    public class SkillBase : ScriptableObject
    {
        public string m_name;
        public virtual void SkillApply(UnitMono skillUser,UnitMono target)
        {
            
        }

        public virtual void SkillDisable(UnitMono skillUser, UnitMono target)
        {

        }
    }
}