using UnityEngine;

public class TaskObject : MonoBehaviour
{
    [SerializeField] private string taskID;
    [SerializeField] private string interactionText;

    public string InteractionText => interactionText;

    public void Interact()
    {
        TaskManager.Instance.CompleteTask(taskID);
    }
}