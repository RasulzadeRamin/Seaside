using UnityEngine;
using UnityEngine.InputSystem;

public class TextureChanger : MonoBehaviour
{
    public Renderer carpetRenderer; 
    public Texture[] textures; 
    private int currentTextureIndex = 0; 
    private PlayerInput playerInput; 
    private InputAction changeTextureAction; 

    void Awake()
    {
        
        playerInput = GetComponent<PlayerInput>();
        changeTextureAction = playerInput.actions["ChangeTexture"];
    }

    void OnEnable()
    {
        
        changeTextureAction.performed += OnChangeTexture;
    }

    void OnDisable()
    {
        changeTextureAction.performed -= OnChangeTexture;
    }

    public void OnChangeTexture(InputAction.CallbackContext context)
    {
        currentTextureIndex = (currentTextureIndex + 1) % textures.Length;

        if (carpetRenderer != null && textures.Length > 0)
        {
            carpetRenderer.material.mainTexture = textures[currentTextureIndex];
        }
    }
}
