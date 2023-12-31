using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.25f;
    private Vector3 _currentVelocity = Vector3.zero;


    private void Awake()
    {
        if (target != null)
        {
            _offset = transform.position - target.position;
        }
        else
            Debug.Log("Camera Follower Does not have a target to follow");
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPostiion = target.position + _offset;
            transform.position = Vector3.SmoothDamp(transform.position,
                targetPostiion, ref _currentVelocity, smoothTime);
        }
    }
}
