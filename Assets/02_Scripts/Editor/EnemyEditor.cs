using LittleSword.Enemy;
using LittleSword.Enemy.FSM;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Enemy enemy = (Enemy)target;

        DrawDefaultInspector();
        
        EditorGUILayout.Space(10);

        GUI.enabled = Application.isPlaying;

        if (GUILayout.Button("Idle"))
        {
            enemy.ChangeState<IdleState>();
        }
        
        if (GUILayout.Button("Chase"))
        {
            enemy.ChangeState<ChaseState>();
        }
        
        if (GUILayout.Button("Attack"))
        {
            enemy.ChangeState<AttackState>();
        }        
        
        GUI.enabled = true;
    }
}
