using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MomMove : MonoBehaviour
{
    enum MomState
    {
        Idle,
        Move,
        Return,
        Wait,
        Detect
    }

    MomState momState;

    public GameObject player;
    public GameObject door;
    public GameObject door_Open;

    public Transform Target1;
    public Transform Target2;



    public float findDistance = 2f;

    public float moveSpeed = 10;

    float currentTime = 0;

    public float MoveTime = 0.2f;

    float WaitTime = 0.1f;

    public GameObject momgage;
    private Animator animator;

    public GameObject textobject;
    private Text ClearText;


    // Start is called before the first frame update
    void Start()
    {
        momState = MomState.Idle;

        //플레이어 
        /*player = GameObject.Find("Player");
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

        }
    }

    void Idle()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= MoveTime)
        {
            currentTime = 0;
            momState = MomState.Move;
            print("Idle -> move");
        }
    }

    void Move()
    {
        door.SetActive(false);
        door_Open.SetActive(true);

        transform.position = Vector3.MoveTowards(transform.position, Target2.position, moveSpeed * Time.deltaTime);
         if (Vector3.Distance(player.transform.position, transform.position) <= findDistance)
         { 
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
            print("Return > Detect");
            momState = MomState.Detect;
        }

        if (Vector3.Distance(Target1.position, transform.position) == 0)
        {
            door.SetActive(true);
            door_Open.SetActive(false);
            print("Return > Idle");
            momState = MomState.Idle;
        }

    }

    void Wait()
    {
        currentTime += Time.deltaTime;

        if (Vector3.Distance(player.transform.position, transform.position) <= findDistance)
        {
            print("Wait > Detect");
            momState = MomState.Detect;
        }

        if (currentTime >= WaitTime)
        {
            print("Wait> Return");
            momState = MomState.Return;
            currentTime = 0;
        }
    }

    void Detect()
    {
        StartCoroutine(Waiting());
        //애니메이션
        momState = MomState.Idle;
        print("디텍트에서 아이들");
        player.transform.position = new Vector3(0, 0, 0);
        transform.position = Target1.transform.position;
        //하트감소UI
        /*GameObject ggm = GameObject.Find("GageManager");
        GageManager gManager = ggm.GetComponent< GageManager > ();
        gManager.Setlevel(gManager.Getlevel() + 1);*/

        print("하트 하나 감소");
        GageManager.gage++;
        //Debug.Log(gage);
        //animator.SetTrigger("level" + gage);
        Debug.Log("애니메이션 실행");
        if (GageManager.gage == 5)
        {
            textobject.SetActive(true);
            ClearText = textobject.GetComponentInChildren<Text>() as Text;
            ClearText.text = "GameOver";
        }

        door.SetActive(true);
        door_Open.SetActive(false);
    }


    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(5f);
    }

    public static int GageUp()
    {
        return GageManager.gage;
    }
}