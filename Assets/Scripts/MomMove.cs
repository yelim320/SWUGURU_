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

    GameObject player;

    public Transform Target1;
    public Transform Target2;



    public float findDistance = 2f;

    public float moveSpeed = 10;

    float currentTime = 0;

    public float MoveTime = 0.2f;

    float WaitTime = 0.1f;

    public GameObject momgage;
    private Animator animator;
    int gage = 0;

    public GameObject textobject;
    private Text ClearText;


    // Start is called before the first frame update
    void Start()
    {
        momState = MomState.Idle;

        //�÷��̾� 
        player = GameObject.Find("Player");

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
        //�ִϸ��̼�
        momState = MomState.Idle;
        print("����Ʈ���� ���̵�");
        player.transform.position = new Vector3(0, 0, 0);
        transform.position = Target1.transform.position;
        //��Ʈ����UI
        /*GameObject ggm = GameObject.Find("GageManager");
        GageManager gManager = ggm.GetComponent< GageManager > ();
        gManager.Setlevel(gManager.Getlevel() + 1);*/

        print("��Ʈ �ϳ� ����");
        /*gage++;
        animator.SetTrigger("level" + gage);
        if (gage == 5)
        {
            animator.SetTrigger("level" + gage);
            textobject.SetActive(true);
            ClearText = textobject.GetComponentInChildren<Text>() as Text;
            ClearText.text = "GameOver";
        }*/
    }


    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(5f);
    }


}