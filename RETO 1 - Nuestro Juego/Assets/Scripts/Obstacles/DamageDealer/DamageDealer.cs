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
    private Player2D targetPlayer;
    private Rigidbody playerRB;

    private bool canDamage = true;

    // It runs once before the first Update it's executed
    void Start()
    {
        Debug.Log("[Elevator] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the AudioController of the Scene
    }

    // Update is executed once per frame
    void Update()
    {

    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && canDamage) // Check that the collided object has the "Player" label
        {
            targetPlayer = collision.transform.GetComponent<Player2D>();
            
            StartCoroutine(ApplyKnockback());

            if(!targetPlayer.isFrozen)
            {
                targetPlayer.isFrozen = true;
                targetPlayer.ApplyDamage(); // Deals damage
            }
        }
    }

    // Knockback
    private IEnumerator ApplyKnockback()
    {
        canDamage = false;
        gameManager.Freeze(true);
        gameManager.ApplyDamage();

        float horizontalDirection = Mathf.Sign(targetPlayer.transform.position.x - transform.position.x);

        Vector3 knockback = new Vector3(horizontalDirection * horizontalForce, upwardForce, 0f);

        playerRB.AddForce(knockback, ForceMode.Impulse);

        yield return new WaitForSeconds(knockbackDuration);

        gameManager.Freeze(false);

        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
}