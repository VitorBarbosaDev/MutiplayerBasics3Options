using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : NetworkBehaviour
{


    [SerializeField] private NavMeshAgent agent = null;


    private Camera mainCamera;

        #region server
    [Command]
    private void CmdMove(Vector3 positon)
    {
        if (!NavMesh.SamplePosition(positon,out NavMeshHit hit,1f,NavMesh.AllAreas)) { return; }

        agent.SetDestination(hit.position);
    }
    #endregion


    #region Client
    public override void OnStartAuthority()
    {
        mainCamera = Camera.main;
        base.OnStartAuthority();
    }
    
    [ClientCallback]
    private void Update()
    {
        if (!hasAuthority){return; }

        if (!Input.GetMouseButton(1)) { return; }

       Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

       if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)){ return; }
        CmdMove(hit.point);
    }




    #endregion

}
