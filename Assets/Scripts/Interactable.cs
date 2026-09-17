using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string objectName;
    [SerializeField] private string taskID;
    [SerializeField] private string interactionText;

    public void Interact()
    {
        Debug.Log("Interagiu com: " + objectName + " (Tipo: " + interactionText + ")");
    }
}