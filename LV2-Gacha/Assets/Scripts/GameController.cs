using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float speed;
    [SerializeField] float speedDown;
    [SerializeField] Transform imgWheel;
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
            imgWheel.transform.Rotate(0, 0, speed * Time.deltaTime);
            speed -= speedDown;
            if (random.Equals(ShowResult.instantce.text))
            {
                if (time <= 2f)
                {
                    showResult();
                }
            }
            if (time <= 0.2f)
            {
                showResult();
            }

        }
    }

    private void showResult()
    {
        audio.Stop();
        stopWheel = false;
        bgResult.SetActive(true);
        textUI.text = Common.Score + ": " + ShowResult.instantce.text;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
