using System.Collections;
using System.Collections.Generic;
using FightingScene.UnitSystem;
using Frame.Core;
using Managers;
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
            UpdateShieldValue();
        }

        public void LoadLevelScene()
        {
            GameManager.Instance.LoadScene(GameManager.SceneName.LevelScene);
            AudioManager.instance.PlaySound(0);
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

        public Text hpText;
        public Text mpText;

        public void ShowHpText()
        {
            hpText.gameObject.SetActive(true);
            hpText.text = FightingManager.Instance.player.CurrentHp + "/" + FightingManager.Instance.player.maxHp;
        }

        public void HideHpText()
        {
            hpText.gameObject.SetActive(false);
        }

        public Text enemyHp;

        public void ShowEnemyHp()
        {
            enemyHp.gameObject.SetActive(true);
            enemyHp.text = FightingManager.Instance.enemy.CurrentHp + "/" + FightingManager.Instance.enemy.maxHp;
        }

        public void HideEnemyHp()
        {
            enemyHp.gameObject.SetActive(false);
        }

        public void ShowMpText()
        {
            mpText.gameObject.SetActive(true);
            mpText.text = FightingManager.Instance.player.CurrentMP + "/" + FightingManager.Instance.player.maxMp;
        }

        public void HideMpText()
        {
            mpText.gameObject.SetActive(false);
        }

        public GameObject levelOver;

        public Text behaviourText;

        public void UpDateBehaviourText(string text)
        {
            behaviourText.text = text;
        }

        #region-----------------buff----------------

        public GameObject buffIconPrefab;
        public GameObject enemyBuffList;
        public GameObject playerBuffList;

        public GameObject AddBuffIcon(UnitMono target, GameObject buffIcon,string description)
        {
            GameObject obj;
            if (target.gameObject.name == "Player")
            {
                obj = Instantiate(buffIcon, playerBuffList.transform);
            }
            else
            {
                obj = Instantiate(buffIcon, enemyBuffList.transform);
            }

            obj.transform.Find("Text").GetComponent<Text>().text = description;

            return obj;
        }
        #endregion

        public Text playerShield;
        public Text enemyShield;
        public void UpdateShieldValue()
        {
            playerShield.text = FightingManager.Instance.player.shield.ToString();
            enemyShield.text = FightingManager.Instance.enemy.shield.ToString();
        }
    }
}