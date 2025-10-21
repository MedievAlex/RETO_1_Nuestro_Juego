using UnityEngine;

public class SimpleCameraFollower : MonoBehaviour
{
    public float distance = 2f;

    void OnEnable() // Se ejecuta cuando el Canvas se activa
    {
        if (Camera.main != null)
        {
            Transform cam = Camera.main.transform;
            transform.position = cam.position + cam.forward * distance;
            transform.LookAt(cam);
            transform.Rotate(0, 180, 0);
            transform.localScale = Vector3.one * 0.005f;
        }
    }
}