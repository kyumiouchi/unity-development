using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttributeKeyManager : MonoBehaviour
{
    static public int MAGIC = 16;
    static public int INTELLIGENCE = 8;
    static public int CHARISMA = 4;
    static public int FLY = 2;
    static public int INVISIBLE = 1;

    public Text attributeDisplay;
    public int attributes = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MAGIC")
        {
            attributes |= MAGIC;
            Destroy(other.gameObject);
        } else if (other.gameObject.tag == "INTELLIGENCE")
        {
            attributes |= INTELLIGENCE;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "CHARISMA")
        {
            attributes |= CHARISMA;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "INVISIBLE")
        {
            attributes |= INVISIBLE;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "FLY")
        {
            attributes |= FLY;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "ADD")
        {
            attributes |= (MAGIC | INTELLIGENCE | CHARISMA | INVISIBLE | FLY);
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attributeDisplay.transform.position = screenPoint + new Vector3(0, -50, 0);
        attributeDisplay.text = Convert.ToString(attributes, 2).PadLeft(8, '0');
    }
}
