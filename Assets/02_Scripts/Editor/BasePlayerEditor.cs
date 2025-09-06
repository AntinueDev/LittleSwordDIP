using UnityEditor;
using LittleSword.Player;
using UnityEngine;

[CustomEditor(typeof(Warrior))]
public class BasePlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BasePlayer basePlayer = (BasePlayer)target;
        // 기본 인스펙터 내용을 랜더링
        DrawDefaultInspector();
        
        // PlayerStats maxHP (입력 가능한 필드)
        basePlayer.playerStats.maxHP = EditorGUILayout.IntField("Max HP", basePlayer.playerStats.maxHP);
        // 현재 HP 출럭
        EditorGUILayout.LabelField("Current HP", basePlayer.CurrentHP.ToString());
        
        // 버튼 생성
        if (GUILayout.Button("피격"))
        {
            basePlayer.TakeDamage(10);
        }

        if (GUILayout.Button("초기화"))
        {
            basePlayer.CurrentHP = basePlayer.playerStats.maxHP;
        }
        
    }
}