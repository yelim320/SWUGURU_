using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingDialogueInStage1 : MonoBehaviour
{
    public Text dialogueText;
    public Dialogue dialogue;

    public Animator animator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        StartCoroutine(WaitTime());
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetTrigger("Ending");
        Debug.Log("�ִϸ��̼�");

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    
    void EndDialogue()
    {
        animator.SetBool("Ending", false);
    }
    
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2f);
        StartDialogue(dialogue);
    }
}
