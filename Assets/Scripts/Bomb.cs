using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bomb : MonoBehaviour
{
    public float timeToDisapper;
    
    public void StartCountdown()
    {
        Invoke("Detonate", timeToDisapper);
    }

    public virtual void Detonate()
    {
        //TO-DO particle effect here 

        Destroy(gameObject);
    }

    public abstract void OnMouseDown();

}
