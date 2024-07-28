using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIChoseCharacter : MonoBehaviour
{
    [SerializeField] private List<CharacterPrefapSO> _character = default;

    [SerializeField] private VoidEvent _startNextSceneEmitter = default;
    [SerializeField] private VoidEvent _sceneReadyEventListener = default;

    private UIView choseCharacerView;

    private const string choseCharacterName = "container";

    private void OnEnable()
    {
        //GetComponent<UIDocumentLocalization>().onCompleted += setupViews;
        _sceneReadyEventListener.OnEventRaised += ready;
    }

    private void OnDisable()
    {
        //GetComponent<UIDocumentLocalization>().onCompleted -= setupViews;
        _sceneReadyEventListener.OnEventRaised -= ready;
        ChoseCharacterView.ChoseCharacterEvent.OnEventRaised -= choseCharacter;
    }

    private void ready()
    {
        Debug.Log("Ready");
    }
    private void Start()
    {
        setupViews(GetComponent<UIDocument>().rootVisualElement);
    }

    private void setupViews(VisualElement root)
    {
        Debug.LogError("Open");
        choseCharacerView = new ChoseCharacterView(root.Q<VisualElement>(choseCharacterName));

        ChoseCharacterView.ChoseCharacterEvent.OnEventRaised += choseCharacter;
        choseCharacerView.Show();
    }

    private void choseCharacter(int characterID)
    {
        Debug.LogError("Select " + characterID);
        GameData.Instance.CurrentSave.CurrentCharacter = _character[characterID];
        
        _startNextSceneEmitter.RaiseEvent();
    }
}
