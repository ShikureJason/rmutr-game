using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Actor", menuName = "Character/Create Actor")]
public class CharacterSO : ScriptableObject
{
    [SerializeField] private List<CharacterPrefapSO> _characterDetail;

    public List<CharacterPrefapSO> CharacterDetail => _characterDetail;

}
