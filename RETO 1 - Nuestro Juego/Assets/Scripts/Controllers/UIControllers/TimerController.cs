using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class TimerController : MonoBehaviour
{
    // Visible variables
    public TextMeshProUGUI timer; // Text showing the numbers

    // Not visible variables
    private UIController uiController;
    private bool pause;
    private float timePassed;
    private float damageTimer;
    private string minutes;
    private string seconds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("[HealthBar] Getting UI Controller.");
        uiController = transform.parent.GetComponentInParent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            timePassed += Time.deltaTime;
            damageTimer = timePassed;
        }

        timer.text = TimeFormat();

        if (damageTimer == 900f)
        {
            uiController.ApplyDamage();
            damageTimer = 0.0f;
        }
    }

    // Transforms float value to seconds and minutes giving it format
    private string TimeFormat()
    {
        minutes = Mathf.Floor(timePassed / 60).ToString("00");
        seconds = Mathf.Floor(timePassed % 60).ToString("00");

        return minutes + ":" + seconds;
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
}
