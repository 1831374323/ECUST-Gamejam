using System.Collections;
using System.Collections.Generic;
using FightingScene.UnitSystem;
using Frame.Core;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace EcustGamejam
{
    public class FightingUIManager : SingletonBase<FightingUIManager>
    {
        public Image hpBar;
        public Image mpBar;
        UnitMono player;
        UnitMono enemy;
        GameObject[] buttons;
        public GameObject[] innerButtons;
        public GameObject[] outerButtons;

        public GameObject playerPosition;
        public GameObject enemyPosition;

        public GameObject endroundButton;

        // Start is called before the first frame update
        void Start()
        {
            player = FightingManager.Instance.player;
            enemy = FightingManager.Instance.enemy;

            buttons = GameObject.FindGameObjectsWithTag("PositionButton");
            ClosePositionMessage();

            FightingManager.Instance.OnPlayerRoundStartAction += UpDatePlayerPosition;
            FightingManager.Instance.OnPlayerRoundStartAction += () => { endroundButton.SetActive(true); };
            FightingManager.Instance.OnEnemyRoundStartAction += () => { endroundButton.SetActive(false); };
        }

        // Update is called once per frame
        void Update()
        {
            UpdateUI();
        }

        public void LoadLevelScene()
        {
            GameManager.Instance.LoadScene(GameManager.SceneName.LevelScene);
        }

        void UpdateUI()
        {

            hpBar.fillAmount = (float)player.CurrentHp / player.maxHp;

            mpBar.fillAmount = (float)player.CurrentMP / player.maxMp;
        }


        public GameObject positionMessage;
        /// <summary>
        /// ��ʾ��λ��Ϣ
        /// </summary>
        /// <param name="id"></param>
        public void ShowPositionMessage(int id)
        {
            positionMessage.SetActive(true);

            Position position = PositionManager.Instance.positions[id];
            Text text = positionMessage.transform.Find("Text").GetComponent<Text>();

            foreach (var button in buttons)
            {
                button.GetComponent<Image>().color = Color.white;
                if (button.GetComponent<PositionButton>().position.wuXing.id == position.wuXing.counterID)
                {
                    button.GetComponent<Image>().color = Color.green;
                }
                else if (button.GetComponent<PositionButton>().position.wuXing.id == position.wuXing.counteredID)
                {
                    button.GetComponent<Image>().color = Color.red;
                }
            }
            text.text =
                $"��λ��{position.m_name}\r\n" +
                $"���ԣ�{position.wuXing.m_name}\r\n" +
                $"���ƣ��̣���{position.wuXing.counterName}\r\n" +
                $"�����ƣ��죩��{position.wuXing.counteredName}";

        }

        /// <summary>
        /// �ر���λ��Ϣ
        /// </summary>
        public void ClosePositionMessage()
        {
            foreach (var button in buttons)
            {
                button.GetComponent<Image>().color = Color.white;

            }
            positionMessage.SetActive(false);
        }

        public void UpDatePlayerPosition()
        {
            playerPosition.transform.position =
                innerButtons[FightingManager.Instance.player.currentPosition].transform.position;
        }

        public void UpdateEnemyPosition()
        {
            enemyPosition.transform.position =
                outerButtons[FightingManager.Instance.enemy.currentPosition].transform.position;
        }
    }
}