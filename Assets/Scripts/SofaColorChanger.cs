using UnityEngine;
using UnityEngine.InputSystem;

public class SofaColorChanger : MonoBehaviour
{
    public Renderer sofaRenderer;
    public Color[] colors;
    private int currentColorIndex = 0;
    private PlayerInput playerInput;
    private InputAction changeColorAction;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        changeColorAction = playerInput.actions["ChangeColor"];
    }

    void OnEnable()
    {
        changeColorAction.performed += OnChangeColor;
    }

    void OnDisable()
    {
        changeColorAction.performed -= OnChangeColor;
    }

    public void OnChangeColor(InputAction.CallbackContext context)
    {
        currentColorIndex = (currentColorIndex + 1) % colors.Length;

        if (sofaRenderer != null)
        {
            sofaRenderer.material.color = colors[currentColorIndex];
        }
    }
}
