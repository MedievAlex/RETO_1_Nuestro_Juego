using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // Visible variables
    [Header("Canvas")] // Makes a header on the public variables
    [SerializeField] private GameObject Canvas;

    [Header("Buttons")] // Makes a header on the public variables
    public Button leftButton;
    public Button rightButton;
    public Button jumpButton;
    public Button dashButton;
    public Button interactButton;

    // Not visible variables
    private UIController uiController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiController = transform.parent.GetComponentInParent<UIController>();
        leftButton.onClick.AddListener(LeftMovement); // When clicking Left button starts the game
        rightButton.onClick.AddListener(RightMovement); // When clicking Right button closes the game
        jumpButton.onClick.AddListener(JumpMovement); // When clicking Jump button opens the Options Menu
        dashButton.onClick.AddListener(DashMovement); // When clicking Dash button opens the Options Menu
        interactButton.onClick.AddListener(Interact); // When clicking Dash button opens the Options Menu
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Left movement button
    private void LeftMovement()
    {
        
    }

    // Right movement button
    private void RightMovement()
    {
        
    }

    // Jump movement button
    private void JumpMovement()
    {
        
    }

    // Dash movement button
    private void DashMovement()
    {
        
    }

    // Interact button
    private void Interact()
    {
        
    }
}
