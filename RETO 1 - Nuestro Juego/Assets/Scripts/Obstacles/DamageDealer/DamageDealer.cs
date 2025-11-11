using UnityEngine;
using System.Collections;

public class DamageDealer : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;  

    // Not visible variables
    private float horizontalForce = 3f;
    private float upwardForce = 5f;
    private float knockbackDuration = 0.3f;

    // It runs once before the first Update it's executed
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the GameManager of the Scene
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            StartCoroutine(ApplyKnockback(collision));

            if (!gameManager.FrozenState())
            {
                gameManager.ApplyDamage();
                gameManager.Freeze(true); 
            }
        }
    }

    // Knockback
    private IEnumerator ApplyKnockback(Collision collision)
    {
        float horizontalDirection = Mathf.Sign(collision.transform.position.x - transform.position.x);

        Vector3 knockback = new Vector3(horizontalDirection * horizontalForce, upwardForce, 0f);

        collision.transform.GetComponent<Rigidbody>().AddForce(knockback, ForceMode.Impulse);
        yield return new WaitForSeconds(knockbackDuration);
    }
}