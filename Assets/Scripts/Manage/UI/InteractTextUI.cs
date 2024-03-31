using System;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public class InteractTextUI
{
    [SerializeField] private LocalizedString _interractText = default;
    [SerializeField] private InteractType _interractType = default;

    public LocalizedString InterractText => _interractText;
    public InteractType InteractType => _interractType;
}
