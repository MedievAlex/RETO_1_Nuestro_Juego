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
    public int totalJumps = 2; // Extra jumps

    // Not visible variables
    private float baseSpeed = 5f; // Base movement speed
    private float speed; // Actual speed
    private float jumpForce = 5f; // Jump force
    private int jumpsLeft; // Remaining extra jumps
    private bool jumpsReset = false; // To check if the counter had been reset
    private Vector3 spawnPoint; // Referencia al punto de reaparición
    private Rigidbody rb; // Referencia al Rigidbody

    // START runs once before the first Update it's executed
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
            if (Input.GetKey(KeyCode.LeftShift)) 
            {
                speed = baseSpeed * 1.7f;
            }
            else
            {
                speed = baseSpeed;
            }
        }

        // Jump
        if (jumpsLeft > 0 && Input.GetKeyDown(KeyCode.Space))
        {     
            if (jumpsLeft == totalJumps) // The first jump is 100% of the strength
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else // Extra jumps are 70% of the strength
            {
                rb.AddForce(Vector3.up * (jumpForce * 0.7f ), ForceMode.Impulse);
            }
            jumpsReset = false;
            jumpsLeft--;
        }  
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Static") && !jumpsReset) // Check that the collided object will restart the jumps
        {
            jumpsLeft = totalJumps; // Resets the jump counter
            jumpsReset = true;
        }

        if (collision.gameObject.CompareTag("DeathPoint") || collision.gameObject.CompareTag("DamageDealer")) // Check that the collided object has the "DeathPoint" label
        {
             // Respawns in the saved point
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
}