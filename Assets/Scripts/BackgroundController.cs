using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 tempVec = new Vector3();

    void LateUpdate()
    {
        tempVec.x = playerTransform.position.x;
        tempVec.y = this.transform.position.y;
        tempVec.z = this.transform.position.z;
        this.transform.position = tempVec;
    }
}
