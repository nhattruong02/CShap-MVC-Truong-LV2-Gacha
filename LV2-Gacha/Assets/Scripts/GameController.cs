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
    private bool stopWheel;
    [SerializeField] GameObject bgResult;
    [SerializeField] Text textUI;
    [SerializeField] string random;
    private float time;
    [SerializeField] List<string> prizes = new List<string>();
    [SerializeField] AudioSource audio;
    [SerializeField] int segment;
    float finalAngle;
    private float target;

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
            /*            if (random.Equals(ShowResult.instantce.text))
                        {
                            if (time <= 2f)
                            {
                                showResult(finalAngle);
                            }
                        }*/
            if (time <= 0.2f)
            {
                finalAngle = imgWheel.transform.eulerAngles.z;
                showResult(finalAngle);
            }

        }
    }

    private void showResult(float finalAngle)
    {
        audio.Stop();
        stopWheel = false;
        bgResult.SetActive(true);
        if (finalAngle > 0 && finalAngle < 32.7)
            textUI.text = prizes[0];
        if (finalAngle > 32.7 && finalAngle < 65.4)
            textUI.text = prizes[1];
        if (finalAngle > 65.4 && finalAngle < 98.1)
            textUI.text = prizes[2];
        if (finalAngle > 98.1 && finalAngle < 130.8)
            textUI.text = prizes[3];
        if (finalAngle > 130.8 && finalAngle < 165.5)
            textUI.text = prizes[4];
        if (finalAngle > 165.5 && finalAngle < 196.2)
            textUI.text = prizes[5];
        if (finalAngle > 196.2 && finalAngle < 233.4)
            textUI.text = prizes[6];
        if (finalAngle > 233.4 && finalAngle < 266.1)
            textUI.text = prizes[7];
        if (finalAngle > 266.1 && finalAngle < 298.8)
            textUI.text = prizes[8];
        if (finalAngle > 298.8 && finalAngle < 327)
            textUI.text = prizes[9];
        if (finalAngle > 327 && finalAngle < 360)
            textUI.text = prizes[10];
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
/*        target = 360 * 
*/        time = Random.Range(4, 6);
        audio.Play();
        speed = maxSpeed;
        stopWheel = true;
    }
}
