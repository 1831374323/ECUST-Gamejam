using System.Collections.Generic;
using FightingScene.SpellSystem;
using FightingScene.UnitSystem;
using UnityEngine;
using Frame.Core;

namespace FightingScene.Managers
{
    public class SpellManager : SingletonBase<SpellManager>
    {
        
        [Tooltip("符咒列表")] public List<Spells> spells ;
        [Tooltip("敌人")] public UnitMono enemy;
        [Tooltip("玩家")] public UnitMono player;


        /// <summary>
        /// 使这个id的符咒生效
        /// </summary>
        /// <param name="id"></param>
        public void SpellApply(int id)
        {
            spells[id].activeSkill.SkillApply(player, enemy);
        }
        
        /// <summary>
        /// 使这个id的符咒失效
        /// </summary>
        /// <param name="id"></param>
        public void SpellDisable(int id)
        {
            spells[id].activeSkill.SkillDisable(player, enemy);
        }
        
        /// <summary>
        /// 使用符咒的主动技能
        /// </summary>
        /// <param name="id"></param>
        public void SpellMotive(int id)
        {
            spells[id].passiveSkill.SkillApply(player, enemy);
        }
        
        /// <summary>
        /// 停止符咒的主动技能
        /// </summary>
        /// <param name="id"></param>
        public void SpellMotiveDisable(int id)
        {
            spells[id].passiveSkill.SkillDisable(player, enemy);
        }
    }
}
