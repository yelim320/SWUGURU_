using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutOfRoom : MonoBehaviour
{
    private LevelLoader levelLoader;
    public GameObject cam;

    private GameObject player;
    public GameObject livingRoomPos;
    public Animator transition;

    //��Ʈ�ѷ� ���� ��ũ��Ʈ ����



    private void Awake()
    {
        player = GameObject.Find("SWUNIE");

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("�浹");
        //�ִϸ��̼� �÷���
        transition.SetTrigger("Start");
        transition.SetTrigger("End");
        player.transform.position = new Vector3(-5, -3, -1);
        cam.transform.position = new Vector3(livingRoomPos.transform.position.x, livingRoomPos.transform.position.y, cam.transform.position.z);
    }

}
