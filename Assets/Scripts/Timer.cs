using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public bool _timerActive;
    private float _currentTime;
    public bool fishCount = false;
    [SerializeField] private int _startMinutes;
    [SerializeField] private TMP_Text _timerText;
    public int status = 0;
    private Vector3 origin;
    // 0 = playing, 1 = win, 2 = lose
    void Start()
    {
        _currentTime = _startMinutes * 60;
        _timerActive = true;

        origin = new Vector3(5.7f, 3.9f, 45.1f);
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
                if(status == 0)
                {
                    status = 2;
                }
                
            }
            TimeSpan timeSpan = TimeSpan.FromSeconds(_currentTime);
            _timerText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
            if (fishCount)
            {
                _timerText.text += " Fish Caught : " + randomWalk.fishCaught.ToString();
                if(randomWalk.fishCaught >= 3)
                {
                    status = 1;
                    _timerActive = false;
                }
            }
        }
        else {
            if (status == 1)
            {
                _timerText.text = "You Win!";
            }
            else if (status == 2)
            {
                _timerText.text = "You Lose!";
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && gameObject.transform.position.z >= 50)
        {
            gameObject.transform.position = origin;
        }
        //Debug.Log("Collision with " + collision.gameObject.name);
        //Debug.Log(Equals(collision.gameObject.tag, "Enemy"));
        //Debug.Log(gameObject.transform.position.z);
        //Debug.Log(origin);
    }

}
