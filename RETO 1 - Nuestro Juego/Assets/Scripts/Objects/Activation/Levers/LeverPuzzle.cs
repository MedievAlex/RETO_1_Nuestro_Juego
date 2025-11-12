using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;

    [Header("Door")] // Makes a header on the public variables
    public Door door; // Referenced door

    [Header("Levers")] // Makes a header on the public variables
    public Lever testLever; // Referenced lever
    public Lever lever1; // Referenced lever
    public Lever lever2; // Referenced lever
    public Lever lever3; // Referenced lever
    public Lever lever4; // Referenced lever

    [Header("Ligth")] // Makes a header on the public variables
    public Sprite redLight;
    public Sprite yellowLight;
    public Sprite greenLight;

    [Header("Attemps")] // Makes a header on the public variables
    public int attempts; // Attempts to complete the puzzle

    // Not visible variables  
    private List<Lever> levers = new List<Lever>();
    private List<SpriteRenderer> lamps = new List<SpriteRenderer>();
    private int remainingAttempts; // Remaining extra attempts
    private bool blocked = false;
    private float checkTime = 1;
    private float timePassed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("[LeverPuzzle] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the AudioController of the Sceneent

        remainingAttempts = attempts;

        GetLamps();
        ResetPuzzle();
    }

    // UPDATE is executed once per frame
    void Update()
    {
        SetLamp();

        if (!blocked)
        {
            if (testLever.GetState())
            {
                if (VerifyPuzzle()) // Correct combination
                {
                    SetTestLight("GREEN");
                    blocked = true;
                    timePassed += Time.deltaTime; // Calculates the time
                    if (timePassed > checkTime) // Creates a new object and restarts the counter
                    {
                        Debug.Log("[LeverPuzzle] Correct combination.");
                        door.changeState();
                        testLever.SetState(false);
                        timePassed = 0f;
                    }
                }
                else // Incorrect combination
                {
                    SetTestLight("RED");
                    timePassed += Time.deltaTime; // Calculates the time
                    if (timePassed > checkTime) // Creates a new object and restarts the counter
                    {
                        remainingAttempts--;
                        Debug.Log("[LeverPuzzle] Incorrect combination. " + remainingAttempts + " attemps left.");
                        testLever.SetState(false);
                        ResetPuzzle();
                        if (remainingAttempts == 0)
                        {
                            gameManager.ApplyDamage();
                            remainingAttempts = attempts;
                        }
                        timePassed = 0f;
                    }
                }
            }
        }

    }

    // Gets each Lever Lamp and it's light
    private void GetLamps()
    {
        levers.Add(testLever);
        levers.Add(lever1);
        levers.Add(lever2);
        levers.Add(lever3);
        levers.Add(lever4);

        foreach (Lever lever in levers)
        {
            lamps.Add(lever.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>());
        }
    }

    // Resets the puzzle values
    private bool VerifyPuzzle()
    {
        if (lever1.stateActive && !lever2.stateActive && !lever3.stateActive && !lever4.stateActive)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Resets the puzzle values
    private void ResetPuzzle()
    {
        testLever.SetState(false);
        SetTestLight("YELLOW");
        do
        {
            lever1.stateActive = RandomState();
            lever2.stateActive = RandomState();
            lever3.stateActive = RandomState();
            lever4.stateActive = RandomState();
        }
        while (lever1.stateActive && !lever2.stateActive && !lever3.stateActive && !lever4.stateActive);
    }

    // Generate a random boolean state
    private bool RandomState()
    {
        if (Random.Range(0, 2) == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    // Sets Lamps Light color
    private void SetTestLight(string light)
    {
        switch (light.ToUpper())
        {
            case "RED":
                lamps[0].sprite = redLight;
                break;
            case "YELLOW":
                lamps[0].sprite = yellowLight;
                break;
            case "GREEN":
                lamps[0].sprite = greenLight;
                break;
        }
    }

    // Sets Lamps Light color
    private void SetLamp()
    {
        for (int i = 1; i < levers.Count; i++)
        {
            lamps[i].sprite = SetLigth(levers[i].stateActive);
        }
    }

    private Sprite SetLigth(bool active)
    {
        if (active)
        {
            return greenLight;
        }
        else
        {
            return redLight;
        }
    }
}