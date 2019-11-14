using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBomb : Bomb
{
    public override void OnMouseDown()
    {
        Vanish();

    }
}
