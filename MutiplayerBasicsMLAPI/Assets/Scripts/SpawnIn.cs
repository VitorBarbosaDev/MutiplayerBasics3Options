using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using System;
using MLAPI.Transports.UNET;

public class SpawnIn : NetworkBehaviour
{
    // Start is called before the first frame update
    public string ipAddress = "127.0.0.1";
    UNetTransport transport;

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if(!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            StartButtons();
        }

        GUILayout.EndArea();

      
    }

    private void StartButtons()
    {
        if (GUILayout.Button("Host"))
        {
            transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
            transport.ConnectAddress = ipAddress;
            NetworkManager.Singleton.StartHost();
        }

        if (GUILayout.Button("Client")) 
        {
            transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
            transport.ConnectAddress = ipAddress;
            NetworkManager.Singleton.StartClient();    
        }
        ipAddress = GUI.TextField(new Rect(10, 100, 200, 20), ipAddress, 50);

        if (GUILayout.Button("Server")) NetworkManager.Singleton.StartServer();
    }
}
