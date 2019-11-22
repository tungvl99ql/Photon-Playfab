using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class bomb : Photon.MonoBehaviour
{
    public GameObject boom1,boom2,boom3,boom4;
    public GameObject boomN,boomD;
    void Start()
    {
        StartCoroutine(booom());
    }

    IEnumerator booom()
    {
        if (photonView.isMine)
        {
            yield return new WaitForSeconds(2);
            PhotonNetwork.Instantiate(this.boomD.name,new Vector2(boom1.transform.position.x - 4.5f, boom2.transform.position.y -0.5f),Quaternion.identity,0);
            PhotonNetwork.Instantiate(this.boomD.name, new Vector2(boom2.transform.position.x - 7, boom2.transform.position.y - 0.5f), Quaternion.identity, 0);
            PhotonNetwork.Instantiate(this.boomN.name, new Vector2(boom2.transform.position.x -3.8f, boom2.transform.position.y -3.5f), Quaternion.identity, 0);
            PhotonNetwork.Instantiate(this.boomN.name, new Vector2(boom3.transform.position.x - 4f, boom2.transform.position.y - 0.5f), Quaternion.identity, 0);
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
