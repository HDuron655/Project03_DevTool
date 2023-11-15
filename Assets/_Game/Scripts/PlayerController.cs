using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Stats")]
    [SerializeField][Range(0, 100)]
    private float _speed;
    [SerializeField][Range(0, 50)]
    private float _jumpHeight;


    [Header("Abilities")]
    [SerializeField]
    private bool _canJump;
    [SerializeField]
    private bool _canDoubleJump;


    [Header("Misc")]
    [SerializeField][Tooltip("Makes the number of collectables in the scene" +
        " visable in score UI")]
    private bool _collectableCountVisable;
    
    // also make the inventory system to 
    // keep score updated with each collectable
    // and how many there are in the game

    // make it possible to bind
    // other keys into movement through
    // inspector
}