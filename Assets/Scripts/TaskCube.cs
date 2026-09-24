using UnityEngine;

public class TaskCube : MonoBehaviour
{
    [SerializeField] private Renderer cubeRenderer;

    private Interaçao interactionScript;

    private void Awake()
    {
        interactionScript = GetComponent<Interaçao>();
    }

    public void Configure(
        string taskID,
        string taskName,
        Color color)
    {
        interactionScript.SetTaskData(
            taskID,
            taskName
        );

        cubeRenderer.material.color = color;

        gameObject.SetActive(true);
    }

    public void DisableCube()
    {
        gameObject.SetActive(false);
    }
}