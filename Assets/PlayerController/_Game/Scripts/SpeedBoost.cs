using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [Header("Speed Boost Buff")]
    [SerializeField]
    [Range(1, 10)]
    private float _buffedSpeed;

    [SerializeField] [Min(0)]
    private float _powerupDuration = 3;

    [SerializeField]
    private GameObject _artToDisable = null;

    private Collider _collider;

    [Tooltip("This is for how fast the object will rotate in the game")]
    public float rotateSpeed = 0.5f;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        transform.Rotate(0, -rotateSpeed, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            StartCoroutine(PowerUp(_powerupDuration));
        }
    }

    IEnumerator PowerUp (float duration)
    {
        GameObject gamePlayer = GameObject.Find("Player");
        PlayerController player = gamePlayer.GetComponent<PlayerController>();

        //soft disable
        _artToDisable.SetActive(false);
        _collider.enabled = false;

        player._moveSpeed = player._moveSpeed += _buffedSpeed;

        yield return new WaitForSeconds(duration);
        
        player._moveSpeed = player._moveSpeed -= _buffedSpeed;

        Destroy(this);
    }
}
