using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class launcher : MonoBehaviourPunCallbacks
{

    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text RoomNameText;
    void Start()
    {
        Debug.Log("cinnectecing master");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("cinnecteced master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        menuManager.instance.OpenMenu("title");
        Debug.Log("Joined LObbu");
    }
    
    public void CreateRoom()
    {
        if(string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        menuManager.instance.OpenMenu("loading");
    }
    public override void OnJoinedRoom()
    {
        menuManager.instance.OpenMenu("room");
        RoomNameText.text = PhotonNetwork.CurrentRoom.Name;
    }
    public override void OnCreateRoomFailed(short returnCode, string message) 
    {
        errorText.text = "room create fail:" + message;
        menuManager.instance.OpenMenu("error");
    }
}
