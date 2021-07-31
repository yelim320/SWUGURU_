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

    public GameObject momgage;
    private Animator animator;
    int gage = 0;

    public GameObject textobject;
    private Text ClearText;


    // Start is called before the first frame update
    void Start()
    {
        momState = MomState.Idle;

        //플레이어 
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
                Return();
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
        transform.position = Vector3.MoveTowards(transform.position, Target1.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(player.transform.position, transform.position) <= findDistance)
        {

            momState = MomState.Detect;
        }


        if (Vector3.Distance(Target1.position, transform.position) == 0)
        {
            momState = MomState.Wait;
            print("무브에서 웨이트");

        }

    }

    void Return()
    {

        transform.position = Vector3.MoveTowards(transform.position, Target2.transform.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(player.transform.position, transform.position) <= findDistance)
        {
            print("리턴에서 디텍트");
            momState = MomState.Detect;
        }

        if (Vector3.Distance(Target2.position, transform.position) == 0)
        {
            print("리턴에서 아이들");
            momState = MomState.Idle;
        }

    }

    void Wait()
    {
        currentTime += Time.deltaTime;

        if (Vector3.Distance(player.transform.position, transform.position) <= findDistance)
        {
            print("웨이트에서 디텍트");
            momState = MomState.Detect;
        }

        if(currentTime == 5)
        {
            currentTime = 0;
            print("웨이트에서 리턴");
            momState = MomState.Return;
        }
    }

    void Detect()
    {
        StartCoroutine(Waiting());
        //애니메이션
        momState = MomState.Idle;
        print("무브에서 아이들");
        player.transform.position = new Vector3(0, 0, 0);
        transform.position = Target1.transform.position;
        //하트감소UI
        /*GameObject ggm = GameObject.Find("GageManager");
        GageManager gManager = ggm.GetComponent< GageManager > ();
        gManager.Setlevel(gManager.Getlevel() + 1);*/

        print("하트 하나 감소");
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