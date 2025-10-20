using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    // Visible variables
    public Lever lever1; // Referenced lever
    public Lever lever2; // Referenced lever
    public Lever lever3; // Referenced lever
    public Lever lever4; // Referenced lever
    public Lever testLever; // Referenced lever
    public int attempts; // Attempts to complete the puzzle

    // Not visible variables  
    private PlayerControl2D targetPlayer;
    private int remainingAttempts; // Remaining extra attempts
    private float checkTime = 1;
    private float timePassed;

    // START runs once before the first Update it's executed
    void Start()
    {
        targetPlayer = GameObject.Find("Player2D").GetComponent<PlayerControl2D>(); // Finds the GameObject of the class PlayerControl2D    
        remainingAttempts = attempts;
        resetPuzzle();
    }

    // UPDATE is executed once per frame
    void Update()
    {
        if (testLever.stateActive)
        {
            if (verifyPuzzle()) // Correct combination
            { 
                timePassed += Time.deltaTime; // Calculates the time
                if (timePassed > checkTime) // Creates a new object and restarts the counter
                {
                    Debug.Log("Correct convination.");
                    testLever.stateActive = false;
                    timePassed = 0f;
                }
            }
            else // Incorrect combination
            {
                timePassed += Time.deltaTime; // Calculates the time
                if (timePassed > checkTime) // Creates a new object and restarts the counter
                {
                    remainingAttempts--;
                    Debug.LogError(remainingAttempts + " attemps left.");
                    testLever.stateActive = false;
                    resetPuzzle();
                    if (remainingAttempts == 0)
                    {    
                        Debug.LogWarning("Knockback missing.");
                        targetPlayer.applyDamage();
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
        testLever.stateActive = false;         
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