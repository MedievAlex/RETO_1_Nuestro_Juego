using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem.XR;

public class TimerController : MonoBehaviour
{
    // Visible variables
    public TextMeshProUGUI timer; // Text showing the numbers

    // Not visible variables
    private UIController uiController;
    private AudioSource audioSource;
    private bool pause;
    private float timePassed;
    private string minutes;
    private string seconds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("[HealthBar] Getting UI Controller.");
        uiController = transform.parent.GetComponentInParent<UIController>();

        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            timePassed += Time.deltaTime;
        }

        timer.text = TimeFormat();
        TimerColor();
    }

    // Transforms float value to seconds and minutes giving it format
    private string TimeFormat()
    {
        minutes = Mathf.Floor(timePassed / 60).ToString("00");
        seconds = Mathf.Floor(timePassed % 60).ToString("00");

        return minutes + ":" + seconds;
    }

    // Color and Countdown control
    private void TimerColor()
    {
        if (timePassed > 1500f)
        {
            timer.color = Color.red;
            if (timePassed > 1740f)
            {
                uiController.CountdownAudio(audioSource);
                if (timePassed > 1800f)
                {
                    uiController.GameOver();
                    timer.color = Color.white;
                }
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
