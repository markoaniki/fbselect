using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TC_CubeRotation : MonoBehaviour
{
    [Header("Rotation Variables")]
    private Vector3 previousRot = Vector3.zero;
    private Vector3 rotPosDelta = Vector3.zero;
    public float speedM = .5f;

    [Header("Original rotation value")]
    public Quaternion oRot;
    private bool onObject = false;

    [Header("Raycast")]
    public Ray ray;
    public RaycastHit hit;

    [Header("AudioFiles")]
    public AudioSource asource;
    public AudioClip keyClick;

    public static TC_CubeRotation tc = null;

    // Start & Update
    void Start()
    {
        if (tc == null) tc = this;
        oRot = transform.rotation;
    }
    void Update()
    {
        if (TC_GameStateMachine.gsm.ags == TC_GameStateMachine.GameSM.WAITING_ANSWER) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.Equals(this.gameObject))
                {
                    onObject = true;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                onObject = false;
            }

            if (Input.GetMouseButton(0) && onObject == true)
            {
                rotPosDelta = (Input.mousePosition - previousRot) * speedM;
                if (Vector3.Dot(transform.up, Vector3.up) >= 0)
                {
                    transform.Rotate(transform.up, -Vector3.Dot(rotPosDelta, Camera.main.transform.right), Space.World);
                }
                else
                {
                    transform.Rotate(transform.up, Vector3.Dot(rotPosDelta, Camera.main.transform.right), Space.World);
                }

                transform.Rotate(Camera.main.transform.right, Vector3.Dot(rotPosDelta, Camera.main.transform.up), Space.World);
            }

            previousRot = Input.mousePosition;
        }
    }

    public void ResetRotation()
    {
        DelaytillPlay(keyClick);
        transform.rotation = oRot;
    }

    public void DelaytillPlay(AudioClip aud)
    {
        Debug.Log("Start");
        asource.clip = aud;
        asource.Play();
        Debug.Log("End");
    }
}
