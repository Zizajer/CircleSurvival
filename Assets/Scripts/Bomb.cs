using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bomb : MonoBehaviour
{
    public bool IsDetonable;
    public Tile TileOnWhichIsBomb;

    public void StartCountdown(float timeToMethod)
    {
        if(IsDetonable)
            Invoke("Detonate", timeToMethod);
        else
            Invoke("Vanish", timeToMethod);
    }

    public virtual void Detonate()
    {
        FindObjectOfType<GameManager>().EndGame();
    }

    public void Vanish()
    {
        Destroy(gameObject);
    }

    public abstract void OnMouseDown();

}
