using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Player : NetworkBehaviour
{
    [SerializeField] private float rotationSpeed = 20f;

    private Camera playerCamera;

    private UseableObject useableObject;
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            this.playerCamera = GetComponentInChildren<Camera>();
        }
        else
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer)
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.position += this.transform.forward * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.transform.position += -1 * this.transform.forward * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.position += -1 * this.transform.right * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.position += this.transform.right * Time.deltaTime;
            }
            if (Input.GetMouseButton(0))
            {
                float rotationY = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
                Debug.Log(rotationY);

                Vector3 eulerAngles = this.transform.eulerAngles;
                Debug.Log(eulerAngles);

                eulerAngles.y += rotationY;

                this.transform.eulerAngles = eulerAngles;
            }
            if (Input.GetMouseButton(1) && this.useableObject)
            {
                //useableObject.CmdTriggerActive();
                this.CmdTriggerActive();
                //this.useableObject.CmdTriggerActive();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        this.useableObject = other.gameObject.GetComponent<UseableObject>();
    }

    private void OnTriggerExit()
    {
        this.useableObject = null;
    }

    /*private void OnTriggerStay(Collider other)
    {
        UseableObject useableObject = other.gameObject.GetComponent<UseableObject>();
        if (Input.GetMouseButton(1) && isLocalPlayer)
        {
            //useableObject.CmdTriggerActive();
            this.CmdTriggerActive(useableObject);
        }
    }*/

    [Command]
    public void CmdTriggerActive()
    {
        useableObject.Active();
    }
}
