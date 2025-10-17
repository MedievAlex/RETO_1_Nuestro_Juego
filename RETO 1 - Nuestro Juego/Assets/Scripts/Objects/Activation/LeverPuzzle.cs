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

    // START runs once before the first Update it's executed
    void Start()
    {
        resetPuzzle();
        targetPlayer = GameObject.Find("Player2D").GetComponent<PlayerControl2D>(); // Finds the GameObject of the class PlayerControl2D
    }

    // UPDATE is executed once per frame
    void Update()
    {
        if (testLever.stateActive)
        {
            if (lever1.stateActive || lever2.stateActive || lever3.stateActive || lever4.stateActive) // Correct combination
            {

            }
            else // Incorrect combination
            {
                remainingAttempts--;
                resetPuzzle();
                if (remainingAttempts == 0)
                {
                    targetPlayer.applyDamage();
                }
            }
        }  
    }

    // Resets the puzzle values
    private void resetPuzzle()
    {
        testLever.stateActive = false;
        remainingAttempts = attempts;
        lever1.stateActive = randomState();
        lever2.stateActive = randomState();
        lever3.stateActive = randomState();
        lever4.stateActive = randomState();
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