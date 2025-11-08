using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCameraController : MonoBehaviour
{
    // Visible variables
    public Vector3 cameraPosition;

    // Not visible variables
    private Player2D targetPlayer;

    private void Awake()
    {
        Destroy(GameObject.Find("MainCamera")); // Destroys the main camera
    }

    // START runs once before the first UPDATE it's executed
    void Start()
    {     
        targetPlayer = GameObject.Find("Player2D").GetComponent<Player2D>(); // Finds the GameObject of the class PlayerControl2D
        transform.SetParent(targetPlayer.transform);
        gameObject.transform.position = targetPlayer.transform.position + (cameraPosition * 2); // * 2 because somehow the camera appears in the half  
    }

    // UPDATE is executed once per frame
    void Update()
    {
        
    }
}