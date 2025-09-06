using UnityEngine;

namespace LittleSword.Interface
{
    public interface IDamageable
    {
        bool IsDead { get; }
        int CurrentHP { get; }
        void TakeDamage(int damage);
        void Die();
        
    }
}