using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCameraController : MonoBehaviour
{

    // START runs once before the first UPDATE it's executed
    void Start()
    {
        DontDestroyOnLoad(gameObject);    
    }

    // UPDATE is executed once per frame
    void Update()
    {
        
    }
}