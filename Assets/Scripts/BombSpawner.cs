using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GreenBomb GreenBombToSpawn;
    public GameObject BombTimer;
    public BlackBomb BlackBombToSpawn;
    public float MinimumTimeToExplode;
    public float MaximumTimeToExplode;

    public void SpawnBomb(Vector3 position)
    {
       float possibility = Random.Range(0, 100);
        if (possibility <= 10)
            SpawnBlackBomb(position);
        else
            SpawnGreenBomb(position);

    }

    //Refactor to one spawn method

    private void SpawnBlackBomb(Vector3 position) 
    {
        BlackBomb createdBlackBomb = Instantiate(BlackBombToSpawn,
                new Vector3(position.x, position.y, 0),
                new Quaternion(0, 0, 0, 0));

        createdBlackBomb.StartCountdown(Random.Range(MinimumTimeToExplode, MaximumTimeToExplode));
    }

    private void SpawnGreenBomb(Vector3 position)
    {
        float timeToExplode = Random.Range(MinimumTimeToExplode, MaximumTimeToExplode);

        GreenBomb createdGreenBomb = Instantiate(GreenBombToSpawn,
                    new Vector3(position.x, position.y, 0),
                    new Quaternion(0, 0, 0, 0));


        createdGreenBomb.StartCountdown(timeToExplode);

        GameObject bombTimer = Instantiate(BombTimer,
                    new Vector3(position.x, position.y, 0),
                    new Quaternion(0, 0, 0, 0),
                    FindObjectOfType<Canvas>().transform);

        //bombTimer.GetComponent<Animator>();
    }
}
