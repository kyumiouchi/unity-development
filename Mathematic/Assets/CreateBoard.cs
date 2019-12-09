using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CreateBoard : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject housePrefab;
    public GameObject treePrefab;

    public Text score;
    GameObject[] tiles;
    long dirtBB = 0;
    long treeBB = 0;
    long playerBB = 0;
    long desertBB = 0;

    // Start is called before the first frame update
    void Start()
    {
        tiles = new GameObject[64];
        for(int row = 0; row < 8; row++)
        {
            for(int colum = 0; colum < 8; colum++)
            {
                int randomTile = UnityEngine.Random.Range(0, tilePrefabs.Length);
                Vector3 pos = new Vector3(colum, 0, row);
                // Quaternion.identity means zero rotation
                GameObject tile = Instantiate(tilePrefabs[randomTile], pos, Quaternion.identity);
                tile.name = tile.tag + "_" + row + "_" + colum;
                tiles[row * 8 + colum] = tile;
                if(tile.tag == "Dirt")
                {
                    dirtBB = SetCellState(dirtBB, row, colum);
                }
                else if (tile.tag == "Desert")
                {
                    desertBB = SetCellState(desertBB, row, colum);
                }
            }
        }
        Debug.Log("Dirt cell = " + CellCount(dirtBB));
        Debug.Log("Desert cell = " + CellCount(desertBB));
        InvokeRepeating("PlantTree",1 ,1);
    }
    void PlantTree()
    {
        int randowRow = UnityEngine.Random.Range(0, 8);
        int randowCol = UnityEngine.Random.Range(0, 8);
        if(GetCellState(dirtBB & ~playerBB, randowRow, randowCol))
        {
            GameObject tree = Instantiate(treePrefab);
            tree.transform.parent = tiles[randowRow * 8 + randowCol].transform;
            tree.transform.localPosition = Vector3.zero;
            treeBB = SetCellState(treeBB, randowRow, randowCol);
        }
    }

    void PrintBB(string name, long BB)
    {
        Debug.Log(name + ": " + Convert.ToString(BB, 2).PadLeft(64, '0'));
    }

    long SetCellState(long bitboard, int row, int colum)
    {
        long newBIt = 1L << (row * 8 + colum);
        return (bitboard |= newBIt);
    }

    bool GetCellState(long bitboard, int row, int colum)
    {
        long mask = 1L << (row * 8 + colum);
        return ((bitboard & mask) != 0);
    }

    int CellCount(long bitboard)
    {
        int count = 0;
        long bb = bitboard;
        while (bb != 0)
        {
            bb &= bb - 1;
            count++;
        }
        return count;
    }
    void CalculateScore()
    {
        score.text = "Score: " + (CellCount(dirtBB & playerBB) * 10 + CellCount(desertBB & playerBB) * 2);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                int rowHit = (int)hit.collider.gameObject.transform.position.z;
                int colHit = (int)hit.collider.gameObject.transform.position.x;
                if(GetCellState((dirtBB & ~treeBB) | desertBB, rowHit, colHit))
                {
                    GameObject house = Instantiate(housePrefab);
                    house.transform.parent = hit.collider.gameObject.transform;
                    house.transform.localPosition = Vector3.zero;
                    playerBB = SetCellState(playerBB, rowHit, colHit);
                    CalculateScore();
                }
            }
        }
    }
}
