using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabAuth : MonoBehaviour
{
    public static PlayfabAuth instance;

    LoginWithPlayFabRequest loginRequest;
    RegisterPlayFabUserRequest Request;

    public InputField username;
    public InputField password;
    public InputField email;
    public Text message;
    public string MyPlayfabID;
    public bool isAuthenticated;

    public string usernameGET;

    private void Awake()
    {
        MakeInstance();
    }
    private void Start()
    {
        email.gameObject.SetActive(false);
    }


    public void login()
    {
        loginRequest = new LoginWithPlayFabRequest();
        loginRequest.Username = username.text;
        loginRequest.Password = password.text;
        
        PlayFabClientAPI.LoginWithPlayFab(loginRequest, 
          result => 
          {
              MpManager.instance.ConnectToMaster();
              message.text = "wellcom " + username.text;
              isAuthenticated = true;
              Debug.Log("login");
              //======================//
          }
        , error => 
        {
            message.text = "login fail,create account";
            isAuthenticated = false;
            Debug.Log(error.ErrorMessage);
            email.gameObject.SetActive(true);
        },null);
    }

    public void register()
    {
        Request = new RegisterPlayFabUserRequest();
        Request.Username = username.text;
        Request.Password = password.text;
        Request.Email = email.text;

        PlayFabClientAPI.RegisterPlayFabUser(Request,
          result =>
          {
              message.text = "created account" ;
          }
        , error =>
        {
            message.text = error.ErrorMessage;
        }, null);
    }


   public void GetAccountInfo()
    {
        GetAccountInfoRequest request = new GetAccountInfoRequest();
        request.Username = username.text;
        PlayFabClientAPI.GetAccountInfo(request, Successs, fail);
    }
    void Successs(GetAccountInfoResult result)
    {
        MyPlayfabID = result.AccountInfo.Username;
        Debug.Log(MyPlayfabID);
    }
    void fail(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }




    














    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
