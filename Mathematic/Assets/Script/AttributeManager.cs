using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttributeManager : MonoBehaviour
{
    static public int MAGIC = 16;
    static public int INTELLIGENCE = 8;
    static public int CHARISMA = 4;
    static public int FLY = 2;
    static public int INVISIBLE = 1;

    public Text attibuteDisplay;
    public int attributes = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MAGIC")
        {
            attributes |= MAGIC;
        }
        else if (other.gameObject.tag == "INTELLIGENCE")
        {
            attributes |= INTELLIGENCE;
        }
        else if (other.gameObject.tag == "CHARISMA")
        {
            attributes |= CHARISMA;
        }
        else if (other.gameObject.tag == "FLY")
        {
            attributes |= FLY;
        }
        else if (other.gameObject.tag == "INVISIBLE")
        {
            attributes |= INVISIBLE;
        }
        else if (other.gameObject.tag == "ANTMAGIC")
        {
            attributes &= ~MAGIC; // 2.8 Turning Bit Flags Off
        }
        else if (other.gameObject.tag == "REMOVE")
        {
            attributes &= ~(INTELLIGENCE | MAGIC); // 2.8 Turning Bit Flags Off
        }
        else if (other.gameObject.tag == "ADD")
        {
            attributes &= ~(INTELLIGENCE | MAGIC | CHARISMA); // 2.8 Turning Bit Flags Off
        }
        else if (other.gameObject.tag == "RESET")
        {
            attributes = 0; // 2.8 Turning Bit Flags Off
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attibuteDisplay.transform.position = screenPoint + new Vector3(0, -50, 0);
        attibuteDisplay.text = Convert.ToString(attributes, 2).PadLeft(8, '0');
    }
}
