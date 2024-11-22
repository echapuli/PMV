using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public Transform objetivo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(objetivo);
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(objetivo.position.x, transform.position.y, transform.position.z);
    }
}
