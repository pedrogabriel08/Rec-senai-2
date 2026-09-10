using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string objectName;
    public InteractionType interactionType;

    public void Interact()
    {
        Debug.Log("Interagiu com: " + objectName + " (Tipo: " + interactionType + ")");
    }
}