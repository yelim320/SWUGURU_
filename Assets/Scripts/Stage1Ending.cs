using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage1Ending : MonoBehaviour
{
    private int numOfItem;
    public int clearcondition = 4;
    public GameObject endingManager;
    public GameObject textobject;
    private Text ClearText;
    public GameObject endingDialogue;
    private AudioSource successAudio;
    private GameObject player;
    public Transform livPos;
    public Transform kitPos;
    private bool clearStage1 = false;

    public GameObject table;
    public GameObject equip;
    public GameObject making;
    public GameObject bowlwith;
    //public AudioSource makingSound;

    void Awake()
    {
        successAudio = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (clearStage1)
        {
            endingDialogue.SetActive(false);
            bowlwith.transform.position = player.transform.position;
            player.transform.position = Vector3.MoveTowards(player.transform.position, livPos.position, 5 * Time.deltaTime);
            StartCoroutine(MoveToKit());
            StartCoroutine(GoNextLevel());
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        int layer = collider.gameObject.layer;
        if (layer == 9)
        {
            numOfItem++;
            //Debug.Log(numOfItem);
            if (numOfItem == clearcondition)
            {
                textobject.SetActive(true);
                ClearText = textobject.GetComponentInChildren<Text>() as Text;
                ClearText.text = "¼º°ø!";
                successAudio.Play();
                textobject.SetActive(true);
                StartCoroutine(makingDough());
                StartCoroutine(completeDough());
                StartCoroutine(ReadyToGo());
            }
        }
        else
        {
            return;
        }
    }

    IEnumerator makingDough()
    {
        yield return new WaitForSeconds(1.9f);
        equip.SetActive(false);
        table.SetActive(true);
        making.SetActive(true);
        //makingSound.Play();
    }

    IEnumerator completeDough()
    {
        yield return new WaitForSeconds(5f);
        making.SetActive(false);
        bowlwith.SetActive(true);
        endingManager.SetActive(true);
    }

    IEnumerator ReadyToGo()
    {
        PlayerMove.cantControl = true;
        yield return new WaitForSeconds(10f);
        clearStage1 = true;
        player.transform.position = new Vector3(-4, -3.5f, -1);
    }

    IEnumerator MoveToKit()
    {
        yield return new WaitForSeconds(2f);
        player.transform.position = Vector3.MoveTowards(player.transform.position, kitPos.position, 10 * Time.deltaTime);
    }

    IEnumerator GoNextLevel()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
