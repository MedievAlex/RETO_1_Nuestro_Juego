using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

/** [ HACER QUE UN OBJETO SE MUEVA A-B ]
- El objeto se mueve constantemente desde el punto A al punto B introducidos
*/
public class ObjetoMovilAutomaticoAB : MonoBehaviour
{    
    public Vector3 puntoA; // Punto inicial
    public Vector3 puntoB; // Punto final
    public float velocidad = 2f; // Velocidad de movimiento
    private bool moviendoHaciaB = true;

    // Se ejecuta Start una vez antes de que se ejecute por primera vez Update
    void Start()
    {
        puntoA = transform.position = puntoA; // Posición inicial
    }

    // Se ejecuta Update una vez por frame
    void Update()
    {
        if (moviendoHaciaB) // Se mueve hacia el punto B
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoB, velocidad * Time.deltaTime);
            if (transform.position == puntoB)
            {
                moviendoHaciaB = false; // Cambia dirección
            }      
        }
        else  // Se mueve hacia el punto A
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoA, velocidad * Time.deltaTime);
            if (transform.position == puntoA)
            {
                moviendoHaciaB = true; // Cambia dirección
            }     
        }
    }

    // Se ejecuta cuando ocurre una colision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Comprueba que lo que ha colisionado es el "Jugador"
        {                       
            collision.transform.SetParent(transform); // Convierte el Jugador como hijo de la plataforma, haciendo que se mueva junto a esta
        }
    }

    // Se ejecura cuando termina una colision
    private void OnCollisionExit(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Player")) // Comprueba que lo que ha dejado de colisionar es el "Jugador"
        {
            collision.transform.SetParent(null); // Elimina la plataforma como padre del Jugador, haciendo que se mueva libre ota vez
        }
    }
}
