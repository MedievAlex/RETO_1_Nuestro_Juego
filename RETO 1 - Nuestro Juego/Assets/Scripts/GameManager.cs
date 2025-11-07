using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerControl2D player;
    private UIController uiController;
    private AudioController audioController;

    void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Payer2D").GetComponent<PlayerControl2D>(); // Finds the Player of the Scene
        uiController = GameObject.Find("UI").GetComponent<UIController>(); // Finds the UIController of the Scene
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>(); // Finds the AudioController of the Scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // ---------------------------------------------------------------------------[ UI: Health Bar ]---------------------------------------------------------------------------

    

    // ---------------------------------------------------------------------------[ UI: Timer ]---------------------------------------------------------------------------



    // ---------------------------------------------------------------------------[ AUDIO ]---------------------------------------------------------------------------
}
