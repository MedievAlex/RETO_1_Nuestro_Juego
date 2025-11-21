using UnityEngine;

public class Player2D : MonoBehaviour
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
    private GameManager gameManager;

    private Rigidbody playerRB; // Reference to the Rigidbody
    private AudioSource audioSource; // Reference to the Audio Source
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
        Debug.Log("[Player] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the GameManager of the Scene
        gameManager.SetPlayer(this);

        playerRB = GetComponent<Rigidbody>(); // Get the Rigidbody component
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
        animator = gameObject.GetComponent<Animator>(); // Get the Animator component

        lifeCount = gameManager.GetLives(); // Get the life points
        gameManager.UpdateLives(lifeCount); // Sets the life points in the UI

        spawnPoint = transform.position; // Save the initial position
    }

    // UPDATE is executed once per frame
    void Update()
    {
        AnimationControl();
        AudioControl();

        if (!isFrozen)
        {
            // Movement
            if (Input.GetAxis("Horizontal") != 0)
            {
                LeftRightMovement();
                /*
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
                */
            }
            else
            {
                walking = false;
                running = false;
            }

            // Jump
            if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0 && activeJump) // If it has jumps left and it has 
            {
                JumpMovement();
                /*
                jumping = true;
                gameManager.PlayerEffects("JUMP");

                if (jumpsLeft == extraJumps && activeJump) // The first jump is 100% of the strength
                {
                    playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                }
                else if (jumpsLeft < extraJumps && activeExtraJumps) // Extra jumps are 7% of the strength
                {
                    playerRB.AddForce(Vector3.up * (jumpForce * 0.7f), ForceMode.Impulse);
                }
                jumpsReset = false;
                jumpsLeft--;
                */
            }
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
                Freeze(false);
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
            walking = false;
            jumping = true;
        }
    }

    // Executed when a collision with a trigger occurs
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("LevelEnd")) // Check that the collided object has the "CheckPoint" label
        {
            gameManager.SaveLives(lifeCount);
        }
    }

    // Movement control
    public void LeftRightMovement()
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

    // Jump control
    public void JumpMovement()
    {
        if(jumpsLeft > 0 && activeJump)
        {
            jumping = true;
            gameManager.PlayerEffects("JUMP");

            if (jumpsLeft == extraJumps && activeJump) // The first jump is 100% of the strength
            {
                playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else if (jumpsLeft < extraJumps && activeExtraJumps) // Extra jumps are 7% of the strength
            {
                playerRB.AddForce(Vector3.up * (jumpForce * 0.7f), ForceMode.Impulse);
            }
            jumpsReset = false;
            jumpsLeft--;
        }
    }

    public void DashMovement(bool dashing)
    {
 
    }

    // Deals damage
    public void ApplyDamage()
    {
        if (!isFrozen)
        {
            playerRB.linearVelocity = Vector3.zero;
            playerRB.angularVelocity = Vector3.zero;

            jumping = false;

            gameManager.PlayerEffects("DAMAGE");
            lifeCount--;
            gameManager.UpdateLives(lifeCount);
            gameManager.ShowDamageBorder(true, 0.5f);
        }
    }

    // Changes the state of frozen
    public bool FrozenState()
    {
        return isFrozen;
    }

    // Changes the state of frozen
    public void Freeze(bool frozen)
    {
        isFrozen = frozen;
    }

    public Rigidbody GetRigidbody()
    {
        return playerRB;
    }

    // Sets new respawn point
    public void SetRespawn(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }

    // Gets the actual respawn point
    public Vector3 GetRespawn()
    {
        return spawnPoint;
    }

    // Respawns in the registered spawnpoint
    public void Respawn()
    {
        playerRB.linearVelocity = Vector3.zero;
        playerRB.angularVelocity = Vector3.zero;
        transform.position = spawnPoint;
    }

    // Ability gestion
    public void AbilityGestion(string abilityName, bool active)
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
                gameManager.UpdateLives(lifeCount);
                break;
            default:
                break;
        }
    }

    // Animation and sound controller
    private void AnimationControl()
    {
        // Walking
        animator.SetBool("walking", walking);

        // Running
        animator.SetBool("running", running);

        // Jumping
        animator.SetBool("jumping", jumping);
    }

    private void AudioControl()
    {
        if (walking && ground)
        {
            if (running)
            {
                gameManager.PlayerAudio(audioSource, "RUN", true);
            }
            else
            {
                gameManager.PlayerAudio(audioSource, "WALK", true);
            }
        }
        else if (!walking || jumping || !ground)
        {
            gameManager.PlayerAudio(audioSource, "WALK", false);
            gameManager.PlayerAudio(audioSource, "RUN", false);
        }
    }
}