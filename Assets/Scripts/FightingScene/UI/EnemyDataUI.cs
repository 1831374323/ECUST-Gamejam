using EcustGamejam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDataUI : MonoBehaviour
{
    public Text text;
    private EnemySO data;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        EnemyBase enemyBase= (EnemyBase)FightingManager.Instance.enemy;
        data = enemyBase.myData;

        text.text = $"怪物名称：{data.m_name}\r\n" +
                    $"怪物描述：{data.description}\r\n" +
                    $"怪物速度：{enemyBase.speed}\r\n";
    }
}
