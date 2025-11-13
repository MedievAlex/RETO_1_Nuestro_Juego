using UnityEngine;

public class EndingCamera : MonoBehaviour
{
    // Not visible variables
    private EndingPlayer targetPlayer;
    private Vector3 cameraPosition;
    private bool followPlayer = true;

    private void Awake()
    {
        cameraPosition = new Vector3(0.2f, 1f, -4f);
    }

    void Start()
    {
        targetPlayer = GameObject.Find("Player2D").GetComponent<EndingPlayer>();
    }
    
    private void Update()
    {
        if(followPlayer)
        {
            transform.position = targetPlayer.transform.position + (cameraPosition * 2); // * 2 because somehow the camera appears in the half
        }

        if(targetPlayer.transform.position == new Vector3(-51f, targetPlayer.transform.position.y, 0f))
        {
            followPlayer = false;
        }
    }
}
