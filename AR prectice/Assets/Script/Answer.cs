using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class Answer : MonoBehaviour
{
    private Vector3 touchPos;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            this.gameObject.SetActive(true);
        }

    }
}
