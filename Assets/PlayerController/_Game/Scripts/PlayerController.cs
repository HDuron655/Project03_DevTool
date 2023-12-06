using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    #region "this is for the headers and more
    [Header("General Stats")]
    [SerializeField][Range(3, 100)]
    public float _moveSpeed = 4;
    [SerializeField][Range(2, 50)]
    private float _jumpHeight = 9.5f;

    [Header("Abilities")]
    [SerializeField]
    private bool _canJump = true;
    [SerializeField][Min(1)][Tooltip("Setting to a number greater than 1 means " +
        "that the player has that many number of jumps; setting to 1 means it will be a normal jump")]
    public int _maxJumpCount = 2;
    public int _remainingJumps = 0;

    [Header("Misc")]
    [SerializeField][Tooltip("Makes the number of collectables in the scene" +
        " visable in score UI")]
    private bool _collectableCountVisable;
    #endregion

    Rigidbody _rb = null;

    private int _origMaxJump;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _origMaxJump = _maxJumpCount;
    }

    private void Update()
    {
        MovePlayer();
        PlayerJump();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * _moveSpeed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * _moveSpeed;

        transform.Translate(horizontal, 0, vertical);
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
                        _remainingJumps--;

                        if (_maxJumpCount > _origMaxJump && _remainingJumps == 0)
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
            _remainingJumps = _maxJumpCount;
        }
    }
}