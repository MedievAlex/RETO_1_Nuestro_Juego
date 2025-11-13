using UnityEngine;

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

    void Start()
    {     
        targetPlayer = GameObject.Find("Player2D").GetComponent<Player2D>(); // Finds the GameObject of the class PlayerControl2D
    }
    private void Update()
    {
        transform.position = targetPlayer.transform.position + (cameraPosition * 2); // * 2 because somehow the camera appears in the half  
    }
}