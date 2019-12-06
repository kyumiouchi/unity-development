using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bitwise Operators
// Bitwise AND (&)
// e.g. 1011 & 0011 = 0011
// 1 & 1 = 1
// 1 & 0 = 0
// 0 & 0 = 0
// exerc: 1001 & 1111 = 1001

// Bitwise OR (|)
// e.g. 1001 & 1111 = 1111
// 1 | 1 = 1
// 1 | 0 = 1
// 0 | 0 = 0
// exerc: 1101 & 1101 = 1101

// Bitwise XOR (^) -> Exclusive OR
// e.g. 1111 & 1101 = 0010
// 1 ^ 1 = 0
// 1 ^ 0 = 1
// 0 ^ 0 = 0
// exerc: 1010 ^ 1101 = 0111

// Bitwise NOT (~)
// e.g. ~1010 = 0101
// ~ 1 = 0
// ~ 0 = 1
// exerc: ~1110 = 0001

//Setting Flags
public class BitFlagsAndBitwiseOperators : MonoBehaviour
{
    bool hasMagic = true;
    bool hasIntelligence = false;
    bool hasCharisma = true;
    bool canFly = false;
    bool isInvisible = false;

    static public int MAGIC = 16;
    static public int INTELLIGENCE = 8;
    static public int CHARISMA = 4;
    static public int FLY = 2;
    static public int INVISIBLE = 1;

    int attibutes = MAGIC | CHARISMA;  // MAGIC + CHARISMA

    void Start()
    {
        attibutes |= INTELLIGENCE;//Setting Flags
        attibutes &= ~MAGIC; //Unsetting Flags
        if (hasMagic && hasIntelligence)
        {
            Debug.Log("Spell");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
