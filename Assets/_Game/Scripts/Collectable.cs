using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("Scoring")]
    [SerializeField] [Min(0)]
    public int _points = 1;

    private float rotateSpeed = 0.5f;

    private void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        UIController Scoring = other.gameObject.GetComponent<UIController>();

        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            if (Scoring != null)
                _points++;
            Debug.Log("SUTUR");
        }

        Destroy(this.gameObject);
    }
}
