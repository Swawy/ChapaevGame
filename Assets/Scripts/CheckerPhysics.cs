using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerPhysics : MonoBehaviour {

    public Rigidbody rb;
    private bool isPressed = false;
    public float releaseTime = 1.5f;

    void Update()
    {
        if (isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }      
    }

    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
    }
}
