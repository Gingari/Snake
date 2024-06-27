using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    public GameObject camera;
    void Update()
    {
        gameObject.transform.position = camera.transform.position;
    }
}
