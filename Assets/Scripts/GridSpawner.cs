﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public float offset;
    public Tile TileToSpawn;

    public Tile[,] SpawnGrid(int rowsCount, int columnsCount,Transform startingPoint)
    {
        Tile[,] tiles = new Tile[rowsCount, columnsCount];
        for (int x = 0; x < rowsCount; x++)
        {
            for (int y = 0; y < columnsCount; y++)
            {
                tiles[x, y] = Instantiate(TileToSpawn,
                    new Vector3(startingPoint.position.x + (x * offset), startingPoint.position.y + (y * offset), 0),
                    new Quaternion(0, 0, 0, 0),
                    startingPoint);
            }
        }

        return tiles;
    }
}
