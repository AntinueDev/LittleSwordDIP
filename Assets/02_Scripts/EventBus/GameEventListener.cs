using TMPro;
using UnityEngine;
using Logger = LittleSword.Common.Logger;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private TextMeshProUGUI stateText;
    
    // 이벤트 등록
    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }
    
    // 이벤트 해지
    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
    
    // 이벤트 발행시 호출할 메소드
    public void OnEventRaised()
    {
        Logger.Log($"이벤트 수신 {gameEvent.name}");
        stateText.text = $"Event Type : {gameEvent.name}";
    }
}
