using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class boomEF : Photon.PunBehaviour
{
    
    void Start()
    {
        Destroy(this.gameObject, 0.3f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Player.instance.Health -= 5;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Player"))
        {
            Player.instance.Health -= 5;
            Debug.Log(collision.gameObject.tag);
        }
    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (photonView.isMine)
    //    {
    //        if (other.gameObject.tag == "Player")
    //        {
    //            Player.instance.Health -= 5;
    //            Debug.Log("detected :" + other.tag);
    //        }
    //    }
    //}

}
