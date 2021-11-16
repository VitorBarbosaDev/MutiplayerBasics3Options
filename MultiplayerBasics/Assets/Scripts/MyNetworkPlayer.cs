using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyNetworkPlayer : NetworkBehaviour
{

    [SerializeField] private TMP_Text displayNameText = null;
    [SerializeField] private Renderer displayColourRenderer =null;

    [SyncVar(hook = nameof(HandleTextUpdated))]
    [SerializeField]
    private string displayName = "Missing Name";

    [SyncVar(hook = nameof(HandleDisplayColourUpdated))]
    [SerializeField]
    private Color playerColor = Color.blue;



    #region Server


    [Server]
    public void SetDisplayName(string newDisplayName)
    { 
        displayName = newDisplayName;
    }

    [Server]
    public void SetDisplayColor(Color newColor)
    {
        playerColor = newColor;
    }


    [Command]
    private void CmdSetDisplayName(string newDisplayName)
    {
        if (newDisplayName.Length > 2 && newDisplayName.Length < 15)
        {

            RpcLogNewName(newDisplayName);

            SetDisplayName(newDisplayName);

        }
    }

    //[ContextMenu("Server Set THE NameS")]
    //private void ServersetMyName()
    //{
    //    RpcSetDisplayName("Server Has Set New Name");
    //}


    #endregion


    #region Client
    private void HandleDisplayColourUpdated(Color oldColour,Color newColour)
    {
        displayColourRenderer.material.SetColor("_BaseColor", newColour);
    }

    private void HandleTextUpdated(string oldtext, string newtext)
    {
        displayNameText.text = newtext;
    }


    [ContextMenu("Set My Name")]
    private void setMyName()
    {
        CmdSetDisplayName("MY New Name");
    }

    [ClientRpc]
    private void RpcLogNewName(string newDisplayName)
    {
        Debug.Log(newDisplayName);
    }




    #endregion
}
