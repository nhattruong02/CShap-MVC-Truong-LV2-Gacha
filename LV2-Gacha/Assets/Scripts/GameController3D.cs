using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController3D : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float speed;
    [SerializeField] float speedDown;
    [SerializeField] GameObject imgWheel;
    [SerializeField] GameObject arrow;
    private bool stopWheel;
    [SerializeField] GameObject bgResult;
    [SerializeField] Text textUI;
    [SerializeField] string random;
    private float time;
    [SerializeField] AudioSource audio;
    private static GameController3D _instantce;
    public static GameController3D instantce => _instantce;
    private void Awake()
    {
        _instantce = this;
    }
    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        if (stopWheel)
        {
            time -= Time.deltaTime;
            imgWheel.transform.Rotate(0, speed * Time.deltaTime, 0);
            speed -= speedDown;
            if (random.Equals(ShowResult3D.instantce.text))
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
        textUI.text = Common.Score + ": " + ShowResult3D.instantce.text;
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
