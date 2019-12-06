using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2.9. BIT Masks
public class DoorManager : MonoBehaviour
{
    int doorType = 0;
    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.GetComponent<AttributeKeyManager>().attributes & doorType) == doorType)
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        this.GetComponent<BoxCollider>().isTrigger = false;
        other.gameObject.GetComponent<AttributeKeyManager>().attributes &= ~doorType;
    }

    private void Start()
    {
        //if (this.gameObject.tag == "MAGIC_DOOR") doorType = AttributeKeyManager.MAGIC;
        if (this.gameObject.tag == "MAGIC_DOOR") doorType = (AttributeKeyManager.MAGIC | AttributeKeyManager.INTELLIGENCE);
        if (this.gameObject.tag == "INT_DOOR") doorType = AttributeKeyManager.INTELLIGENCE;
        if (this.gameObject.tag == "FLY_DOOR") doorType = AttributeKeyManager.FLY;
        if (this.gameObject.tag == "INV_DOOR") doorType = AttributeKeyManager.INVISIBLE;
        if (this.gameObject.tag == "CHA_DOOR") doorType = AttributeKeyManager.CHARISMA;
    }
}
