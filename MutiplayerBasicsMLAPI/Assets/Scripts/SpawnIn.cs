using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using System;

public class SpawnIn : NetworkBehaviour
{
    // Start is called before the first frame update
 

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
            NetworkManager.Singleton.StartHost();
        }

        if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
        if (GUILayout.Button("Server")) NetworkManager.Singleton.StartServer();
    }
}
