using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

/** [ HACER QUE UN OBJETO SE MUEVA A-B-C ]
- El objeto se mueve constantemente desde el punto A al punto B y punto C introducidos
- El orden es desde alante hacia atrás y vuelta al inicio
*/
public class ObjetoMovilAutomaticoABC : MonoBehaviour
{
    public Vector3 puntoA; // Punto inicial
    public Vector3 puntoB; // Punto intermedio
    public Vector3 puntoC; // Punto final
    public float velocidad = 2f; // Velocidad de movimiento
    private bool moviendoHaciaA = false;
    private bool moviendoHaciaB = true;
    private bool moviendoHaciaC = false;
    private bool volviendoHaciaB = false;

    // Se ejecuta Start una vez antes de que se ejecute por primera vez Update
    void Start()
    {
        
    }

    // Se ejecuta Update una vez por frame
    void Update()
    {
        if (moviendoHaciaB || volviendoHaciaB) // Se mueve hacia el punto B por primera o segunda vez
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoB, velocidad * Time.deltaTime);
            if (transform.position == puntoB && moviendoHaciaB) // Se mueve por primera vez desde el punto A
            {
                moviendoHaciaB = false; // Cambia dirección
                moviendoHaciaC = true; // Cambia dirección

            }
            else if (transform.position == puntoB && volviendoHaciaB) // Se mueve por segunda vez volviendo desde punto B
            {
                volviendoHaciaB = false; // Cambia dirección
                moviendoHaciaA = true; // Cambia dirección
            }
        }
        else if (moviendoHaciaC) // Se mueve hacia el punto C
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoC, velocidad * Time.deltaTime);
            if (transform.position == puntoC)
            {
                moviendoHaciaC = false; // Cambia dirección
                volviendoHaciaB = true; // Cambia dirección
            }
        }
        else if (moviendoHaciaA) // Se mueve hacia el punto A
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoA, velocidad * Time.deltaTime);
            if (transform.position == puntoA)
            {
                moviendoHaciaA = false; // Cambia dirección
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
