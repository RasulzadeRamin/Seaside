using UnityEngine;
using UnityEngine.InputSystem;

public class SofaColorChanger : MonoBehaviour
{
    public Renderer sofaRenderer; // Reference to the Renderer component of the sofa
    public Color[] colors; // Array of colors to cycle through
    private int currentColorIndex = 0; // Track the current color index
    private PlayerInput playerInput; // Reference to the PlayerInput component
    private InputAction changeColorAction; // Input action for changing the color

    void Awake()
    {
        // Get PlayerInput component and the ChangeColor action
        playerInput = GetComponent<PlayerInput>();
        changeColorAction = playerInput.actions["ChangeColor"];
    }

    void OnEnable()
    {
        // Subscribe to the ChangeColor action event
        changeColorAction.performed += OnChangeColor;
    }

    void OnDisable()
    {
        // Unsubscribe from the ChangeColor action event
        changeColorAction.performed -= OnChangeColor;
    }

    public void OnChangeColor(InputAction.CallbackContext context) // Ensure the method is public
    {
        // Cycle through the colors array
        currentColorIndex = (currentColorIndex + 1) % colors.Length;

        // Set the new color to the material
        if (sofaRenderer != null)
        {
            sofaRenderer.material.color = colors[currentColorIndex];
        }
    }
}
