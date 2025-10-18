using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    // Visible variables
    public string thisScene; // Next level name
    public string nextScene; // Next level name
    public Vector3 nextSpawn; // Next scene's spawn
    
    // START runs once before the first Update it's executed
    void Start()
    {
    
    }

    // UPDATE is executed once per frame
    void Update()
    {
        
    }

    // Executed when a collision with a trigger occurs
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && collider.transform.parent != null)
        {
            if (collider.gameObject.transform.parent.gameObject.CompareTag("Elevator")) // Check that the collided object has the "Player" label and its in the "Elevator"
            {
                collider.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero; // Stop it from moving
                collider.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // Reset the physical rotation
                collider.gameObject.transform.position = nextSpawn;
  
                SceneManager.LoadSceneAsync(nextScene);
                SceneManager.UnloadSceneAsync(thisScene);
            }
        }
    }
}