using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    // Visible variables
    public Sprite heatlhBarS;
    public Sprite nullHeatlhBarS;
    public Sprite heatlhBarM;
    public Sprite nullHeatlhBarM;
    public Sprite heatlhBarE;
    public Sprite nullHeatlhBarE;

    // Not visible variables
    private UIController uiController;
    private int hearts;
    private int maxHearts;
    private int currentHearts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("[HealthBar] Getting UI Controller.");
        uiController = transform.parent.GetComponentInParent<UIController>();
    }

    // Updates life
    public void UpdateLives(int lives)
    {
        Debug.Log("[HealthBar] " + lives + " lives left.");

        if (hearts > lives)
        {
            Debug.Log("[HealthBar] - 1 Heart.");
        }
        else
        {
            Debug.Log("[HealthBar] + 1 Heart.");
        }

        hearts = lives;

        if (hearts > maxHearts)
        {
            maxHearts = hearts;
            ActivateExtraHearts(maxHearts);
        }

        // Sets null hearts
        for (int i = 0; i < maxHearts; i++)
        {
            if (i == 0)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = nullHeatlhBarS;
            }
            else if (i == maxHearts - 1)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = nullHeatlhBarE;
            }
            else
            {
                transform.GetChild(i).GetComponent<Image>().sprite = nullHeatlhBarM;
            }
        }

        // Sets hearts
        for (int i = 0; i < hearts; i++)
        {
            if (i == 0)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = heatlhBarS;
            }
            else if (i == maxHearts - 1)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = heatlhBarE;
            }
            else
            {
                transform.GetChild(i).GetComponent<Image>().sprite = heatlhBarM;
            }
        }

        // Game Over
        if (hearts == 0)
        {
            Debug.LogWarning("[HealthBar] No hearts left.");
            uiController.GameOver();
        }
    }

    // Extra hearts activation
    private void ActivateExtraHearts(int maxHearts)
    {
        if (maxHearts == 4)
        {
            Debug.Log("[HealthBar] 4th Extra Heart unlocked.");
            transform.GetChild(2).GetComponent<Image>().sprite = heatlhBarM;
            transform.GetChild(3).GetComponent<Image>().sprite = heatlhBarE;
            transform.GetChild(3).GetComponent<Image>().enabled = true;
        }
        else if (maxHearts == 5)
        {
            Debug.Log("[HealthBar] 5th Extra Heart unlocked.");
            transform.GetChild(3).GetComponent<Image>().sprite = heatlhBarM;
            transform.GetChild(4).GetComponent<Image>().sprite = heatlhBarE;
            transform.GetChild(4).GetComponent<Image>().enabled = true;
        }
    }

    // Gets the heart count
    public int GetLives()
    {
        Debug.Log("[HealthBar] Current Hearts: " + currentHearts + ".");
        return currentHearts;
    }

    // Saves the heart count
    public void SaveLives(int saveHearts)
    {
        Debug.Log("[HealthBar] Saving " + currentHearts + " Hearts.");
        currentHearts = saveHearts;
    }

    // Default settings
    public void SetDefault()
    {
        Debug.Log("[HealthBar] Setting default Health Bar.");

        currentHearts = 3;
        maxHearts = 3;

        transform.GetChild(0).GetComponent<Image>().sprite = heatlhBarS;
        transform.GetChild(1).GetComponent<Image>().sprite = heatlhBarM;
        transform.GetChild(2).GetComponent<Image>().sprite = heatlhBarE;

        transform.GetChild(3).GetComponent<Image>().enabled = false;

        transform.GetChild(4).GetComponent<Image>().enabled = false;
    }
}