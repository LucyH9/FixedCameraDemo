using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMainCamera : MonoBehaviour
{
    public Camera mainCamera;
    void Start()
    {
        mainCamera.depth = Camera.main.depth + -1;
    }
    void LateUpdate()
    {
        transform.position = mainCamera.transform.position;
        transform.rotation = mainCamera.transform.rotation;
    }
}
