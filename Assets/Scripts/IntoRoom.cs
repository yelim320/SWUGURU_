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

    //컨트롤러 삽입 스크립트 삽입

    private void Awake()
    {
        player = GameObject.Find("SWUNIE");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("충돌");
        transition.SetTrigger("Start");
        transition.SetTrigger("End");
        player.transform.position = new Vector3(-3, -1, -1);
        cam.transform.position = new Vector3(myRoomPos.transform.position.x, myRoomPos.transform.position.y, cam.transform.position.z);
    }

}
