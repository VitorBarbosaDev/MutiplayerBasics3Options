using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomItem : MonoBehaviour
{
    public TMP_Text roomName;
    LobbyManager manager;

    private void Start()
    {
        manager = FindObjectOfType<LobbyManager>();
    }
    public void setRoomName(string _roomname)
    {
        roomName.text = _roomname;
    }

    public void onClickItem()
    {
        manager.JoinRoom(roomName.text);
    }
}

