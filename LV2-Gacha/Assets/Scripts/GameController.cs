using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float speed;
    [SerializeField] GameObject imgWheel;
    [SerializeField] GameObject arrow;
    private bool stopWheel;
    [SerializeField] GameObject bgResult;
    [SerializeField] Text textUI;
    [SerializeField] string random;
    private float time;
    [SerializeField] AudioSource audio;
    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        if (stopWheel)
        {
            time -= Time.deltaTime;
            Debug.Log(time);
            imgWheel.transform.Rotate(0, 0, speed);
            if (time < 2)
            {
                speed--;
                if (speed < 0)
                {
                    audio.Stop();
                    stopWheel = false;
                    bgResult.SetActive(true);
                    textUI.text = Common.Score + ": " + ShowResult.instantce.text;
                }
            }
        }  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (bgResult.activeSelf)
            {
                bgResult.SetActive(false);
            }
        }
    }
    public void Play()
    {
        time = Random.Range(4, 6);
        audio.Play();
        speed = maxSpeed;
        stopWheel = true;
    }
}
