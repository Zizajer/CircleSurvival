using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBomb : Bomb
{
    private BombTimer bombTimer;

    public override void OnMouseDown()
    {
        Destroy(gameObject);
        Destroy(bombTimer.gameObject);
    }

    public void SetBombTimer(BombTimer bT,float timeToExplode)
    {
        bombTimer = bT;
        bombTimer.SetTimer(timeToExplode);
    }
}
