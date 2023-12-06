using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    [Header("Scoring")]
    [SerializeField]
    [Min(0)]
    public int _points = 1;

    [SerializeField] private TextMeshProUGUI _currentScoreTextView;
    private int _currentScore;

    private float rotateSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            IncreaseScore(_currentScore);
        }
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            IncreaseScore(_points);
        }

        this.gameObject.SetActive(false);
    }

    public void IncreaseScore(int scoreIncrease)
    {
        _points = _points + 1;
        // increase score
        _currentScore += scoreIncrease;
        // update score display, so that we can see new score
        _currentScoreTextView.text =
            "Score: " + _points;
    }
}
