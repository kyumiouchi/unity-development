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
        long bitboard = 10101;
        CellCount(bitboard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    long SetCellState(long bitboard, int row, int col)
    {
        long newBit = 1L << (row * 8 + col);
        return (bitboard |= newBit);
    }

    bool GetCellState(long bitboard, int row, int col)
    {
        long mask = 1L << (row * 8 + col);
        return ((bitboard & mask) != 0);
    }

    int CellCount(long bitboard)
    {
        int count = 0;
        long bb = bitboard;

        while (bb != 0)
        {
            bb &= bb - 1;
            Debug.Log(Convert.ToString(bb, 2).PadLeft(64, '0') + " count " + count);
            //print("bb " +bb+ " count "+ count);
            count++;
        }
        return count;
    }
}
