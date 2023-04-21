using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    static float speed = 3f; // ź�� �̵� �ӷ�
    private Rigidbody bulletRigidbody; // �̵��� ����� ������ٵ� ������Ʈ
                                       // ������ٵ� ������Ʈ�� �浹 �޼����� �߻���Ų��
    //public GameObject gameObjectForCount;
    GameManager gameManagerForCount;
    GameObject gameObjectForCount;
    // Start is called before the first frame update
    void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        gameObjectForCount = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerForCount = gameObjectForCount.GetComponent<GameManager>();
        // ������ٵ��� �ӵ� = ���� ����  * �̵��ӷ�
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
        bulletRigidbody.velocity = transform.forward * speed;    //  ���� ���� ���� Vector3(0,0,1)
        //bulletRigidbody.velocity = new Vector3(0,0,1) * speed; //  ���� ���� ���� Vector3(0,0,1)

        // 3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
    void OnTriggerEnter(Collider other)
    {
        // �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (other.tag == "Player")
        {
            // ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            // �������κ��� PlayerController ������Ʈ�� �������� �� ������ ���
            if (playerController != null)
            {
                if (playerController.curShield != 0)
                {
                    playerController.curShield -= 1;
                }
                else if (playerController.curShield == 0)
                {
                    //playerController.curHealth -= 1;
                    // ���� PlayerController ������Ʈ�� Die() �޼��� ����
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
