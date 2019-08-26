using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TC_OFController : MonoBehaviour
{
    [Header("Mouse Drag Related Variables")]
    private bool onObject = false;
    public Vector3 origP = new Vector3();
    public Vector3 origPos = new Vector3();
    private Vector3 v3OrgMouse;
    public string father = null;

    [Header("Raycast")]
    public Ray ray;
    public RaycastHit hit;

    // Awake, Start & Update
    void Awake()
    {
        origPos = transform.position;
        origP = origPos;
    }
    void Start()
    {

    }
    void Update()
    {
        if(TC_GameStateMachine.gsm.ags == TC_GameStateMachine.GameSM.WAITING_ANSWER) MouseTest();
    }

    void MouseTest()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.Equals(transform.gameObject))
            {
                onObject = true;
                transform.position = hit.point;
            }
            return;
        }

        if (Input.GetMouseButton(0) && onObject == true)
        {
            var VecT = ray.origin;
            VecT.z = transform.position.z;
            transform.position = VecT;
            return;
        }

        if (Input.GetMouseButtonUp(0) && onObject == true)
        {
            onObject = false;
            transform.localPosition = origPos;
        }
    }
}
