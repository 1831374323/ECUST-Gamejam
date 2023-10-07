using System;
using Frame.Core;
using Managers;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace LevelChoosingScene
{
    public class SettingUIManager : SingletonBase<SettingUIManager>
    {
        [SerializeField, Tooltip("设置UI")] private GameObject settingUI;
        [SerializeField, Tooltip("音量滑块")] private Slider voiceSlider;
        [SerializeField, Tooltip("音效滑块")] private Slider sFXSlider;

        void Awake()
        {
            voiceSlider.value = PlayerPrefs.GetFloat("CurMusicVolume", 0);
            sFXSlider.value = PlayerPrefs.GetFloat("CurSFXVolume", 0);
            //初始化音量
            AudioManager.instance.InitMusicSld();
            AudioManager.instance.InitSoundSld();
        }
        
        /// <summary>
        ///  脚本实际上只是起到了传递参数的作用,因为AudioManager是持续单例，在某些场景中不是初始存在，无法直接挂载到组件上，需要使用代码动态调用
        /// </summary>
        public void MusicSldOnClick()
        {
            AudioManager.instance.MusicSldOnClick(voiceSlider);
            PlayerPrefs.SetFloat("CurMusicVolume",voiceSlider.value);
        }
        public void SoundSldOnClick()
        {
            AudioManager.instance.SoundSldOnClick(sFXSlider);
            PlayerPrefs.SetFloat("CurSFXVolume",sFXSlider.value);
        }

        
        /// <summary>
        /// 设置UI关闭和打开方法
        /// </summary>
        public void OpenCloseSettingUI()
        {
            settingUI.SetActive(!settingUI.activeSelf);
            AudioManager.instance.PlaySound(0);
        }

    }
}
