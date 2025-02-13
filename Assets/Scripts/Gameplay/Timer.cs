using UnityEngine;
using TMPro;  // Importer TextMeshPro biblioteket

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float elapsedTime;
    private bool isRunning = false;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    public void StartTimer()
    {
        elapsedTime = 0f;
        isRunning = true;
        Debug.Log("Timer Started!");
    }

    public void StopTimer()
    {
        isRunning = false;
        Debug.Log("Timer Stopped at: " + FormatTime(elapsedTime));
    }

    private void UpdateTimerUI()
    {
        timerText.text = FormatTime(elapsedTime);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}
