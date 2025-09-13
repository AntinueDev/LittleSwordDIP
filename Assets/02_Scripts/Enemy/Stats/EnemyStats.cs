using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "LittleSword/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    [Header("Basic Stats")] 
    public int maxHP = 100;
    public float moveSpeed = 2f;
    public float chaseRange = 5f;
    public float attackRange = 1.5f;
    public float attackDamage = 10f;
    public float attackCooldown = 1f;
    public float detectInterval = 0.3f;
}
