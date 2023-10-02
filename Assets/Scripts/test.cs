using EcustGamejam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public QianAtkSkill skill;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        skill.SkillApply(FightingManager.Instance.player,FightingManager.Instance.enemy);
    }
}
