using UnityEngine;

public class InitializeGameManage : MonoBehaviour
{
    [Header("Event Emitter")] 
    [SerializeField] private VoidEvent _gameManageHasStartEvent = default;

    private InitializeGameManage instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
