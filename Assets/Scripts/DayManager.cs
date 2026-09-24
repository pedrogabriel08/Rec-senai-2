using System.Collections;
using TMPro;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance;

    [Header("Dia Atual")]
    public int CurrentDay { get; private set; } = 1;

    [Header("UI")]
    [SerializeField] private TMP_Text dayText;

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
        StartCoroutine(ShowDay(CurrentDay));
    }

    public void NextDay()
    {
        CurrentDay++;

        Debug.Log($"Dia {CurrentDay}");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.GenerateRandomTasks(3);
        }

        StartCoroutine(ShowDay(CurrentDay));
    }

    private IEnumerator ShowDay(int day)
    {
        if (dayText == null)
        {
            Debug.LogWarning("Day Text não foi atribuído!");
            yield break;
        }

        dayText.gameObject.SetActive(true);

        dayText.text = $"DIA {day}";

        yield return new WaitForSeconds(3f);

        dayText.gameObject.SetActive(false);
    }
}