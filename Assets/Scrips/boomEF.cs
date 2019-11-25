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

    

}
