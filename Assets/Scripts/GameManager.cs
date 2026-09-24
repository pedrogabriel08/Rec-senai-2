using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TaskCube[] taskCubes;

    [System.Serializable]
    private class TaskData
    {
        public string TaskID;
        public string Title;
        public Color Color;

        public TaskData(
            string taskID,
            string title,
            Color color)
        {
            TaskID = taskID;
            Title = title;
            Color = color;
        }
    }

    private List<TaskData> allTasks;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("GAME MANAGER INICIOU");

        CreateTaskPool();

        GenerateRandomTasks(3);
    }

    private void CreateTaskPool()
    {
        allTasks = new List<TaskData>()
        {
            new TaskData(
                "remedio",
                "Tomar Remédio",
                Color.red
            ),

            new TaskData(
                "cachorro",
                "Alimentar Cachorro",
                Color.green
            ),

            new TaskData(
                "louca",
                "Lavar Louça",
                Color.blue
            ),

            new TaskData(
                "lixo",
                "Tirar o Lixo",
                Color.yellow
            ),

            new TaskData(
                "banho",
                "Tomar Banho",
                Color.magenta
            ),

            new TaskData(
                "quarto",
                "Organizar Quarto",
                new Color(1f, 0.5f, 0f)
            ),

            new TaskData(
                "dentes",
                "Escovar os Dentes",
                Color.white
            )
        };
    }

    public void GenerateRandomTasks(int amount)
    {
        TaskManager.Instance.ClearTasks();

        foreach (var cube in taskCubes)
        {
            cube.DisableCube();
        }

        List<TaskData> availableTasks =
            new List<TaskData>(allTasks);

        for (int i = 0; i < amount; i++)
        {
            if (availableTasks.Count <= 0)
                break;

            int randomIndex =
                Random.Range(0, availableTasks.Count);

            TaskData selectedTask =
                availableTasks[randomIndex];

            TaskManager.Instance.AddTask(
                new Tarefinhas(
                    selectedTask.TaskID,
                    selectedTask.Title
                )
            );

            if (i < taskCubes.Length)
            {
                taskCubes[i].Configure(
                    selectedTask.TaskID,
                    selectedTask.Title,
                    selectedTask.Color
                );
            }

            availableTasks.RemoveAt(randomIndex);
        }
    }
}