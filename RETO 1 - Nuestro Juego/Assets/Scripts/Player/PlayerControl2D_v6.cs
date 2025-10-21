using System;
using UnityEngine;
using UnityEngine.UI;

/** [ 2D MOVEMENT CONTROLS V.6 ]
- Movement: Left and right
- Jump: Single jump
- Double jump: As many jumps as indicated
- Respawn: Respawn at the first point
- Checkpoints: Stores the location of checkpoints to respawn there
- Dash: Holding Left Shift will double movement speed
*/
public class PlayerControl2D : MonoBehaviour
{
    // Visible variables 
    public int lifeCount = 3; // Life points
    public bool activeDash = false; // Active or desactive the dash ability
    public bool activeJump = false; // Active or desactive the dash ability
    public bool activeExtraJumps = false; // Active or desactive the dash ability

    // Not visible variables
    private Rigidbody rb; // Referencia al Rigidbody
    private Vector3 spawnPoint; // Referencia al punto de reaparición
    private float baseSpeed = 5f; // Base movement speed
    private float speed; // Actual speed
    private float jumpForce = 6f; // Jump force
    private int extraJumps = 2; // Extra jumps
    private int jumpsLeft; // Remaining extra jumps
    private bool jumpsReset = false; // To check if the counter had been reset   

    // START runs once before the first UPDATE it's executed
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        spawnPoint = transform.position; // Save the initial position
    }

    // UPDATE is executed once per frame
    void Update()
    {
        // Movement
        if (Input.GetAxis("Horizontal") != 0)
        {
            // Sideways movement
            float moveLeftRight = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(moveLeftRight, 0, 0); // X, Y, Z

            // Dash
            if (Input.GetKey(KeyCode.LeftShift) && activeDash) 
            {
                speed = baseSpeed * 1.7f;
            }
            else
            {
                speed = baseSpeed;
            }
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0 && activeJump) // If it has jumps left and it has 
        {     
            if (jumpsLeft == extraJumps && activeJump) // The first jump is 100% of the strength
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else if (jumpsLeft < extraJumps && activeExtraJumps) // Extra jumps are 7% of the strength
            {
                rb.AddForce(Vector3.up * (jumpForce * 0.7f ), ForceMode.Impulse);
            }
            jumpsReset = false;
            jumpsLeft--;
        }  

        // Game Over
        if (lifeCount == 0)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Static") && !jumpsReset) // Check that the collided object will restart the jumps
        {
            jumpsLeft = extraJumps; // Resets the jump counter
            jumpsReset = true;
        }
    }

    // Executed when a collision with a trigger occurs
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("CheckPoint")) // Check that the collided object has the "CheckPoint" label
        {
            spawnPoint = transform.position; // Saves the checkpoint position
            Destroy(collider.gameObject); // Destroys the checkpoint
        }
    }

    // Respawn methods
    public void applyDamage() // Deals damage
    {
        lifeCount--;
    }
    public void setRespawn(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
    public Vector3 getRespawn()
    {
        return spawnPoint;
    }
    public Rigidbody getRigidbody()
    {
        return rb;
    }

    // Ability methods
    public void abilityGestion(string abilityName, bool active)
    {
        switch (abilityName.ToUpper())
        {
            case "DASH":
                activeDash = active;
                break;
            case "JUMP":
                activeJump = active;
                break;
            case "EXTRAJUMPS":
                activeExtraJumps = active;
                break;
            case "ADDEXTRAJUMP":
                extraJumps++;
                break;
            case "ADDLIFE":
                lifeCount++;
                break;
        }
    }
}