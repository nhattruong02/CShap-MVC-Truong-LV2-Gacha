using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play3D : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        GameController3D.instantce.Play();
    }
}
