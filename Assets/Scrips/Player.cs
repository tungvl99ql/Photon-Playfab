using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class Player : Photon.PunBehaviour
{
    float dirX, dirY;
    public TextMesh text;
    public GameObject BombPrefab;
    public float Health;
    public static Player instance;
    private void Awake()
    {
        MakeInstance();
        Health = 10;
    }
    void Start()
    {
        
        if (photonView.isMine)
        {
            text.text = PlayfabAuth.instance.MyPlayfabID;
            dirX = Input.GetAxis("Horizontal") * 5 * Time.deltaTime;
            dirY = Input.GetAxis("Vertical") * 5 * Time.deltaTime;
            transform.position = new Vector2(transform.position.x + dirX, transform.position.y + dirY);
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("hp :"+Health);

        if (photonView.isMine)
        {
            text.text = PlayfabAuth.instance.MyPlayfabID;
            dirX = Input.GetAxis("Horizontal") * 5 * Time.deltaTime;
            dirY = Input.GetAxis("Vertical") * 5 * Time.deltaTime;

            transform.position = new Vector2(transform.position.x + dirX, transform.position.y + dirY);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                PhotonNetwork.Instantiate(this.BombPrefab.name, this.transform.position, Quaternion.identity, 0);
            }
        }
        else
        {

        }
    }


    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
