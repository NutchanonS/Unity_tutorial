using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 8f;
    public Vector3 offset;

    Camera zoomCamera;
    float Default_fov;
    private void Start()
    {
        zoomCamera = GetComponent<Camera>();
        Default_fov = zoomCamera.fieldOfView;
    }
    void Update()
    {
        if (target == null) return;

        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (zoomCamera.fieldOfView > 1)
            {
                zoomCamera.fieldOfView -= 2;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (zoomCamera.fieldOfView < 100)
            {
                zoomCamera.fieldOfView += 2 ;
            }
        }
        if (Input.GetKey(KeyCode.Mouse2))
        {
            zoomCamera.fieldOfView = Default_fov;
        }
    }
}