//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    Ray ray;
    public Camera myCamera;
    public Transform playerP;
    public float playerSpeed;
    Rigidbody myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {

        Looking();
        Move();
    }
    void Move()
    {
        Vector3 moveVec = new Vector3(Input.GetAxisRaw("Horizontal")*playerSpeed*Time.deltaTime, 0, Input.GetAxisRaw("Vertical")* playerSpeed*Time.deltaTime);

        myRigidbody.AddForce(moveVec);
    }
    void Looking()
    {
        ray = myCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, 100))
        {
            Vector3 myVec = raycastHit.point - transform.position;
            Debug.DrawLine(myCamera.transform.position, raycastHit.point);
            Debug.Log(raycastHit.point + "∏Ò«•");
            Vector3 correctVec = myVec + transform.position;
            correctVec.y = transform.position.y;
            transform.LookAt(correctVec);
        }
    }
}
