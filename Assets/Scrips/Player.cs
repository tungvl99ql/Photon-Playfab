using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using UnityEngine.UI;

public class Player : Photon.PunBehaviour
{
    float dirX, dirY;
    public TextMesh text;
    public GameObject BombPrefab;
    private float Health;
    public static Player instance;
    public Text HpDisplay;
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
        HpDisplay.GetComponentInParent<Text>().text = "HP PLAYER : " + Health.ToString();

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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bom")
        {
            if (photonView.isMine)
            {
                photonView.RPC("Damge", PhotonTargets.All);
            }
        }
    }

    [PunRPC]
    void Damge()
    {
        Health -= 5;
    }

    public virtual void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.isWriting)
        {
            stream.SendNext(Health);
        }else if(stream.isReading)
        {
            Health = (float)stream.ReceiveNext();
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
