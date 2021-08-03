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

    //컨트롤러 삽입 스크립트 삽입



    private void Awake()
    {
        player = GameObject.Find("Player");

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("충돌");
        //애니메이션 플레이
        transition.SetTrigger("Start");
        transition.SetTrigger("End");
        player.transform.position = new Vector3(-11, -3, -1);
        cam.transform.position = new Vector3(livingRoomPos.transform.position.x, livingRoomPos.transform.position.y, cam.transform.position.z);
    }

}
