using UnityEngine;
using UnityEngine.UI;

public class DamageBorderController : MonoBehaviour
{
    //Visible variables
    public Sprite border;

    // Not visible variables
    private Image image;
    private bool visible;
    private float timePassed;
    private float visibleSeconds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = transform.GetComponent<Image>();
        image.sprite = border;
    }

    // Update is called once per frame
    void Update()
    {
        if (visible)
        {
            timePassed += Time.deltaTime; // Calculates the time
            if (timePassed > visibleSeconds) // Destroys the platform
            {
                visible = false;
                ShowDamageBorder(visible, 0f);
            }  
        }
    }

    // Shows or hides the border
    public void ShowDamageBorder(bool visible, float visibleSeconds)
    {
        timePassed = 0;
        this.visibleSeconds = visibleSeconds;    
        this.visible = visible;
        
        Debug.Log("[DamabeBorder] Visible " + visible + ".");
        image.enabled = visible;
    }
}