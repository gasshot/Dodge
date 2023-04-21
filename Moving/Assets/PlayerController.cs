using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody myRigidbody;
    public Camera myCamera;
    //GameObject myGameObject;
    public float mySpeed  = 8f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Looking();
        Move();
    }

    void Move()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        myRigidbody.velocity = moveVec * mySpeed;
    }
    void Looking()
    {
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, 100))
        {
            Vector3 myVec = raycastHit.point - transform.position;
            Debug.DrawLine(myCamera.transform.position, raycastHit.point, Color.blue);
            Vector3 correctVec = myVec + transform.position;
            Vector3 drawForVec = new Vector3(transform.position.x, 0, transform.position.z);
            Debug.DrawLine(drawForVec , raycastHit.point, Color.red);
            correctVec.y = transform.position.y;
            transform.LookAt(correctVec);
        }
    }
}

