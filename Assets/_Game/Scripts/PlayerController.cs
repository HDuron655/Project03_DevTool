using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("General Stats")]
    [SerializeField][Range(3, 100)]
    private float _moveSpeed = 5;
    [SerializeField][Range(2, 50)]
    private float _jumpHeight = 5;

    //maybe add a gravity slider for how quick player falls?


    [Header("Abilities")]
    [SerializeField]
    private bool _canJump = true;
    [SerializeField]
    private bool _canDoubleJump;


    [Header("Misc")]
    [SerializeField][Tooltip("Makes the number of collectables in the scene" +
        " visable in score UI")]
    private bool _collectableCountVisable;

    Rigidbody _rb = null;

    private bool playerIsOnGround = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovePlayer();
        PlayerJump();
        Debug.Log(playerIsOnGround);
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * _moveSpeed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * _moveSpeed;

        transform.Translate(horizontal, 0, vertical);

        /*
        float moveAmountThisFrameZ = Input.GetAxisRaw("Vertical") * _moveSpeed;
        Vector3 moveDirectionZ = transform.forward * moveAmountThisFrameZ;
        _rb.AddForce(moveDirectionZ);

        float moveAmountThisFrameX = Input.GetAxisRaw("Horizontal") * _moveSpeed;
        Vector3 moveDirectionX = transform.right * moveAmountThisFrameX;
        _rb.AddForce(moveDirectionX);
        */

    }

    void PlayerJump()
    {
        if (this._canJump == true)
        {
            if (Input.GetButtonDown("Jump") && playerIsOnGround)
            {
                _rb.AddForce(new Vector3(0, _jumpHeight, 0), ForceMode.Impulse);
                playerIsOnGround = false;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
            playerIsOnGround = true;
            }
            /*make this possible by making playerisonground statement true when
             the player is on ground, maybe tags and other stuff? but also 
            incorporate the double jump method by adding more to the first 
            if statement about "JUMP" etc.
             */
            



        /*
        if (this.transform.position.y < _jumpHeight)
        {
            float jumpAmountThisFrame = Input.GetAxis("Jump") * _jumpHeight;
            Vector3 Jumping = transform.up * jumpAmountThisFrame;
            _rb.AddForce(Jumping);
        }
        */
        }
    }



    // also make the inventory system to 
    // keep score updated with each collectable
    // and how many there are in the game

    // make it possible to bind
    // other keys into movement through
    // inspector
}