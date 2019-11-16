using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBomb : Bomb
{
    public override void OnMouseDown()
    {
        FindObjectOfType<GameManager>().EndGame();
    }

    private void OnDestroy()
    {
        TileOnWhichIsBomb.isBombSetted = false;
    }
}
