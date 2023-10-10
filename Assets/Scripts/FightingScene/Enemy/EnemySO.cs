using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName ="MyData/Enemy")]
    public class EnemySO : ScriptableObject
    {
        public string m_name;
        public string description;
        public List<EnemySkillBase> skillRecycle;
        public int maxHp;
        public int speed;
        public int shield;
        public Sprite image;
        public Sprite headImage;
        public string scriptName;
        public Position buffPosition;
    }
}