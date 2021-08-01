using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2_OvenClose : MonoBehaviour
{
    public GameObject re_Open;


    private void OnMouseDown()
    {

        gameObject.SetActive(false);
        re_Open.SetActive(true);

    }
}
