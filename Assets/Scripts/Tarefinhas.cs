using System;

[System.Serializable]
public class Tarefinhas
{
    public string TaskID;
    public string Title;
    public bool IsCompleted;

    public Action OnComplete;

    public Tarefinhas(string taskID, string title)
    {
        TaskID = taskID;
        Title = title;
        IsCompleted = false;
    }

    public void Complete()
    {
        if (IsCompleted)
            return;

        IsCompleted = true;

        OnComplete?.Invoke();
    }
}