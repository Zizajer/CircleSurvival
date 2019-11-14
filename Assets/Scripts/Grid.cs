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


}