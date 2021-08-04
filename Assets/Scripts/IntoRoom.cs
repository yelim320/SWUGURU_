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

    private AudioSource door;

    //��Ʈ�ѷ� ���� ��ũ��Ʈ ����

    private void Awake()
    {
        player = GameObject.Find("Player");
        door = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("�浹");
        door.Play();
        transition.SetTrigger("Start");
        transition.SetTrigger("End");
        player.transform.position = new Vector3(-7, -3, -1);
        cam.transform.position = new Vector3(myRoomPos.transform.position.x, myRoomPos.transform.position.y, cam.transform.position.z);

    }
}
