using UnityEngine;
using UnityEngine.VFX;

public class FootstepVFX : MonoBehaviour
{
    public VisualEffect[] footstepVFX;  // Array of VFX components (left and right foot)
    private int currentFoot = 0; // Track which footstep to play (0 for left, 1 for right)

    // This method will be called by the animation event
    private void OnFootstep()
    {
        // Play the current foot VFX
        if (footstepVFX != null && footstepVFX.Length > 0)
        {
            footstepVFX[currentFoot].Play();

            // Alternate between 0 (left foot) and 1 (right foot)
            currentFoot = (currentFoot + 1) % footstepVFX.Length;
        }
    }
}

