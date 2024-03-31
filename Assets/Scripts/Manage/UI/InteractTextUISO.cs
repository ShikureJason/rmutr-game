using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractText", menuName = "UI/Interact Text")]
public class InteractTextUISO : ScriptableObject
{
    [SerializeField] private List<InteractTextUI> _interactText = default;

    public List<InteractTextUI> InteractText => _interactText;
}
