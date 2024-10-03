using UnityEngine;
using UnityEngine.InputSystem;

public class DoorOpen : MonoBehaviour
{
    public Animator doorAnimator;
    public string triggerTag = "DoorClose";
    private bool isPlayerInTrigger = false;
    private bool isDoorOpen = false;
    private PlayerInput playerInput;
    private InputAction interactAction;
    public AudioClip openDoorSound;
    public AudioClip closeDoorSound;
    private AudioSource audioSource;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        interactAction = playerInput.actions["Interact"];
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnEnable()
    {
        interactAction.performed += OnInteractPerformed;
    }

    void OnDisable()
    {
        interactAction.performed -= OnInteractPerformed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            isPlayerInTrigger = false;
            CloseDoor();
        }
    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
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
        doorAnimator.SetBool("DoorOpen", true);
        if (openDoorSound != null)
        {
            audioSource.PlayOneShot(openDoorSound);
        }
    }

    private void CloseDoor()
    {
        isDoorOpen = false;
        doorAnimator.SetBool("DoorOpen", false);
        if (closeDoorSound != null)
        {
            audioSource.PlayOneShot(closeDoorSound);
        }
    }
}
