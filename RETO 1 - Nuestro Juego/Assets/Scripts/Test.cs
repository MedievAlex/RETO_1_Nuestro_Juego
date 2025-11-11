using UnityEngine;

public class Test : MonoBehaviour
{
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;

    [Header("Player")]
    public Player2D player;

    [Header("Level")]
    public int level;

    [Header("Key locations Level-1")]
    public Vector3 tDamageDealers;
    public Vector3 yCheckpoint;
    public Vector3 uElevator;

    [Header("Key locations Level-2")]
    public Vector3 tPlatforms;

    [Header("Key locations Level-3")]
    public Vector3 tPuzzle;

    private bool testMode = false;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the AudioController of the Scene

        tDamageDealers = new Vector3(-3f, 14f, 0f);
        yCheckpoint = new Vector3(20f, 18f, 0f);
        uElevator = new Vector3(35f, 20f, 0f);

        tPlatforms = new Vector3(20f, 18f, 0f);
        tPuzzle = new Vector3(35f, 20f, 0f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.T))
        {
            testMode = !testMode;
            SetPlayer();
        }

        if (testMode)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                level = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                level = 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                level = 3;
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                gameManager.AbilityGestion("ADDLIFE", true);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                gameManager.ApplyDamage();
            }

            if (level == 1)
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    player.transform.position = tDamageDealers;
                }

                if (Input.GetKeyDown(KeyCode.Y))
                {
                    player.transform.position = yCheckpoint;
                }

                if (Input.GetKeyDown(KeyCode.U))
                {
                    player.transform.position = uElevator;
                }
            }

            if (level == 2)
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    player.transform.position = tPlatforms;
                }
            }

            if (level == 3)
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    player.transform.position = tPuzzle;
                }
            }
        }
    }

    private void SetPlayer()
    {
        if (gameManager.player != null)
        {
            player = gameManager.player;

            gameManager.AbilityGestion("DASH", true);
            gameManager.AbilityGestion("JUMP", true);
            gameManager.AbilityGestion("EXTRAJUMPS", true);
        }
    }
}
