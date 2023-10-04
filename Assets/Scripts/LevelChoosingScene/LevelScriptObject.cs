using UnityEngine;
using UnityEngine.Serialization;

namespace LevelChoosingScene
{
    [CreateAssetMenu(fileName = "Level",menuName = "ScriptableObject/Level",order = 1)]
    public class LevelScriptObject : ScriptableObject
    {
        [Tooltip("关卡编号")] public int levelId=-1;
        [Tooltip("关卡描述")] public string description = "关卡信息：";
        [Tooltip("敌人描述")] public string enemyDescription = "敌人信息：";
        [Tooltip("敌人头像")] public Sprite enemySprite;
    }
}
