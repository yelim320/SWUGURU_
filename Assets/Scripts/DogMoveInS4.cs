using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMoveInS4 : MonoBehaviour
{
    public float t = 1f; // speed
    public float l = 10f; // �պ��Ÿ�
    public float posX = -18f; // �߽�

    public GameObject player;
    new Collider2D collider2D;
    float distanceToPlayer;
    bool isTouching = false;

    private AudioSource bowWow;

    public GameObject doghouse;
    public enum DogState
    {
        Idle,
        Move,
        GetSnack
    }

    public static DogState dogState;

    // Start is called before the first frame update
    void Start()
    {
        dogState = DogState.Move;
        bowWow = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (dogState)
        {
            case DogState.Idle:
                Idle();
                break;

            case DogState.Move:
                Move();
                break;

            case DogState.GetSnack:
                GetSnack();
                break;
        }
    }

    public void Idle()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (isTouching)
        {
            if (distanceToPlayer <= 5)
            {
                return;
            }

            OnTriggerEnter2D(collider2D);
            return;
        }
    }

    public void Move()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (isTouching)
        {
            if (distanceToPlayer <= 5)
            {
                return;
            }

            //Debug.Log("�浹����");

            OnTriggerEnter2D(collider2D);
            return;
        }

        Vector3 pos = new Vector3(posX + Mathf.PingPong(t * Time.time, l), 3.5f, -1);
        transform.position = pos;
    }

    public void GetSnack()
    {
        float disToDoghouse = Vector3.Distance(transform.position, doghouse.transform.position);

        if (disToDoghouse > 0.1)
        {
            Vector3 dirToDoghouse = doghouse.transform.position - transform.position;
            dirToDoghouse.Normalize();
            transform.position += dirToDoghouse * 5 * Time.deltaTime;
        }
        else
        {
            transform.position = doghouse.transform.position;
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        isTouching = true;
        if (distanceToPlayer > 5)
        {
            //Debug.Log("���");
            isTouching = false;
            return;
        }
        StartCoroutine(Bark());
    }

    IEnumerator Bark()
    {
        bowWow.Play();
        yield return new WaitForSeconds(1.0f);
    }
}