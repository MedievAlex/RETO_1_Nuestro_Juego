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

    [Header("Key locations Level-3")]
    public Vector3 tPuzzle;

    private bool testMode = false;

    void Start()
    {
        tDamageDealers = new Vector3(-3f, 14f, 0f);
        yCheckpoint = new Vector3(20f, 18f, 0f);
        uElevator = new Vector3(35f, 20f, 0f);

        tPlatforms = new Vector3(20f, 18f, 0f);
        tPuzzle = new Vector3(35f, 20f, 0f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.T) && Input.GetKey(KeyCode.M))
        {
            testMode = true;
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

            if (Input.GetKeyDown(KeyCode.G))
            {
                timerController.AddTime();
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                gameManager.AbilityGestion("ADDLIFE", true);
            }

            if (Input.GetKeyDown(KeyCode.J))
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
