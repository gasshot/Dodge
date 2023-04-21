using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    static float speed = 3f; // 탄알 이동 속력
    private Rigidbody bulletRigidbody; // 이동에 사용할 리지드바디 컴포넌트
                                       // 리지드바디 컴포넌트는 충돌 메세지를 발생시킨다
    //public GameObject gameObjectForCount;
    GameManager gameManagerForCount;
    GameObject gameObjectForCount;
    // Start is called before the first frame update
    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        gameObjectForCount = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerForCount = gameObjectForCount.GetComponent<GameManager>();
        // 리지드바디의 속도 = 앞쪽 방향  * 이동속력
        if(gameManagerForCount.surviveTime>10f)
        {
            speed = 5f;
        }
        else if (gameManagerForCount.surviveTime > 20f)
        {
            speed = 7f;
        }
        else if (gameManagerForCount.surviveTime > 30f)
        {
            speed = 9f;
        }
        bulletRigidbody.velocity = transform.forward * speed;    //  지역 로컬 상의 Vector3(0,0,1)
        //bulletRigidbody.velocity = new Vector3(0,0,1) * speed; //  전역 로컬 상의 Vector3(0,0,1)

        // 3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 트리거 충돌 시 자동으로 실행되는 메서드
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Player")
        {
            // 상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            // 상대방으로부터 PlayerController 컴포넌트를 가져오는 데 성공한 경우
            if (playerController != null)
            {
                if (playerController.curShield != 0)
                {
                    playerController.curShield -= 1;
                }
                else if (playerController.curShield == 0)
                {
                    //playerController.curHealth -= 1;
                    // 상대방 PlayerController 컴포넌트의 Die() 메서드 실행
                    playerController.Die();
                }
            }
        }
        else if (other.tag == "Level")
        {
            Destroy(this.gameObject);
        }

    }
}
