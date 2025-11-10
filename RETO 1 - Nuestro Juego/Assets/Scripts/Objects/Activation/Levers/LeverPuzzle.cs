using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;

    [Header("Door")] // Makes a header on the public variables
    public Door door; // Referenced door

    [Header("Levers")] // Makes a header on the public variables
    public Lever lever1; // Referenced lever
    public Lever lever2; // Referenced lever
    public Lever lever3; // Referenced lever
    public Lever lever4; // Referenced lever
    public Lever testLever; // Referenced lever

    [Header("Attemps")] // Makes a header on the public variables
    public int attempts; // Attempts to complete the puzzle

    // Not visible variables  
    private int remainingAttempts; // Remaining extra attempts
    private float checkTime = 1;
    private float timePassed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("[LeverPuzzle] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the AudioController of the Sceneent

        remainingAttempts = attempts;
        resetPuzzle();
    }

    // UPDATE is executed once per frame
    void Update()
    {
        if (testLever.GetState())
        {
            if (verifyPuzzle()) // Correct combination
            { 
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
                timePassed += Time.deltaTime; // Calculates the time
                if (timePassed > checkTime) // Creates a new object and restarts the counter
                {
                    remainingAttempts--;
                    Debug.Log("[LeverPuzzle] Incorrect combination. " + remainingAttempts + " attemps left.");
                    testLever.SetState(false);
                    resetPuzzle();
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

    // Resets the puzzle values
    private bool verifyPuzzle()
    {
        if(lever1.stateActive && !lever2.stateActive && !lever3.stateActive && !lever4.stateActive){ 
            return true;
        }
        else
        { 
            return false;
        }
    }

    // Resets the puzzle values
    private void resetPuzzle()
    {
        testLever.SetState(false);         
        do
        {     
            lever1.stateActive = randomState();
            lever2.stateActive = randomState();
            lever3.stateActive = randomState();
            lever4.stateActive = randomState();
        }
        while(lever1.stateActive && !lever2.stateActive && !lever3.stateActive && !lever4.stateActive); 
    }

    // Generate a random boolean state
    private bool randomState()
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
}