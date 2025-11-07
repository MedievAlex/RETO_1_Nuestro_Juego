using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

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
    [Header("Abilities")] // Makes a header on the public variables
    public int lifeCount; // Life points
    public bool activeDash = false; // Active or desactive the dash ability
    public bool activeJump = false; // Active or desactive the dash ability
    public bool activeExtraJumps = false; // Active or desactive the dash ability

    [Header("States")] // Makes a header on the public variables
    public bool isFrozen = false;

    // Not visible variables
    private UIController uiController;
    private AudioController audioController;

    private Rigidbody rb; // Referencia al Rigidbody
    private Animator animator; // Reference to the animator

    private Vector3 spawnPoint; // Referencia al punto de reaparición
    private float baseSpeed = 5f; // Base movement speed
    private float speed; // Actual speed
    private float jumpForce = 6f; // Jump force
    private int extraJumps = 2; // Extra jumps
    private int jumpsLeft; // Remaining extra jumps
    private bool jumpsReset = false; // To check if the counter had been reset   

    private bool walking = false;
    private bool running = false;
    private bool jumping = false;
    private bool ground;

    // START runs once before the first UPDATE it's executed
    void Start()
    {
        uiController = GameObject.Find("UI").GetComponent<UIController>(); // Finds the UIController of the Scene
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>(); // Finds the AudioController of the Scene

        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        animator = gameObject.GetComponent<Animator>(); // Get the Animator component

        lifeCount = uiController.getLife(); // Get the life points
        uiController.setLife(lifeCount); // Sets the life points in the UI

        spawnPoint = transform.position; // Save the initial position
    }

    // UPDATE is executed once per frame
    void Update()
    {

        if (!isFrozen)
        {
            animationControl();
            audioControl();

            // Movement
            if (Input.GetAxis("Horizontal") != 0)
            {
                walking = true;

                // Sideways movement
                float moveLeftRight = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
                transform.Translate(moveLeftRight, 0, 0); // X, Y, Z

                // Dash
                if (Input.GetKey(KeyCode.LeftShift) && activeDash)
                {
                    running = true;

                    speed = baseSpeed * 1.7f;
                }
                else
                {
                    running = false;

                    speed = baseSpeed;
                }

                if (Input.GetAxis("Horizontal") < 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }
            else
            {
                walking = false;
                running = false;
            }

            // Jump
            if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0 && activeJump) // If it has jumps left and it has 
            {
                jumping = true;
                audioController.playerEfects("JUMP");

                if (jumpsLeft == extraJumps && activeJump) // The first jump is 100% of the strength
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                }
                else if (jumpsLeft < extraJumps && activeExtraJumps) // Extra jumps are 7% of the strength
                {
                    rb.AddForce(Vector3.up * (jumpForce * 0.7f), ForceMode.Impulse);
                }
                jumpsReset = false;
                jumpsLeft--;
            }
        }

        // Game Over
        if (lifeCount == 0)
        {
            uiController.GameOver();
        }
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Static")) // Check that the collided object will restart the jumps
        {
            jumping = false;

            if (!jumpsReset)
            {
                jumpsLeft = extraJumps; // Resets the jump counter
                jumpsReset = true;
            }

            if (isFrozen)
            {
                isFrozen = false;
            }
        }
    }

    // Executed when a collision is happening
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Static")) // Check that the collided object will restart the jumps
        {
            ground = true;
            jumping = false;
        }
    }

    // Executed when a collision ends
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Static")) // Check that the collided object will restart the jumps
        {
            ground = false;
            jumping = true;
        }
    }

    // Executed when a collision with a trigger occurs
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("LevelEnd")) // Check that the collided object has the "CheckPoint" label
        {
            uiController.saveLife(lifeCount);
        }
    }



    // Respawn methods
    public void applyDamage() // Deals damage
    {
        jumping = false;

        audioController.playerEfects("DAMAGE");
        lifeCount--;
        uiController.setLife(lifeCount);
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

    // Ability gestion
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
                uiController.setLife(lifeCount);
                break;
        }
    }

    // Animation and sound controller
    private void animationControl()
    {
        // Walking
        animator.SetBool("walking", walking);

        // Running
        animator.SetBool("running", running);

        // Jumping
        animator.SetBool("jumping", jumping);
    }

    private void audioControl()
    {
        if (walking && ground)
        {
            if (running)
            {
                audioController.playerAudio(GetComponent<AudioSource>(), "RUN", true);
            }
            else
            {
                audioController.playerAudio(GetComponent<AudioSource>(), "WALK", true);
            }
        }
        else if (!walking || jumping || !ground)
        {
            audioController.playerAudio(GetComponent<AudioSource>(), "WALK", false);
            audioController.playerAudio(GetComponent<AudioSource>(), "RUN", false);
        }
    }
}