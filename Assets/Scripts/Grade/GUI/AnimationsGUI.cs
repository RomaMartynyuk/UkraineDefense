using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsGUI : MonoBehaviour
{
    Animator animator;
    bool animState = false;
    public void animShop()
    {
        animator = GetComponent<Animator>();
        animState = !animState;
        animator.SetBool("Hidden", animState);
    }
}
