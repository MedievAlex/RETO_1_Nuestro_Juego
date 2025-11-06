using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    // Visible variables
    public TextMeshProUGUI timer;

    // Not visible variables
    private bool pause;
    private float timePassed;
    private string minutes;
    private string seconds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = timeFormat();
    }

    private string timeFormat()
    {
        if (!pause)
        {
            timePassed += Time.deltaTime;
        }

        minutes = Mathf.Floor(timePassed / 60).ToString("00");
        seconds = Mathf.Floor(timePassed % 60).ToString("00");

        return minutes + ":" + seconds;
    }

    // To stop the cronometer
    public void setPause(bool pause)
    {
        this.pause = pause;
    }

    // To reset the time
    public void resetTime()
    {
        setPause(true);
        timePassed = 0;
    }
}
