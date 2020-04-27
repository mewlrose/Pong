using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public int ownerId;

    public void Init(int ownerId)
    {
        this.ownerId = ownerId;

        if (ownerId == 1){
            gameObject.transform.RotateAround(Vector3.up, Mathf.PI);
        }
    }

}
