using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI; // For UI components
using TMPro;
public class SitAction : MonoBehaviour
{
    public Animator animator; 
    private PlayerInput playerInput; 
    private InputAction sitAction;

    public TextMeshProUGUI uiText; 
    private bool isSitting = false; 
    private bool isInSittingPlace = false; 

    void Awake()
    {
        
        playerInput = GetComponent<PlayerInput>();
        sitAction = playerInput.actions["Sit"];
    }

    void OnEnable()
    {
        
        sitAction.performed += OnSitPerformed;
    }

    void OnDisable()
    {
        
        sitAction.performed -= OnSitPerformed;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("SitArea"))
        {
            isInSittingPlace = true;
            uiText.text = "";
        }
    }

    void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("SitArea"))
        {
            isInSittingPlace = false;
        }
    }

    void OnSitPerformed(InputAction.CallbackContext context)
    {
        if (isInSittingPlace)
        {
            
            isSitting = !isSitting;
            animator.SetBool("Sit", isSitting);
        }
        else
        {
            
            uiText.text = "Not a sitting place!";
        }
    }
}