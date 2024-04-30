using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public GameObject targetObject;

    void Update()
    {
        Vector3 target = targetObject.transform.position; //Finds the position of the targetobject and stores the values in a vector3 called target
        //Vector3 target = transform.position + Vector3.forward; //The last part of the code3 on this line "Vector3.forward" you can change to any of the four N,S,E,W diractions, just change the .forward, .forward is the same as facing north

        Vector3 relativeTarget = transform.parent.InverseTransformPoint(target); //Finds the compasses relative target coordinates of the target

        float needleOrientation = Mathf.Atan2(relativeTarget.x, relativeTarget.z) * Mathf.Rad2Deg; //Calculates the rotation the needle needs with Atan2

        transform.localRotation = Quaternion.Euler(0, needleOrientation, 0); //Applies the needle rotation to the actual object in scene
    }
}
