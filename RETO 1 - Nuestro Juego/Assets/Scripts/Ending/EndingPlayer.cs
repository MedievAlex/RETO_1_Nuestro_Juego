using UnityEngine;

public class EndingPlayer : MonoBehaviour
{
    // Not visible variables
    private GameManager gameManager;
    private AudioSource audioSource; // Reference to the Audio Source
    private Animator animator; // Reference to the animator

    private bool creditsEnd = false;
    private bool walking = true;
    private bool running = false;

    private float timePassed;
    private float stopTime = 3f;

    private Vector3 walkDestination;
    private Vector3 runDestination;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("[Player] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the GameManager of the Scene

        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
        animator = gameObject.GetComponent<Animator>(); // Get the Animator component

        walkDestination = new Vector3(-51f, transform.position.y, 0f);
        runDestination = new Vector3(-36.34f, 35f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        AnimationControl();
        AudioControl();

        if (walking)
        {
            transform.position = Vector3.MoveTowards(transform.position, walkDestination, 5f * Time.deltaTime);
        }

        if (transform.position == walkDestination)
        {
            walking = false;
            GetComponent<SpriteRenderer>().flipX = true;
            creditsEnd = true;
        }

        if (creditsEnd)
        {
            timePassed += Time.deltaTime; // Calculates the time
            if (timePassed > stopTime) // Creates a new object and restarts the counter
            {
                walking = true;
                GetComponent<SpriteRenderer>().flipX = false;
                running = true; 
            }
        }

        if (walking && running)
        {
            transform.position = Vector3.MoveTowards(transform.position, runDestination, (5f * 1.7f) * Time.deltaTime);
        }

        if (transform.position == runDestination)
        {
            gameManager.ReturnToMainMenu(true);
        }
    }

    // Animation and sound controller
    private void AnimationControl()
    {
        // Walking
        animator.SetBool("walking", walking);

        // Running
        animator.SetBool("running", running);
    }

    private void AudioControl()
    {
        if (walking)
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
        else if (!walking)
        {
            gameManager.PlayerAudio(audioSource, "WALK", false);
            gameManager.PlayerAudio(audioSource, "RUN", false);
        }
    }
}
