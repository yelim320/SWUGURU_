using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage3Ending : MonoBehaviour
{
    private int numOfItem = 0;
    public int clearcondition = 4;
    public GameObject textobject;
    private Text ClearText;
    private AudioSource successAudio;
    private bool clearStage3 = false;

    public GameObject table;
    //public GameObject equip;
    public GameObject decorating;
    //public AudioSource decoratingSound;

    void Awake()
    {
        successAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (clearStage3)
        {
            StartCoroutine(GoNextLevel());
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        int layer = collider.gameObject.layer;
        if (layer == 9)
        {
            numOfItem++;
            if (numOfItem == clearcondition)
            {
                textobject.SetActive(true);
                ClearText = textobject.GetComponentInChildren<Text>() as Text;
                ClearText.text = "¼º°ø!";
                successAudio.Play();
                textobject.SetActive(true);
                StartCoroutine(makingCake());
            }
        }
        else
        {
            return;
        }
    }

    IEnumerator makingCake()
    {
        yield return new WaitForSeconds(1.9f);
        //equip.SetActive(false);
        table.SetActive(true);
        decorating.SetActive(true);
        //makingSound.Play();
        clearStage3 = true;
    }

    IEnumerator GoNextLevel()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
