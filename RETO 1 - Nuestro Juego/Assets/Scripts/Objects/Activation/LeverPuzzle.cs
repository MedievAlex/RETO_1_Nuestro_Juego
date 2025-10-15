using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    // Visible variables
    public PlayerControl2D targetPlayer;
    public Lever lever1; // Referenced lever
    public Lever lever2; // Referenced lever
    public Lever lever3; // Referenced lever
    public Lever lever4; // Referenced lever
    public Lever testLever; // Referenced lever
    public int attempts; // Attempts to complete the puzzle

    // Not visible variables  
    private int remainingAttempts; // Remaining extra attempts

    // START runs once before the first Update it's executed
    void Start()
    {
        resetPuzzle();
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
                    dealDamage();
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

    // Deals damage to the player
    private void dealDamage()
    {
        targetPlayer.getRigidbody().linearVelocity = Vector3.zero; // Stop it from moving
        targetPlayer.getRigidbody().angularVelocity = Vector3.zero; // Reset the physical rotation
        targetPlayer.transform.position = targetPlayer.getRespawn(); // Respawn at the saved point
    }
}