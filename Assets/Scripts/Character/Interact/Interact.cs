using UnityEngine;

public class Interact
{
    public InteractType type;
    public GameObject interactableObject;

    public Interact(InteractType t, GameObject obj)
    {
        type = t;
        interactableObject = obj;
    }
}