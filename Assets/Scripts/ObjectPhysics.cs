using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPhysics : MonoBehaviour {

    GameObject gameObjectWhite = GameObject.Find("CheckerWhite1");
    GameObject gameObjectBlack = GameObject.Find("CheckerBlack1");
    Transform thingToPull;

    int PushOn = 0;
    float smooth = 1.0f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.name == "CheckerWhite1")
        {
            thingToPull = hit.transform;
        }
    }

    private void Update()
    {

        //if (thingToPull != null)
        //{
        //    Vector3 D = transform.position - thingToPull; // line from crate to player
        //    float dist = D.magnitude;
        //    Vector3 pullDir = D.normalized; // short blue arrow from crate to player
        //    if (dist > 50) thingToPull = null; // lose tracking if too far
        //    else if (dist > 3)
        //    { // don't pull if too close
        //      // this is the same math to apply fake gravity. 10 = normal gravity
        //        float pullF = 10;
        //        // for fun, pull a little bit more if further away:
        //        // (so, random, optional junk):
        //        float pullForDist = (dist - 3) / 2.0f;
        //        if (pullForDist > 20) pullForDist = 20;
        //        pullF += pullForDist;
        //        // Now apply to pull force, using standard meters/sec converted
        //        //    into meters/frame:
        //        thingToPull.GetComponent<Rigidbody>().velocity += pullDir * (pullF * Time.deltaTime);
        //    }
        //}
        //if (Input.GetMouseButtonDown(1) && PushOn == 0)
        //{
        //    Vector3 dirWhite = transform.position - gameObjectBlack.transform.position;
        //    Vector3 dirBlack = transform.position - gameObjectWhite.transform.position;
        //    dirWhite.Normalize();
        //    dirBlack.Normalize();
        //    GetComponent<Rigidbody>().AddForce(dirWhite * Time.deltaTime);
        //    GetComponent<Rigidbody>().AddForce(dirBlack * Time.deltaTime);
        //    transform.position = Vector3.Lerp(transform.position, -gameObjectWhite.transform.position, 0);
        //}
        //if(Input.GetMouseButtonUp(1) && PushOn == 1)
        //{
        //    PushOn = 0;
        //}
    }
}
