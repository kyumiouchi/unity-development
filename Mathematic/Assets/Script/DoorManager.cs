using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2.9. BIT Masks
public class DoorManager : MonoBehaviour
{
    int doorTyoe = AttributeManager.MAGIC;
    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.GetComponent<AttributeManager>().attributes & doorTyoe) != 0)
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    void OnTriggerExit(Collision collision)
    {
        this.GetComponent<BoxCollider>().isTrigger = false;
    }
}
