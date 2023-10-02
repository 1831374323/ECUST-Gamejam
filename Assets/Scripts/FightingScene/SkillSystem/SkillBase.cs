using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    public class SkillBase : ScriptableObject
    {
        public string m_name;
        public virtual void SkillApply()
        {

        }

        public virtual void SkillDisable()
        {

        }
    }
}