using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1.0f;

    public void OpenIt()
    {
        StartCoroutine(Opening());
    }

    IEnumerator Opening()
    {
        transition.SetTrigger("Click");
        yield return new WaitForSeconds(transitionTime);
    }
}
