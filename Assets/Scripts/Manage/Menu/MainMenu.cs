using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SaveDataSO _saveData;
    [SerializeField] private GameObject _selectCharacterPanel;
    [SerializeField] private GameObject _confirmNewGamePanel;

    public void StatNewData()
    {
        _saveData.SetNewData();
        _selectCharacterPanel.SetActive(true);

    }
    public void StartNewGame()
    {
        if (_saveData.HasSaveData())
        {
            gameObject.SetActive(false);
            _confirmNewGamePanel.SetActive(true);
        }
        else 
        {
            StatNewData();
        }

    }

    public void ContinueGame()
    {

    }

    public void Exit()
    {

    }
}
