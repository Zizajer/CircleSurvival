using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTimer : MonoBehaviour
{
    public void SetTimer(float timeToExplode)
    {
        Destroy(gameObject, timeToExplode);

        GetComponent<Animation>()["RedBombFillAnimation"].speed = 1 / timeToExplode;
    }
}
