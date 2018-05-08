using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour {

    private Vector3 movementVelocity;
    [Range(0.0f, 5.0f)]
    public float overTime = 0.5f;
    public Transform _parent;
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _parent.position-new Vector3(0.1f,0f,0f), ref movementVelocity, overTime);
        transform.LookAt(_parent.position - new Vector3(0.1f, 0f, 0f));
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
