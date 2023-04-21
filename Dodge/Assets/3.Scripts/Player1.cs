using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public Camera myCamera;
    public GameObject bullet;
    public Transform muzzlePosition;
    public Rigidbody playerRigidbody;

    public float speed = 8f;
    public float curShotDelay;
    public float maxShotDelay = 0.3f;

    enum City
    {
        Seoul,   // 0
        Daejun,  // 1
        Busan = 5,  // 5
        Jeju = 10   // 10
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        Fire();
        Move();

    }
    void FixedUpdate()
    {
        FreezeRotate();
    }
    void FreezeRotate()
    {

        //transform.rotation = Quaternion.identity;
        //transform.rotation = 
        playerRigidbody.angularVelocity = Vector3.zero;
    }
    void Move()
    {
        //  수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를 (xSpeed,0 , zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        playerRigidbody.velocity = newVelocity;
    }
    void Fire()
    {
        curShotDelay += Time.deltaTime;
        if (Input.GetMouseButton(0) == true && curShotDelay > maxShotDelay)
        {         
            GameObject intantBullet = Instantiate(bullet, muzzlePosition.position, muzzlePosition.rotation);
            curShotDelay = 0;
        }
    }

    void Look()
    {
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit; // ray선에서 무언가 충돌했을 때
        if (Physics.Raycast(ray, out raycastHit, 100))
        {
            Vector3 myVec = raycastHit.point - transform.position;
            Debug.DrawLine(myCamera.transform.position, raycastHit.point);
            Debug.Log(raycastHit.point + "목표");
            Vector3 correctVec = myVec + transform.position; // 플레이어가 이동시 과거의 위치에서 myVec보면 어긋남 수정필요
            correctVec.y = transform.position.y;
            transform.LookAt(correctVec);
        }
    }
}
