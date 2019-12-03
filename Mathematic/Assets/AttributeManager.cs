using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttributeManager : MonoBehaviour
{
    static public int MAGIC = 16;

    public Text attibuteDisplay;
    int attributes = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MAGIC")
        {
            attributes |= MAGIC;
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
