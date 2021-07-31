using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage2 : MonoBehaviour
{
    GameObject point;
    public float distanceToPoint;
    public float successRange = 10f;

    public float t = 1f; // speed
    public float l = 10f; // 왕복거리
    public float posX = 1f; // 중심

    public GameObject textobject;
    private Text ClearText;

    public GameObject momgage;
    private Animator animator;
    int gage = 0;

    // Start is called before the first frame update
    void Start()
    {
        point = GameObject.Find("Point");
        animator = momgage.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(posX + Mathf.PingPong(t * Time.time, l), 4, -0.3f);
        transform.position = pos;

        if (Input.GetButtonDown("Jump"))
        {
            distanceToPoint = Vector3.Distance(transform.position, point.transform.position);

            if(distanceToPoint <= successRange)
            {
                //print("성공");
                textobject.SetActive(true);
                ClearText = textobject.GetComponentInChildren<Text>() as Text;
                ClearText.text = "Stage2 성공!";
                StartCoroutine(GoNextLevel());
            }
            else
            {
                //print("실패");
                //엄마 게이지 올라가기
                gage++;
                animator.SetTrigger("level" + gage);
                if (gage == 5)
                {
                    animator.SetTrigger("level" + gage);
                    textobject.SetActive(true);
                    ClearText = textobject.GetComponentInChildren<Text>() as Text;
                    ClearText.text = "GameOver";
                }
            }
        }
    }

    IEnumerator GoNextLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(4);
    }
}
