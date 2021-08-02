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
            Debug.Log(numOfItem);
            if (numOfItem == clearcondition)
            {
                textobject.SetActive(true);
                ClearText = textobject.GetComponentInChildren<Text>() as Text;
                ClearText.text = "����!";
                successAudio.Play();
                textobject.SetActive(true);
                endingManager.SetActive(true);
                StartCoroutine(MoveToLiv());
            }
        }
        else
        {
            return;
        }
    }

    IEnumerator MoveToLiv()
    {
        PlayerMove.cantControl = true;
        yield return new WaitForSeconds(4f);
        clearStage1 = true;
        player.transform.position = new Vector3(4, -3, -1);
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