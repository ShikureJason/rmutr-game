using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Create Dialogue")]
public class DialogueSO : ScriptableObject{

    [SerializeField] private List<DialogueDetail> _dialogueLine;
    [SerializeField] private bool _isDone = false;

    public List<DialogueDetail> DialogueLine => _dialogueLine;
    public bool IsDone
    {
        get { return _isDone; }
        set { _isDone = value; }
    }  
}
