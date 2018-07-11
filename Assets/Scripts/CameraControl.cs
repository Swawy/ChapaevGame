using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float speed = 0.2f;
    public float camSpeed = 0.2f;

    //private float mouseX = 0.0f;
    //private float mouseY = 0.0f;

    void Start () {
		
	}
	
	void Update () {

        if (Input.GetKey(KeyCode.G))
        {
            transform.Rotate(camSpeed,0,0);
        }
        if (Input.GetKey(KeyCode.T))
        {
            transform.Rotate(-camSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.H))
        {
            transform.Rotate(0, camSpeed, 0);
        }
        if (Input.GetKey(KeyCode.F))
        {
            transform.Rotate(0, -camSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(camSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-camSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, camSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -camSpeed);
        }

        //transform.Translate(camSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, camSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        
        //transform.position += (Vector3.up * vert + Vector3.right * horz) * speed * Time.deltaTime;
        //transform.eulerAngles = new Vector3(mouseY, mouseX, 0.0f);
    }
}
