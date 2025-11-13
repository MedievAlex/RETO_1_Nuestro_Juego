using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem.XR;

public class TimerController : MonoBehaviour
{
    // Visible variables
    [Header("Timer")] // Makes a header on the public variables
    public TextMeshProUGUI timer; // Text showing the numbers

    [Header("Time Limits")] // Makes a header on the public variables
    public bool customTime;
    public float timeLimit;
    public float alertLimit;

    // Not visible variables
    private UIController uiController;
    private AudioSource audioSource;
    private bool pause;
    private float timePassed;
    private string minutes;
    private string seconds;
    private float countdownLimit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("[HealthBar] Getting UI Controller.");
        uiController = transform.parent.GetComponentInParent<UIController>();

        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component

        if (!customTime)
        {
            timeLimit = 1800f;
            alertLimit = 1500f;
        }
        countdownLimit = (timeLimit - 60f); // Default = 1740f
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            timePassed += Time.deltaTime;
        }

        timer.text = TimeFormat();
        TimerStyle();
    }

    // Transforms float value to seconds and minutes giving it format
    private string TimeFormat()
    {
        minutes = Mathf.Floor(timePassed / 60).ToString("00");
        seconds = Mathf.Floor(timePassed % 60).ToString("00");

        return minutes + ":" + seconds;
    }

    // Color and Countdown control
    private void TimerStyle()
    {
        if (timePassed > alertLimit)
        {
            timer.color = Color.red; 
        }

        if (timePassed > countdownLimit)
        {
            uiController.CountdownAudio(audioSource);
            if (timePassed > timeLimit)
            {
                uiController.GameOver();
                timer.color = Color.white;
            }
        }
    }

    // Stop or play the timer
    public void PauseTimer(bool pause)
    {
        this.pause = pause;
    }

    // Reset the value of the timer to 0
    public void ResetTimer()
    {
        PauseTimer(false);
        timePassed = 0;
    }


    public void AddTime()
    {
        timePassed = timePassed + 60f;
    }
}
