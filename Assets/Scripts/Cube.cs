using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float _rotationVelocity = 1f;

    void Update()
    {
        Vector3 newRotation = new Vector3(Input.GetAxis("Vertical"), -Input.GetAxis("Horizontal"), 0f);
        transform.Rotate(newRotation * _rotationVelocity);
    }
}
