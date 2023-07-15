using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 targetOffset;
    [SerializeField]
    private float movementspeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, movementspeed * Time.deltaTime);
    }
}
