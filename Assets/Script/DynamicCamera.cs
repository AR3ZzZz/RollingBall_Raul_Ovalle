using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    [SerializeField] Transform target1;
    [SerializeField] Transform target2;
    [SerializeField] float CameraDistance;
    [SerializeField] float CameraHeight;
    [SerializeField] float smooth;
    

    void LateUpdate()
    {
        if (target1 == null || target2 == null) return;
        {
            Vector3 middlePoint = (target1.position + target2.position) / 2;
            Vector3 cameraPos = middlePoint+ new Vector3 (0, CameraHeight, CameraDistance);
            transform.position = target1.position;
            transform.position = Vector3.Lerp(transform.position, cameraPos, smooth);
            transform.LookAt(middlePoint);
        } 
    }
}
