using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MLAPI;
using System;

public class PlayerController : NetworkBehaviour
{
    public NavMeshAgent nav;
    public Camera cam;
    private RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        nav = transform.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            Movement();
        }
    }

    private void Movement()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out hit, 100) && hit.transform.tag == "Floor")
            {
                nav.SetDestination(hit.point);
            }
        }
    }
}
