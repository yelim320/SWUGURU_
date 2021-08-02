using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MomMove : MonoBehaviour
{
    public enum MomState
    {
        Idle,
        Move,
        Return,
        Wait,
        Detect,
        HitWatch
    }

    public static MomState momState;

    public GameObject player;
    public GameObject door;
    public GameObject door_Open;

    public GameObject madMommy;
    public GameObject drowsyMommy;

    public Transform Target1;
    public Transform Target2;

    public float findDistance = 2f;
    public float moveSpeed = 10;
    public float MoveTime = 0.15f;

    float currentTime = 0;
    float WaitTime = 5f;

    public GameObject momgage;
    private Animator animator;

    public GameObject textobject;
    private Text ClearText;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        momState = MomState.Idle;

        /*madMommy = GameObject.Find("madmommy");
        drowsyMommy = GameObject.Find("drowsyMommy");

        //�÷��̾� 
        player = GameObject.Find("Player");
        door = GameObject.Find("DoorToMom");
        door_Open = GameObject.Find("DoorToMom_open");*/

        animator = momgage.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (momState)
        {
            case MomState.Idle:
                Idle();
                break;

            case MomState.Move:
                Move();
                break;

            case MomState.Return:
                Return();
                break;

            case MomState.Wait:
                Wait();
                break;

            case MomState.Detect:
                Detect();
                break;

            case MomState.HitWatch:
                HitWatch();
                break;

        }
    }

    void Idle()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= MoveTime)
        {
            currentTime = 0;
            momState = MomState.Move;
            madMommy.SetActive(false);
            drowsyMommy.SetActive(false);
        }
    }

    void Move()
    {
        door.SetActive(false);
        door_Open.SetActive(true);

        transform.position = Vector3.MoveTowards(transform.position, Target2.position, moveSpeed * Time.deltaTime);
         if (Vector3.Distance(player.transform.position, transform.position) <= findDistance)
         {
            StartCoroutine(Waiting());
            momState = MomState.Detect;
        }

        if (Vector3.Distance(Target2.position, transform.position) == 0)
        {
            momState = MomState.Wait;
            print("Move > Wait");
        }
        

    }

    void Return()
    {
        StartCoroutine(Waiting());

        transform.position = Vector3.MoveTowards(transform.position, Target1.transform.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(player.transform.position, transform.position) <= findDistance)
        {
            StartCoroutine(Waiting());
            momState = MomState.Detect;
        }

        if (Vector3.Distance(Target1.position, transform.position) == 0)
        {
            door.SetActive(true);
            door_Open.SetActive(false);
            momState = MomState.Idle;
        }

    }

    void Wait()
    {
        currentTime += Time.deltaTime;

        if (Vector3.Distance(player.transform.position, transform.position) <= findDistance)
        {
            StartCoroutine(Waiting());
            momState = MomState.Detect;
        }

        if (currentTime >= WaitTime)
        {
            momState = MomState.Return;
            currentTime = 0;
        }
    }

    void Detect()
    {
        madMommy.SetActive(true);

        //��Ʈ����UI
        /*GameObject ggm = GameObject.Find("GageManager");
        GageManager gManager = ggm.GetComponent< GageManager > ();
        gManager.Setlevel(gManager.Getlevel() + 1);*/

        GageManager.gage++;
        //Debug.Log(gage);
        //animator.SetTrigger("level" + gage);
        Debug.Log("�ִϸ��̼� ����");
        if (GageManager.gage == 5)
        {
            textobject.SetActive(true);
            ClearText = textobject.GetComponentInChildren<Text>() as Text;
            ClearText.text = "GameOver";
            textobject.SetActive(false);
            gameOver.SetActive(true);
        }


        momState = MomState.Idle;
        door.SetActive(true);
        door_Open.SetActive(false);
        

    }

    void HitWatch()
    {
        drowsyMommy.SetActive(true);
        transform.position = Vector3.MoveTowards(transform.position, Target1.transform.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(player.transform.position, transform.position) <= findDistance)
        {
            //door.SetActive(true);
            //door_Open.SetActive(false);
            print("�Ѹ���");
            print("HitWat > Idle");
            momState = MomState.Idle;
        }
    }


    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(5f);
        player.transform.position = new Vector3(0, 0, 0);
        transform.position = Target1.transform.position;
    }

    public static int GageUp()
    {
        return GageManager.gage;
    }
}