using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Choice", menuName = "Create Choice")]
public class ChoiceSO : ScriptableObject
{
    [SerializeField] List<ChoiceDetail> _choiceDetail;

    public List<ChoiceDetail> ChoiceDetail => _choiceDetail;
}
