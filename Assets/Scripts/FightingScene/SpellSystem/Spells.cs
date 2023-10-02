using EcustGamejam;
using UnityEngine;

namespace FightingScene.SpellSystem
{ 
 /// <summary>
 /// 符咒的基类
 /// </summary>
 
 [CreateAssetMenu(fileName = "Spell",menuName = "ScriptableObject/Spell",order = 0)]
 public class Spells : ScriptableObject
    {
        [SerializeField, Tooltip("符咒id")] public int id = -1;
        [SerializeField, Tooltip("符咒名字")] public new string name = "null";
        [SerializeField, Tooltip("符咒技能描述")] private string description = "null";

        [SerializeField, Tooltip("符咒主动技能")] public SkillBase activeSkill;
        [SerializeField, Tooltip("符咒被动技能")] public SkillBase passiveSkill;
    }
}
