using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    // Visible variables
    public Sprite heartSprite;
    public Sprite nullHeartSprite;

    // Not visible variables
    private static UIController Instance;
    private int hearts;
    private int maxHearts;
    private int defaultHearts = 3;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        setDefault();
    }

    void Update()
    {
        
    }

    // Updates life
    public void setLife(int life)
	{
        hearts = life;

        if (hearts > maxHearts)
        {
            maxHearts = hearts;
            activateHearts(maxHearts);
        }

        // Sets null hearts
        for (int i = 0; i < maxHearts; i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = nullHeartSprite;
        }

        // Sets hearts
        for (int i = 0; i < hearts; i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = heartSprite;
        }
    }  

    // Extra hearts activation
    private void activateHearts(int maxHearts)
    {
        if (maxHearts == 4)
        {
            transform.GetChild(3).GetComponent<Image>().enabled = true;
        }
        else if (maxHearts == 5)
        {
            transform.GetChild(4).GetComponent<Image>().enabled = true;
        } 
    }

    // Gets the heart count
    public int getLife()
    {
        return defaultHearts;
    }

    // Saves the heart count
    public void saveLife(int saveHearts)
    {
        defaultHearts = saveHearts;
    }

    public void gameOver()
    {
        SceneManager.LoadScene("GameOverMenu", LoadSceneMode.Single);
        setDefault();
    }

    // Default settings
    private void setDefault()
    {
        defaultHearts = 3;

        transform.GetChild(0).GetComponent<Image>().sprite = heartSprite;
        transform.GetChild(1).GetComponent<Image>().sprite = heartSprite;
        transform.GetChild(2).GetComponent<Image>().sprite = heartSprite;

        transform.GetChild(3).GetComponent<Image>().enabled = false;
        transform.GetChild(3).GetComponent<Image>().sprite = heartSprite;

        transform.GetChild(4).GetComponent<Image>().enabled = false;
        transform.GetChild(4).GetComponent<Image>().sprite = heartSprite;
    }
}