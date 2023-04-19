using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //  수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를 (xSpeed,0 , zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        playerRigidbody.velocity = newVelocity; // 힘은 누적 speed * 60(1초당)
    }


    public void Die()
    {
        gameObject.SetActive(false);
        playerController.enabled = false;
    }
}
