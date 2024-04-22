using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListMenu : MonoBehaviourPunCallbacks
{
    public Transform goContent;
    public RoomList roomList;
    private List<RoomList> listing = new List<RoomList>();
    public GameObject lobbyPanel;

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(true);
        goContent.DestroyChildren();
        
        listing.Clear();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomInfos)
    {
        foreach (RoomInfo info in roomInfos)
        {
            if (info.RemovedFromList)
            {
                int index = listing.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(listing[index].gameObject);
                    listing.RemoveAt(index);
                }
            }
            else
            {
                int index = listing.FindIndex(x => x.RoomInfo.Name == info.Name);

                if (index == -1)
                {
                    RoomList list = Instantiate(roomList, goContent);
                    if( list != null)
                    {
                        list.SetRoomInfo(info);
                        listing.Add(list);
                    }
                }
            }
        }
    }
}
