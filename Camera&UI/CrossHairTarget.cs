using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairTarget : MonoBehaviour
{
    [SerializeField]
    float fixedOffset = 100f;

    Camera mainCamera;
    Ray ray;
    RaycastHit hitInfo;

    void Start()
    {
        mainCamera = Camera.main;   
    }
    void Update()
    {
        ray.origin = mainCamera.transform.position + mainCamera.transform.forward * fixedOffset;
        ray.direction = mainCamera.transform.forward;
        if (Physics.Raycast(ray, out hitInfo))
        {
            transform.position = hitInfo.point;
        }
        else
        {
            transform.position = ray.origin + ray.direction * 100000.0f;
        }
    }
}
