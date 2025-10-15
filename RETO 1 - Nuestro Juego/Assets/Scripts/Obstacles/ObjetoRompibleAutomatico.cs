using UnityEngine;

/** [ HACER QUE UN OBJETO SE ROMPA (DESAPAREZCA) ]
- Tras pisar el objeto durante varios segundos prolongados este caerá y desaparecerá
*/
public class ObjetoRompibleAutomatico : MonoBehaviour
{
    private bool peso = false; // Indica si el jugador está sobre el bloque
    public float velocidad = 5f; // Velocidad en el que caerá
    private Vector3 location; // Referencia a la localización

    // Se ejecuta Start una vez antes de que se ejecute por primera vez Update
    void Start()
    {
        location = transform.position; // Guardamos la posición inicial
        location.y = location.y - 4;
    }

    // Se ejecuta Update una vez por frame
    void Update()
    {
        if (peso)
        {
            transform.position = Vector3.MoveTowards(transform.position, location, velocidad * Time.deltaTime);
            if (transform.position == location)
            {
                Destroy(gameObject); // El objeto se destruirá en 2 frames (segundos)
            }
        }
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Comprueba que lo que ha colisionado es el "Jugador"
        {
            peso = true;

            collision.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero; // Stop it from moving
            collision.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // Reset the physical rotation
        }
    }
}