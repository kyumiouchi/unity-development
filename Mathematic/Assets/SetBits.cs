using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetBits : MonoBehaviour
{
    //int bSequence = 8 + 1;
    // Start is called before the first frame update
    static string A = "110111";
    static string B = "10001";
    static string C = "1101";

    int aBits = Convert.ToInt32(A, 2);
    int bBits = Convert.ToInt32(B, 2);
    int cBits = Convert.ToInt32(C, 2);

    int packet = 0;
    void Start()
    {
        //Debug.Log(Convert.ToString(bSequence, 2));

        packet = packet | (aBits << 26);
        packet = packet | (aBits << 21);
        packet = packet | (aBits << 17);

        Debug.Log(Convert.ToString(packet, 2).PadLeft(32, '0'));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
