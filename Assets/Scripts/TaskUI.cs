private void Update()
{
    if (TaskManager.Instance == null)
    {
        Debug.LogError("TaskManager está NULL!");
        return;
    }

    if (taskText == null)
    {
        Debug.LogError("TaskText está NULL!");
        return;
    }

    string taskDisplay = "Tarefas:\n\n";

    foreach (var task in TaskManager.Instance.GetAllTasks())
    {
        string status = task.IsCompleted ? "[X]" : "[ ]";

        taskDisplay += $"{status} {task.Title}\n";
    }

    taskText.text = taskDisplay;
}