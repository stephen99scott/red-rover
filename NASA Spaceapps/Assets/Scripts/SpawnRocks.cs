using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnRocks : MonoBehaviour
{
    public GameObject specialItem;
    public GameObject rover;
    public int num_items;
    public Vector2Int xbounds;
    public Vector2Int zbounds;
    System.Random random = new System.Random();

    void Start()
    {
        Generate();
    }

    void Generate()
    {
        for (int i = 0; i < num_items; i++)
        {
            float xpos = random.Next(xbounds[0], xbounds[1]);
            float zpos = random.Next(zbounds[0], zbounds[1]);
            GameObject item = Instantiate(specialItem) as GameObject;
            item.transform.position = new Vector3(xpos, -1000f, zpos);
        }
        
    }
}
