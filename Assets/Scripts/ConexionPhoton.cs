using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class ConexionPhoton : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI txtConection;
    void Start()
    {
        StartConnection();
    }
    public void StartConnection()
    {
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = "Test" + Random.Range(0, 999);
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public override void OnConnectedToMaster()
    {
        txtConection.text = "Conexion Exitosa";
        txtConection.color = Color.green;
        
        if(!PhotonNetwork.InLobby) PhotonNetwork.JoinLobby();
            
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        txtConection.text = "Desconectado: " + cause.ToString();
        txtConection.color = Color.red;
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Lobby");
    }
}
