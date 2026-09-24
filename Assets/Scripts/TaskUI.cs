using TMPro;
using UnityEngine;

public class TaskUI : MonoBehaviour
{
    [SerializeField] private TMP_Text taskText;

    private void Update()
    {
        if (TaskManager.Instance == null)
        {
            Debug.Log("TaskManager NULL");
            return;
        }

        //Debug.Log(
        //"Quantidade de tarefas: " +
        //TaskManager.Instance.GetAllTasks().Count
        //);

        string taskDisplay = "Tarefas:\n\n";

        foreach (var task in TaskManager.Instance.GetAllTasks())
        {
            string status = task.IsCompleted ? "[X]" : "[ ]";

            taskDisplay += $"{status} {task.Title}\n";
        }

        taskText.text = taskDisplay;

        //if (TaskManager.Instance.AreAllTasksCompleted())
        //{
        //    Debug.Log("Todas as tarefas concluídas");
        //}


    }

}