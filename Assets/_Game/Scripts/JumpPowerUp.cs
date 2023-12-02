using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    //I think i am finished with this, the workings are fine so far
    // the only thing i can change is how to make the collectable spin
    // or something but other than that it is good 

    [Header("Double Jump Powerup")]
    [SerializeField]
    [Range(1, 5)]
    private int _poweredJumps = 1;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player._remainingJumps += _poweredJumps;
            player._maxJumpCount += _poweredJumps;
        }

        Destroy(this.gameObject);
    }
    
}
