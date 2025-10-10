using UnityEngine;
using UnityEngine.UI;

/** [ CONTROLES DE MOVIMIENTO EN 2D V.5 ]
- Movimiento: Izquierda y derecha
- Salto: Salto simple
- Doble Salto: Tantos saltos como se desee
- Respawn: Reaparición en el primer punto
- Checkpoints: Almacena la localización de los checkpoints para reaparecer ahí
- Correr: Al mantener Left Shift la velocidad de movimiento se duplicará
*/
public class ControlMovimiento2D_v5 : MonoBehaviour
{
    public float velocidadBase = 5f; // Velocidad base del movimiento
    private float velocidad; // Velocidad del movimiento
    public float fuerzaSalto = 5f; // Fuerza del salto
    public int saltos = 2; // Cantidad de saltos
    private int saltosRestantes; // Saltos disponibles
    private Vector3 spawnPoint; // Referencia al punto de reaparición
    private Rigidbody rb; // Referencia al Rigidbody

    // Se ejecuta Start una vez antes de que se ejecute por primera vez Update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
        spawnPoint = transform.position; // Guardamos la posición inicial
    }

    // Se ejecuta Update una vez por frame
    void Update()
    {
        // Movimiento hacia izquierda y derecha
        float moverIzquierdaDerecha = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        transform.Translate(moverIzquierdaDerecha, 0, 0); // X, Y, Z

        // Saltar
        if (saltosRestantes > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            saltosRestantes--;
        }

        // Correr
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidad = velocidadBase * 1.7f;
        }
        else
        {
            velocidad = velocidadBase;
        }
    }

    // Se ejecuta cuando ocurre una colision
    private void OnCollisionEnter(Collision collision)
    {
        saltosRestantes = saltos; // Reinicia el contador

        if (collision.gameObject.CompareTag("DeathPoint")) // Respawn si toca el suelo
        {
            Respawn();
        }
    }

    // Se ejecuta cuando ocurre una colision con un trigger
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("CheckPoint")) // Respawn si toca el suelo
        {
            spawnPoint = transform.position; // Guarda la posición del checkpoint
            Destroy(collider.gameObject);
        } 
    }

    // Metodo de reaparición
    private void Respawn()
    {
        rb.linearVelocity = Vector3.zero; // Para que no siga moviéndose
        rb.angularVelocity = Vector3.zero; // Resetea la rotación física
        transform.position = spawnPoint; // Reaparece en el punto guardado
    }
}