using UnityEngine;

public class BedInteraction : MonoBehaviour
{
    public void Interact()
    {
        if (TaskManager.Instance.AreAllTasksCompleted())
        {
            Debug.Log("Dormindo...");

            DayManager.Instance.NextDay();
        }
        else
        {
            Debug.Log("Ainda há tarefas para fazer.");
        }
    }

}