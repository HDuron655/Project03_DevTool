using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    
    [Header("Double Jump Powerup")]
    [SerializeField]
    [Range(1, 5)]
    [Tooltip("This is how many jumps the powerup will give the player")]
    private int _poweredJumps = 1;

    [Tooltip("This is for how fast the object will rotate in the game")]
    public float rotateSpeed = 0.5f;

    private void Update()
    {
        transform.Rotate(0, -rotateSpeed, 0, Space.World);
    }

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
