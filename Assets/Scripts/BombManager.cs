using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public GreenBomb GreenBombToSpawn;
    public BombTimer BombTimerToSpawn;
    public BlackBomb BlackBombToSpawn;
    public GameObject ExplosionEffect;
    public float MinimumTimeToExplode;
    public float MaximumTimeToExplode;

    public void SpawnBomb(Tile freeTile)
    {
       float possibility = Random.Range(0, 100);
        if (possibility <= 10)
            SpawnBlackBomb(freeTile);
        else
            SpawnGreenBomb(freeTile);
    }

    //Refactor to one spawn method

    private void SpawnBlackBomb(Tile freeTile) 
    {
        BlackBomb createdBlackBomb = Instantiate(BlackBombToSpawn,
                freeTile.transform.position,
                freeTile.transform.rotation);

        createdBlackBomb.TileOnWhichIsBomb = freeTile;
        createdBlackBomb.StartCountdown(Random.Range(MinimumTimeToExplode, MaximumTimeToExplode));
    }

    private void SpawnGreenBomb(Tile freeTile)
    {
        float timeToExplode = Random.Range(MinimumTimeToExplode, MaximumTimeToExplode);

        GreenBomb createdGreenBomb = Instantiate(GreenBombToSpawn,
                freeTile.transform.position,
                freeTile.transform.rotation);

        createdGreenBomb.TileOnWhichIsBomb = freeTile;
        createdGreenBomb.StartCountdown(timeToExplode);

        BombTimer bombTimer = Instantiate(BombTimerToSpawn,
                freeTile.transform.position,
                freeTile.transform.rotation,
                FindObjectOfType<Canvas>().transform);

        createdGreenBomb.SetBombTimer(bombTimer,timeToExplode);
    }

    public void ExplodeAllActiveBombs()
    {
        foreach (Bomb bomb in FindObjectsOfType<Bomb>())
        {
            Instantiate(ExplosionEffect, bomb.transform.position, bomb.transform.rotation);
            Destroy(bomb.gameObject);
        }
    }
}
