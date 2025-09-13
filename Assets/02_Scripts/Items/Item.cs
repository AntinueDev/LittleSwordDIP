using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Consumable,
}

[CreateAssetMenu(fileName = "Item", menuName = "LittleSword/Item")]
public class Item : ScriptableObject
{
    [Header("Basic Info")] 
    public string itemName;
    [TextArea(3, 5)] 
    public string description;
    public Sprite icon;
    public ItemType itemType;

    [Header("Item Stats")] 
    public int damage;
    public int defense;
    
    [Header("Effects")]
    public ItemEffect[] effects;
    
    // 아이템 사용할 때 호출하는 메소드
    public void UseItem(GameObject target)
    {
        foreach (var effect in effects)
        {
            effect.ApplyEffect(target);
        }
    }
}
