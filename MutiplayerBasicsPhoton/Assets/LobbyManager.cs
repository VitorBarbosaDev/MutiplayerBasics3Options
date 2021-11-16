using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomInput;
    public TMP_Text roomName;
    public GameObject lobbyPanel;
    public GameObject roomPanel;

    public RoomItem roomItemPrefab;

    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;

    public float timeBetweenUpdates = 1.5f;
        float nextUpdateTime;

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void OnclickCreate()
    {
        if (roomInput.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomInput.text,new RoomOptions() { MaxPlayers = 4 });
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name: "+PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= nextUpdateTime)
        {

            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdates;
        }
    }

    private void UpdateRoomList(List<RoomInfo> list)
    {
       foreach(RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach (RoomInfo room in list)
        {
          RoomItem newRoom =  Instantiate(roomItemPrefab,contentObject);
            newRoom.setRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }

    }


    public void JoinRoom(string roomname)
    {
        PhotonNetwork.JoinRoom(roomname);
    }

    public void onClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }


    public override void OnLeftRoom()
    {
        lobbyPanel.SetActive(true);
        roomPanel.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

}
