using UnityEngine;
using UnityEngine.VFX;

public class FootstepVFX : MonoBehaviour
{
    public VisualEffect[] footstepVFX;
    private int currentFoot = 0;

    private void OnFootstep()
    {
        if (footstepVFX != null && footstepVFX.Length > 0)
        {
            footstepVFX[currentFoot].Play();

            currentFoot = (currentFoot + 1) % footstepVFX.Length;
        }
    }
}

