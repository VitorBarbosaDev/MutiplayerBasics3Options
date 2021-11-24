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
    public Animator PlayerAnim;
    public bool growb;

    // Start is called before the first frame update
    void Start()
    {
        // cam = Camera.main;
        cam = gameObject.GetComponentInChildren<Camera>();
         nav = transform.GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            Movement();
        }
        if (!IsLocalPlayer)
        {
            cam.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Grow();
        }

    }

    private void Movement()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out hit, 100) && hit.transform.tag == "Floor")
            {
                PlayerAnim.SetFloat("Speed", 1);
                nav.SetDestination(hit.point);
            }
        }
    }

    private void Grow()
    {
        if (growb == false)
        {
            growb = true;
            PlayerAnim.SetFloat("Speed", 0);
            PlayerAnim.SetBool("Grow", growb);
        }
        else 
        {
            growb = false;
            PlayerAnim.SetBool("Grow", growb);

        }
    }
}
