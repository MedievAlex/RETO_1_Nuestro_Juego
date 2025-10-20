using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("Botones")]
    public Button playButton;
    public Button optionsButton;
    public Button exitButton;

    void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}