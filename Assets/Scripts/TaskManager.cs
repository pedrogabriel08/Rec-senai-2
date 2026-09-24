using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance { get; private set; }

    private List<Tarefinhas> tasks = new List<Tarefinhas>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddTask(Tarefinhas newTask)
    {
        if (tasks.Exists(task => task.TaskID == newTask.TaskID))
            return;

        tasks.Add(newTask);

        Debug.Log($"Task adicionada: {newTask.Title}");
    }

    public void CompleteTask(string taskId)
    {
        Tarefinhas task = tasks.Find(task => task.TaskID == taskId);

        if (task != null)
        {
            task.Complete();

            Debug.Log($"Task concluída: {task.Title}");
            Debug.Log($"Estado: {task.IsCompleted}");
        }
    }

    public bool IsTaskCompleted(string taskId)
    {
        Tarefinhas task = tasks.Find(task => task.TaskID == taskId);

        return task != null && task.IsCompleted;
    }

    public bool AreAllTasksCompleted()
    {
        return tasks.TrueForAll(task => task.IsCompleted);
    }

    public List<Tarefinhas> GetAllTasks()
    {
        return tasks;
    }

    public void ClearTasks()
    {
        tasks.Clear();
    }

 
}
