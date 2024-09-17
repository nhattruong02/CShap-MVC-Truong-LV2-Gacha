using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult3D : MonoBehaviour
{
    private static ShowResult3D _instantce;
    public static ShowResult3D instantce => _instantce;
    public string text;
    private void Awake()
    {
        _instantce = this;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(Common.Score))
        {
            text = collision.gameObject.GetComponent<TMP_Text>().text;
        }
    }
}
