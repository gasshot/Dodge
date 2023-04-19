using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed = 60f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotateSpeed, 0f);
    }
}
