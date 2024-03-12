using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private SaveDataSO _saveData;
    [SerializeField] private GameObject _continuegameButton;

    private void Start()
    {
        _continuegameButton.SetActive(_saveData.HasSaveData());
    }
    public void SetActiveMainMenu(bool expression)
    {
        gameObject.SetActive(expression);
    }
}
