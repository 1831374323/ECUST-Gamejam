using UnityEngine;

namespace FightingScene.SpellSystem
{ 
 /// <summary>
 /// 符咒的基类
 /// </summary>
    public class Spells : ScriptableObject
    {
        [SerializeField, Tooltip("符咒id")] public int id = -1;
        [SerializeField, Tooltip("符咒名字")] public new string name = "null";
        [SerializeField, Tooltip("符咒技能描述")] public string description = "null";
        /// <summary>
        /// 符咒的效果
        /// </summary>
        public virtual void Skill(){Debug.Log("调用符咒技能");} 
        public virtual void KillSkill(){Debug.Log("符咒技能结束");} 
    }
}
