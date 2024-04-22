using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomName;
    public GameObject lobbyPannel;

    public void OnclickCreateRoom()
    {
        if(!PhotonNetwork.IsConnected) return;
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(roomName.text, options, TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Creating Room Now");
        lobbyPannel.SetActive(true);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Creacion del room fallida");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
