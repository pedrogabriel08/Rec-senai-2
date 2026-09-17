using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        GenerateDay1Tasks();
    }

    private void GenerateDay1Tasks()
    {
        TaskManager.Instance.ClearTasks();

        TaskManager.Instance.AddTask(
            new Tarefinhas(
                "remedio",
                "Tomar Remédio"
            )
        );

        TaskManager.Instance.AddTask(
            new Tarefinhas(
                "cachorro",
                "Alimentar Cachorro"
            )
        );
    }
}