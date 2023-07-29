using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera2 : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 2f;
    public float currentZoom = 1f;
    public float maxZoom = 3f;
    public float minZoom = 0.3f;
    private float X;
    private float Y;
    public float yawSpeed = 3.5f;
    public float zoomsensitive = 0.7f;
    float dst; // distance between Player and Camera
    float zoomSmooth;
    float targetZoom;

    void Start()
    {
        dst = offset.magnitude;
        transform.LookAt(target);
        targetZoom = currentZoom;
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel") * zoomsensitive;
        if (scroll != 0f)
        {
            targetZoom = Mathf.Clamp(targetZoom-scroll, minZoom, maxZoom);
        }
        currentZoom = Mathf.SmoothDamp(currentZoom, targetZoom, ref zoomSmooth, 0.15f);
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * yawSpeed, Input.GetAxis("Mouse X") * yawSpeed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }
    }
    private void LateUpdate()
    {
        transform.position = target.position - transform.forward * dst * currentZoom; 
        transform.LookAt(target.position);
   
    }

}
