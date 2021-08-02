using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    private int numOfItem;
    public int clearcondition = 5;
    public GameObject textobject;
    private Text ClearText;
    private AudioSource successAudio;

    void Awake()
    {
        successAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        int layer = collider.gameObject.layer;
        if(layer == 9)
        {
            numOfItem++;
            Debug.Log(numOfItem);
            if(numOfItem == clearcondition)
            {
                textobject.SetActive(true);
                ClearText = textobject.GetComponentInChildren<Text>() as Text;
                ClearText.text = "¼º°ø!";
                successAudio.Play();
                StartCoroutine(GoNextLevel());
            }
        }
        else
        {
            return;
        }
    }

    IEnumerator GoNextLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
