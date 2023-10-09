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

        text.text = $"�������ƣ�{data.m_name}\r\n" +
                    $"����������{data.description}\r\n" +
                    $"ʣ��Ѫ����{enemyBase.CurrentHp}\r\n" +
                    $"��ǰ���ܣ�{enemyBase.shield}\r\n";
    }
}
