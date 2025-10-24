using System.Collections;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Tunable values visible in the Inspector
    [Tooltip("Fuerza del knockback aplicado al jugador")]
    public float knockbackForce = 5f;
    [Tooltip("Segundos que el jugador pierde el control después de recibir daño")]
    public float stunDuration = 1f;

    // Optional cached reference (not required, we'll prefer the collided instance)
    private PlayerControl2D targetPlayer;

    void Start()
    {
        // Intentamos cachear si existe un objeto llamado Player2D en escena (opcional)
        var obj = GameObject.Find("Player2D");
        if (obj != null)
            targetPlayer = obj.GetComponent<PlayerControl2D>();
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return; // Ignorar colisiones que no sean con el jugador

        // Obtener la instancia real del jugador que chocó
        var playerControl = collision.gameObject.GetComponent<PlayerControl2D>();
        if (playerControl == null)
        {
            Debug.LogWarning("DamageDealer: el objeto con tag Player no tiene PlayerControl2D.");
            return;
        }

        // Evitar reaplicar stun/daño si ya está aturdido
        if (playerControl.isStunned)
            return;

        // Aplica daño usando tu método existente
        playerControl.applyDamage();

        // Aplica knockback usando el Rigidbody que expone el jugador
        var rb = playerControl.getRigidbody();
        if (rb != null)
        {
            // Dirección desde el obstáculo hacia el jugador (solo X/Y)
            Vector3 rawDir = playerControl.transform.position - transform.position;
            Vector3 dir = new Vector3(rawDir.x, rawDir.y, 0f).normalized;

            // Resetar velocidad en X/Y (mantener Z) y aplicar impulso solo en X/Y
            rb.linearVelocity = new Vector3(0f, 0f, rb.linearVelocity.z);
            rb.angularVelocity = Vector3.zero;

            Vector3 knock = (dir + new Vector3(0f, 0.4f, 0f)) * knockbackForce;
            rb.AddForce(knock, ForceMode.Impulse);
        }
        else
        {
            Debug.LogWarning("DamageDealer: getRigidbody() devolvió null.");
        }

        // Aturdir al jugador (usa la bandera isStunned en el propio jugador)
        StartCoroutine(StunPlayer(playerControl, stunDuration));
    }

    private IEnumerator StunPlayer(PlayerControl2D player, float duration)
    {
        if (player == null) yield break;

        // Si ya está aturdido, no hacemos nada
        if (player.isStunned) yield break;

        player.isStunned = true;
        yield return new WaitForSeconds(duration);
        if (player != null) player.isStunned = false;
    }
}