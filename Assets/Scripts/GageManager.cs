using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageManager : MonoBehaviour
{
    public static Animator animator;
    public static int gage = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        gage = EndingManager.GageReset();
        gage = MomMove.GageUp();
        if (gage != 0)
        {
            animator.SetTrigger("level" + gage);
        }

    }
}
