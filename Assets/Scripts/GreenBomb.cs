using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBomb : Bomb
{
    private BombTimer bombTimer;

    public override void OnMouseDown()
    {
        TileOnWhichIsBomb.isBombSetted = false;
        Destroy(gameObject);
    }

    public void SetBombTimer(BombTimer bT,float timeToExplode)
    {
        bombTimer = bT;
        bombTimer.SetTimer(timeToExplode);
    }

    private void OnDestroy()
    {
        if(bombTimer != null)
            Destroy(bombTimer.gameObject);
    }
}
