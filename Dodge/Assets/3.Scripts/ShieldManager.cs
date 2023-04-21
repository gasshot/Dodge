using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public GameObject[] shieldObject;
    public GameObject playerObject;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerController = playerObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        ShieldView();
    }
    void ShieldView()
    {
        switch (playerController.curShield)
        {
            case 4:
                shieldObject[0].SetActive(true);
                shieldObject[1].SetActive(true);
                shieldObject[2].SetActive(true);
                shieldObject[3].SetActive(true);
                break;
            case 3:
                shieldObject[0].SetActive(true);
                shieldObject[1].SetActive(true);
                shieldObject[2].SetActive(true);
                shieldObject[3].SetActive(false);
                break;
            case 2:
                shieldObject[0].SetActive(true);
                shieldObject[1].SetActive(true);
                shieldObject[2].SetActive(false);
                shieldObject[3].SetActive(false);
                break;
            case 1:
                shieldObject[0].SetActive(true);
                shieldObject[1].SetActive(false);
                shieldObject[2].SetActive(false);
                shieldObject[3].SetActive(false);
                break;
            case 0:
                shieldObject[0].SetActive(false);
                shieldObject[1].SetActive(false);
                shieldObject[2].SetActive(false);
                shieldObject[3].SetActive(false);
                break;
        }
    }
}
