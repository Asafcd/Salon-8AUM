using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Realtime;

public class PlayerList : MonoBehaviour
{
    public TextMeshProUGUI textinfo;
    public Player Player {get; private set;}
    
    public void SetPlayerInfo(Player playerInfo)
    {
        Player = playerInfo;
        textinfo.text = playerInfo.NickName;
    }
}
