using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoRoom : MonoBehaviour
{
    private LevelLoader levelLoader;
    public GameObject cam;

    private GameObject player;
    public GameObject myRoomPos;
    public Animator transition;

    //��Ʈ�ѷ� ���� ��ũ��Ʈ ����

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("�浹");
        transition.SetTrigger("Start");
        transition.SetTrigger("End");
        player.transform.position = new Vector3(-8, -3, -1);
        cam.transform.position = new Vector3(myRoomPos.transform.position.x, myRoomPos.transform.position.y, cam.transform.position.z);
    }
}
