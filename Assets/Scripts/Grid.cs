using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int RowsCount;
    public int ColumnsCount;
    public Tile[,] tiles;
    public GridSpawner gridSpawner;

    private void Start()
    {
        tiles = gridSpawner.SpawnGrid(RowsCount, ColumnsCount,transform);
    }

    public Tile GetFreeTile()
    {
        Tile randomFreeTile;
        bool isFreeTileFounded = false;

        do{
            randomFreeTile = tiles[Random.Range(0, RowsCount), Random.Range(0, ColumnsCount)];
            if (!randomFreeTile.isBombSetted)
                isFreeTileFounded = true;
        } while (!isFreeTileFounded);

        return randomFreeTile;
    }
}