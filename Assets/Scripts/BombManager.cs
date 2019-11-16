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
        float timeToExplode = Random.Range(MinimumTimeToExplode, MaximumTimeToExplode);

        Bomb spawnedBlackBomb = SpawnAndInitializeBomb(freeTile, BlackBombToSpawn, timeToExplode);

        SpawnAndActivateBombTimer(spawnedBlackBomb, timeToExplode);
    }

    private void SpawnGreenBomb(Tile freeTile)
    {
        float timeToExplode = Random.Range(MinimumTimeToExplode, MaximumTimeToExplode);

        Bomb spawnedGreenBomb = SpawnAndInitializeBomb(freeTile, GreenBombToSpawn, timeToExplode);

        SpawnAndActivateBombTimer(spawnedGreenBomb, timeToExplode);
    }

    public void ExplodeAllActiveBombs()
    {
        foreach (Bomb bomb in FindObjectsOfType<Bomb>())
        {
            GameObject createdExplosionEffect = Instantiate(ExplosionEffect, 
                    bomb.transform.position, 
                    bomb.transform.rotation);
            Destroy(bomb.gameObject);
            Destroy(createdExplosionEffect, 
                    createdExplosionEffect.GetComponent<ParticleSystem>().main.duration);
        }
    }

    private Bomb SpawnAndInitializeBomb(Tile freeTile, Bomb bombToSpawn,float timeToExplode)
    {
        Bomb createdGreenBomb = Instantiate(bombToSpawn,
               freeTile.transform.position,
               freeTile.transform.rotation);

        createdGreenBomb.TileOnWhichIsBomb = freeTile;
        createdGreenBomb.StartCountdown(timeToExplode);

        return createdGreenBomb;
    }

    private BombTimer SpawnAndActivateBombTimer(Bomb bomb,float timeToExplode)
    {
        BombTimer bombTimer = Instantiate(BombTimerToSpawn,
                bomb.transform.position,
                bomb.transform.rotation,
                FindObjectOfType<Canvas>().transform);

        bomb.SetBombTimer(bombTimer, timeToExplode);

        return bombTimer;
    }
}
