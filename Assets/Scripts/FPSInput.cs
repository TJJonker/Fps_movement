using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 6f;

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float deltaZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(deltaX, 0, deltaZ);
    }
}
