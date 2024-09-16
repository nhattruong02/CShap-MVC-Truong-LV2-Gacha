using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    private static ShowResult _instantce;
    public static ShowResult instantce => _instantce;
    public string text;
    private void Awake()
    {
        _instantce = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Common.Score))
        {
            text = collision.gameObject.GetComponent<Text>().text;
        }
    }
}
