using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _timerActive;
    private float _currentTime;
    [SerializeField] private int _startMinutes;
    [SerializeField] private TMP_Text _timerText;
    private int status = 0;
    // 0 = playing, 1 = win, 2 = lose
    void Start()
    {
        _currentTime = _startMinutes * 60;
        _timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(_timerActive) {
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                _timerActive = false;
                _currentTime = 0;
                status = 0;
            }
            TimeSpan timeSpan = TimeSpan.FromSeconds(_currentTime);
            _timerText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }

        
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            _timerActive = false;
            _timerText.text = "You Win!";
        }
    }
}
