using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Actor", menuName = "Character/Create Actor")]
public class CharacterSO : ScriptableObject
{
    [SerializeField] private List<CharacterDetail> _characterDetail;

    public List<CharacterDetail> CharacterDetail => _characterDetail;

}
