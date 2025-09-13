using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "LittleSword/GameEvent")]
public class GameEvent : ScriptableObject
{
    // 이벤트 구독자(리스너) 관리
    private List<GameEventListener> listeners = new List<GameEventListener>();
    
    // 이벤트 구독 등록
    public void AddListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }
    
    // 이벤트 구독 해지
    public void RemoveListener(GameEventListener listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
    
    // 이벤트 발행
    public void Raise()
    {
        foreach (var listener in listeners)
        {
            listener.OnEventRaised();
        }
    }
}
