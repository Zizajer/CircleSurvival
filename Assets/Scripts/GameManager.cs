using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Grid Grid;
    public BombSpawner BombSpawner;
    public float MinimumTimeToSpawnABomb;
    public float MaximumTimeToSpawnABomb;

    private void Start()
    {
        Invoke("SpawnABombOnFreeTile", Random.Range(MinimumTimeToSpawnABomb, MaximumTimeToSpawnABomb));
    }

    public void SpawnABombOnFreeTile()
    {
        Tile freeTile = Grid.GetFreeTile();
        BombSpawner.SpawnBomb(freeTile.transform.position);
        freeTile.isBombSetted = true;

        Invoke("SpawnABombOnFreeTile", Random.Range(MinimumTimeToSpawnABomb, MaximumTimeToSpawnABomb));
    }
}
