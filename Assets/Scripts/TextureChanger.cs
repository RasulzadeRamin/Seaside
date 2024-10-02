using UnityEngine;
using UnityEngine.InputSystem;

public class TextureChanger : MonoBehaviour
{
    public Renderer carpetRenderer; // Reference to the Renderer component of the sofa
    public Texture[] textures; // Array of textures to cycle through
    private int currentTextureIndex = 0; // Track the current texture index
    private PlayerInput playerInput; // Reference to the PlayerInput component
    private InputAction changeTextureAction; // Input action for changing the texture

    void Awake()
    {
        // Get PlayerInput component and the ChangeTexture action
        playerInput = GetComponent<PlayerInput>();
        changeTextureAction = playerInput.actions["ChangeTexture"];
    }

    void OnEnable()
    {
        // Subscribe to the ChangeTexture action event
        changeTextureAction.performed += OnChangeTexture;
    }

    void OnDisable()
    {
        // Unsubscribe from the ChangeTexture action event
        changeTextureAction.performed -= OnChangeTexture;
    }

    public void OnChangeTexture(InputAction.CallbackContext context) // Ensure the method is public
    {
        // Cycle through the textures array
        currentTextureIndex = (currentTextureIndex + 1) % textures.Length;

        // Set the new texture to the material
        if (carpetRenderer != null && textures.Length > 0)
        {
            carpetRenderer.material.mainTexture = textures[currentTextureIndex];
        }
    }
}
