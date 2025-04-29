using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float timeToCollect = 5f;
    public PowerupEffect powerupEffect;
    // void Ontrigger(Collider collision)
    // {
    //     // check here for player/enemy
    //     // while(collision.gameObject.tag == "Player")
    //     // {
        
    //     // }
    //     Debug.Log("hp++");
    //     powerupEffect.Apply(collision.gameObject);
    //     Destroy(gameObject);
        
    // }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            powerupEffect.Apply(collision.gameObject);
            Destroy(gameObject);
        }
        Destroy(gameObject,timeToCollect);
    }

}

