using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bomb : MonoBehaviour
{
    public string OnTimeEndedMethod;
    
    public void StartCountdown(float timeToMethod)
    {
        Invoke("Vanish", timeToMethod);
    }

    public virtual void Detonate()
    {
        //TO-DO particle effect here 

        Destroy(gameObject);
    }

    public void Vanish()
    {
        Destroy(gameObject);
    }

    public abstract void OnMouseDown();

}
