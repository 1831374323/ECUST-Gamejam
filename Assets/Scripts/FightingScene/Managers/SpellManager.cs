using System.Collections.Generic;
using FightingScene.SpellSystem;
using UnityEngine;
using Frame.Core;

namespace FightingScene.Managers
{
    public class SpellManager : SingletonBase<SpellManager>
    {
        [Tooltip("符咒列表")] public List<Spells> spells ;
        
        /// <summary>
        /// 使这个id的符咒生效
        /// </summary>
        /// <param name="id"></param>
        public void SpellApply(int id)
        {
            spells[id].Skill();
        }
        
        /// <summary>
        /// 使这个id的符咒失效
        /// </summary>
        /// <param name="id"></param>
        public void SpellDisable(int id)
        {
            spells[id].KillSkill();
        }
        
        /// <summary>
        /// 使用符咒的主动技能
        /// </summary>
        /// <param name="id"></param>
        public void SpellMotive(int id)
        {
            spells[id].MotiveSkill();
        }
        
        /// <summary>
        /// 停止符咒的主动技能
        /// </summary>
        /// <param name="id"></param>
        public void SpellMotiveDisable(int id)
        {
            spells[id].KillMotiveSkill();
        }
    }
}
