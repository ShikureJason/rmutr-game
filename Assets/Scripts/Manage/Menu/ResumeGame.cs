using UnityEngine;

public class ResumeGame : MonoBehaviour
{
    [SerializeField] private SaveDataSO _saveData;
    [Header("Event Emitter")]
    [SerializeField] private SceneEvent _loadSceneEventEmitter;

    public void loadData()
    {
        _loadSceneEventEmitter.RaiseEvent(_saveData.SaveData.CurrentScene);
    }
}
