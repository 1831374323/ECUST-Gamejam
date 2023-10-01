using System.Collections.Generic;
using FightingScene.SpellSystem;
using UnityEngine;

namespace FightingScene.Managers
{
    public class SpellManager : MonoBehaviour
    {
        [Tooltip("符咒列表")] public List<Spells> spells ;

        private void Start()
        {
            SpellApply(0);
            SpellDisable(0);
        }
        
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
    }
}
