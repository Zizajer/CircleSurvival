using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bomb : MonoBehaviour
{
    public string OnTimeEndedMethod;
    
    public void StartCountdown(float timeToMethod)
    {
        Invoke(OnTimeEndedMethod, timeToMethod);
    }

    public virtual void Detonate()
    {
        FindObjectOfType<GameManager>().EndGame();
        Destroy(gameObject);
    }

    public void Vanish()
    {
        Destroy(gameObject);
    }

    public abstract void OnMouseDown();

}
