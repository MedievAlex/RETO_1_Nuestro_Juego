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
    public Vector3 tPuzzle;

    private bool testMode = false;

    void Start()
    {
        level = gameManager.GetLevel();

        tDamageDealers = new Vector3(-3f, 14f, 0f);
        yCheckpoint = new Vector3(20f, 18f, 0f);
        uElevator = new Vector3(35f, 20f, 0f);

        tPlatforms = new Vector3(-38f, 15f, 0f);
        yEnd = new Vector3(56.5f, 25f, 0f);

        tPuzzle = new Vector3(-3f, 5f, 0f);
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

            if (Input.GetKeyDown(KeyCode.T))
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
                    player.transform.position = tPuzzle;
                }
            }

            if (Input.GetKeyDown(KeyCode.Y))
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

                }
            }

            if (Input.GetKeyDown(KeyCode.U))
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
