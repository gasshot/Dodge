using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    public float speed = 8f;
    PlayerController playerController;
    GameManager gameManager;
    //PlayerController[] playerController;
    // Start is called before the first frame update
    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
        //playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //  수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal"); // -1 ~ +1
        //float xInput = Input.GetAxisRaw("Horizontal");  모두 정직하게 1
        float zInput = Input.GetAxis("Vertical");   // -1 ~ +1

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를 (xSpeed, 0f, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity; // 힘은 누적 speed * 60(1초당)
        FreezeRotate();
    }
    void FreezeRotate()
    {
        playerRigidbody.angularVelocity = Vector3.zero;
    }

    public void Die()
    {
        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();
        //playerController.enabled = false;
        gameManager.EndGame();

    }
}
