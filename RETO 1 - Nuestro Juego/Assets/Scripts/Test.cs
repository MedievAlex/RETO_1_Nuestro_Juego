using UnityEngine;

public class Test : MonoBehaviour
{
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;
    public TimerController timerController;

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
    public Vector3 yEnd;

    [Header("Key locations Level-3")]
    public Vector3 tPastRocks;
    public Vector3 yPuzzle;

    private bool testMode = false;

    void Start()
    {
        level = gameManager.GetLevel();

        tDamageDealers = new Vector3(-3f, 14f, 0f);
        yCheckpoint = new Vector3(20f, 18f, 0f);
        uElevator = new Vector3(35f, 20f, 0f);

        tPlatforms = new Vector3(-38f, 15f, 0f);
        yEnd = new Vector3(56.5f, 25f, 0f);

        tPastRocks = new Vector3(-13f, 35.1f, 0f);
        yPuzzle = new Vector3(-3f, 3f, 0f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.T) && Input.GetKey(KeyCode.M))
        {
            testMode = true;
            level = gameManager.GetLevel();
        }

        if (testMode)
        {
            if (player == null)
            {
                SetPlayer();
            }

            if (Input.GetKeyDown(KeyCode.G)) // Adds 1 minute
            {
                timerController.AddTime();
            }

            if (Input.GetKeyDown(KeyCode.H)) // +1 heart
            {
                if(player.lifeCount < 5)
                {
                    gameManager.AbilityGestion("ADDLIFE", true);
                }    
            }

            if (Input.GetKeyDown(KeyCode.J)) // - 1 heart
            {
                if (player.lifeCount > 1)
                {
                    gameManager.ApplyDamage();
                }
            }

            if (Input.GetKey(KeyCode.K)) // Kills the player
            {
                for (int i = 0; i < player.lifeCount; i++)
                {
                    gameManager.ApplyDamage();
                }
            }

            if (Input.GetKeyDown(KeyCode.T)) // Moves towards the first key location
            {
                level = gameManager.GetLevel();

                if (level == 1)
                {
                    player.transform.position = tDamageDealers;
                }
                else if (level == 2)
                {
                    player.transform.position = tPlatforms;
                }
                else if (level == 3)
                {
                    player.transform.position = tPastRocks;
                }
            }

            if (Input.GetKeyDown(KeyCode.Y)) // Moves towards the second key location
            {
                level = gameManager.GetLevel();

                if (level == 1)
                {
                    player.transform.position = yCheckpoint;
                }
                else if (level == 2)
                {
                    player.transform.position = yEnd;
                }
                else if (level == 3)
                {
                    player.transform.position = yPuzzle;
                }
            }

            if (Input.GetKeyDown(KeyCode.U)) // Moves towards the third key location
            {
                level = gameManager.GetLevel();

                if (level == 1)
                {
                    player.transform.position = uElevator;
                }
                else if (level == 2)
                {

                }
                else if (level == 3)
                {

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
