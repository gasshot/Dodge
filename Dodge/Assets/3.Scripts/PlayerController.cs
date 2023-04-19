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
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� playerRigidbody�� �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>();
        //playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //  ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal"); // -1 ~ +1
        //float xInput = Input.GetAxisRaw("Horizontal");  ��� �����ϰ� 1
        float zInput = Input.GetAxis("Vertical");   // -1 ~ +1

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 �ӵ��� (xSpeed, 0f, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity; // ���� ���� speed * 60(1�ʴ�)
        FreezeRotate();
    }
    void FreezeRotate()
    {
        playerRigidbody.angularVelocity = Vector3.zero;
    }

    public void Die()
    {
        // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        // ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManager gameManager = FindObjectOfType<GameManager>();
        //playerController.enabled = false;
        gameManager.EndGame();

    }
}
