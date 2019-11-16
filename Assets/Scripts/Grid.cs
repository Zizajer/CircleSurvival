using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int RowsCount;
    public int ColumnsCount;
    public Tile[,] Tiles;
    public GridSpawner GridSpawner;

    private void Start()
    {
        Tiles = GridSpawner.SpawnGrid(RowsCount, ColumnsCount,transform);
    }

    public Tile GetFreeTile()
    {
        Tile randomFreeTile;
        bool isFreeTileFounded = false;

        do{
            randomFreeTile = Tiles[Random.Range(0, RowsCount), Random.Range(0, ColumnsCount)];
            if (!randomFreeTile.IsBombSetted)
                isFreeTileFounded = true;
        } while (!isFreeTileFounded);

        return randomFreeTile;
    }
}