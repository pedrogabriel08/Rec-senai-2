using UnityEngine;

public class Interaçao : MonoBehaviour
{
    private string taskID;
    private string interactionText;

    public string InteractionText => interactionText;

    public void SetTaskData(string id, string text)
    {
        taskID = id;
        interactionText = text;
    }

    public void Interact()
    {
        TaskManager.Instance.CompleteTask(taskID);

        Debug.Log("Task concluída: " + taskID);
    }
}