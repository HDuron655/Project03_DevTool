using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    #region "this is for the headers and stuff
    [Header("General Stats")]
    [SerializeField][Range(3, 100)]
    public float _moveSpeed = 5;
    [SerializeField][Range(2, 50)]
    private float _jumpHeight = 5;

    //maybe add a gravity slider for how quick player falls?

    [Header("Abilities")]
    [SerializeField]
    private bool _canJump = true;
    [SerializeField][Min(1)]
    public int _maxJumpCount = 2;
    public int _remainingJumps = 0;

    [Header("Misc")]
    [SerializeField][Tooltip("Makes the number of collectables in the scene" +
        " visable in score UI")]
    private bool _collectableCountVisable;
    #endregion

    Rigidbody _rb = null;

    JumpPowerUp _powerJumpz;

    private int _origMaxJump;

    //private bool playerIsOnGround = true;

    //Character controller movment
    private CharacterController _characterController;

    private Vector3 _direction;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _powerJumpz = gameObject.GetComponent<JumpPowerUp>();

        _origMaxJump = _maxJumpCount;

        //_characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovePlayer();
        PlayerJump();
        //Debug.Log(Time.deltaTime);
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
            if (Input.GetButtonDown("Jump"))
                if (_remainingJumps > 0)
                {
                    {
                        _rb.AddForce(new Vector3(0, _jumpHeight, 0), ForceMode.Impulse);
                        //playerIsOnGround = false;
                        _remainingJumps--;

                        if (_maxJumpCount > _origMaxJump && _remainingJumps ==0)
                        {
                            _maxJumpCount = _origMaxJump;
                        }
                    }
                }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //playerIsOnGround = true;
            _remainingJumps = _maxJumpCount;
        }
    }

    //READ!!!!
    /* 12/3/23
     * make the powerups spin or something, make them intesting
     * make the camera follow the player like in marble madness
     * make the playtesting room showcasing the abliities
     * add a UI for stored Jumps
     * make collectables for player with a score UI
     * make an indicator for how long the speed boost will last
     * maybe implement an optional first person camera?
     * IN THE FUTURE add particles and a sfx when collecting the powers
    */
    
    //TODO after all of that is done, make sure to make a little playtest room
    // so that i can showcase what i did for the video

    //OLD
    // also make the inventory system to 
    // keep score updated with each collectable
    // and how many there are in the game

    // make it possible to bind
    // other keys into movement through
    // inspector
}