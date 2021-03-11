using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PawnAiming : MonoBehaviour
{
    public float aimDuration = 0.3f;
    public float aimFOV = 20f;

    [SerializeField]
    float turnSpeed = 15f;
    [SerializeField]
    Rig rigLayer;

    Camera mainCamera;
   

    void Start()
    {
        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, yawCamera, 0f), turnSpeed * Time.deltaTime);

        if (rigLayer)
            rigLayer.weight = 1f;
    }  
}
