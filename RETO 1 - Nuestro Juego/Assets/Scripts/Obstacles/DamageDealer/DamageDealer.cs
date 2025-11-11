using UnityEngine;
using System.Collections;

public class DamageDealer : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;  

    [Header("Knockback Settings")]
    public float horizontalForce = 3f;
    public float upwardForce = 5f;
    public float knockbackDuration = 0.3f;
    public float damageCooldown = 2f;

    // Not visible variables
    private bool canDamage = true;

    // It runs once before the first Update it's executed
    void Start()
    {
        Debug.Log("[Elevator] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the AudioController of the Scene
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
        yield return new WaitForSeconds(damageCooldown);
    }
}