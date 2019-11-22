using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MpManager : Photon.MonoBehaviour
{
    public static MpManager instance;
    public string gameversion;
    public Text ConnectState;
    public PlayfabAuth playfab;
    public GameObject[] DisalbeOnConnected;
    public GameObject[] EnalbeOnConnected; 
    public GameObject[] DisalbeOnJoinedRoom;
    public GameObject playerPrefab1, playerPrefab2;
    public int changePlayerSkin ;

    private void Awake()
    {
        MakeInstance();
    }

    private void Update()
    {
        Debug.Log(changePlayerSkin);
    }
    private void FixedUpdate()
    {
        ConnectState.text = PhotonNetwork.connectionStateDetailed.ToString();
    }

    public void ConnectToMaster()
    {
        PhotonNetwork.ConnectUsingSettings(gameversion);
    }

    public virtual void OnConnectedToMaster()
    {
        foreach(GameObject disable in DisalbeOnConnected)
        {
            disable.SetActive(false);
        }
        foreach (GameObject enable in EnalbeOnConnected)
        {
            enable.SetActive(true);
        }
    }

    public void CreateOrJoin()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public virtual void OnPhotonRandomJoinFailed()
    {
        RoomOptions room = new RoomOptions
        {
            MaxPlayers = 10,
            IsVisible = true
        };
        int randomIDroom = Random.Range(0, 100);
        PhotonNetwork.CreateRoom("Room : " + randomIDroom, room, TypedLobby.Default);
    }


    public virtual void OnJoinedRoom()
    {
        foreach (GameObject disalbe in DisalbeOnJoinedRoom)
        {
            disalbe.SetActive(false);
        }

            if (changePlayerSkin == 1 || changePlayerSkin == 0)
            {
                PhotonNetwork.Instantiate(this.playerPrefab1.name, Vector3.zero, Quaternion.identity, 0);
            }
            if (changePlayerSkin == 2)
            {
                PhotonNetwork.Instantiate(this.playerPrefab2.name, Vector3.zero, Quaternion.identity, 0);
            }


        PlayfabAuth.instance.GetAccountInfo();
    }

    public void changeP1()
    {
        changePlayerSkin = 1;
    }
    public void changeP2()
    {
        changePlayerSkin = 2;
    }




















    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
