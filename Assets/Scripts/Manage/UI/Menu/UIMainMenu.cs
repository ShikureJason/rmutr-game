using UnityEngine;
using UnityEngine.UIElements;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private SaveDataSO _saveData;
    [SerializeField] private GameObject _continuegameButton;


    public const string MenuName = "Menu";

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnDisable()
    {
        
    }

    private void Start()
    {
        _continuegameButton.SetActive(_saveData.HasSaveData());
    }
    public void SetActiveMainMenu(bool expression)
    {
        gameObject.SetActive(expression);
    }
}
