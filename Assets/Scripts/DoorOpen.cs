using UnityEngine;
using UnityEngine.InputSystem;

public class DoorOpen : MonoBehaviour
{
    public Animator doorAnimator; // Reference to the Animator component
    public string triggerTag = "DoorClose"; // The specific tag for the trigger
    private bool isPlayerInTrigger = false; // Track if the player is in the trigger zone
    private bool isDoorOpen = false; // Track if the door is open or not
    private PlayerInput playerInput; // Reference to the PlayerInput component
    private InputAction interactAction; // Reference to the Interact action

    void Awake()
    {
        // Initialize PlayerInput and Interact action
        playerInput = GetComponent<PlayerInput>();
        interactAction = playerInput.actions["Interact"];
    }

    void OnEnable()
    {
        // Subscribe to the Interact action event
        interactAction.performed += OnInteractPerformed;
    }

    void OnDisable()
    {
        // Unsubscribe from the Interact action event
        interactAction.performed -= OnInteractPerformed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the specified tag
        if (other.CompareTag(triggerTag))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger has the specified tag
        if (other.CompareTag(triggerTag))
        {
            isPlayerInTrigger = false;
            CloseDoor(); // Automatically close the door when exiting the trigger
        }
    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        // If the player is in the trigger zone and presses the interact key
        if (isPlayerInTrigger)
        {
            if (isDoorOpen)
            {
                CloseDoor();
            }
            else
            {
                OpenDoor();
            }
        }
    }

    private void OpenDoor()
    {
        isDoorOpen = true;
        doorAnimator.SetBool("DoorOpen", true); // Set the animator to open the door
    }

    private void CloseDoor()
    {
        isDoorOpen = false;
        doorAnimator.SetBool("DoorOpen", false); // Set the animator to close the door
    }
}
