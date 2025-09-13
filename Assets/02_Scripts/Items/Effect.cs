using LittleSword.Player;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "LittleSword/Effect/HealEffect")]
public class Effect : ItemEffect
{
    public int healAmount = 20;
    
    public override void ApplyEffect(GameObject target)
    {
        target.GetComponent<BasePlayer>().CurrentHP += healAmount;
    }
}
