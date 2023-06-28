using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class AnimationChanger : MonoBehaviour
{
    private Animator animator;
    private bool isRun = false;
    private bool isTargeting = false;
    
    private int ANIMATOR_RUN = Animator.StringToHash("Run"); 
    private int ANIMATOR_TARGETING = Animator.StringToHash("Targeting"); 
    
    void Start()
    {
        animator = GetComponent<Animator>();
        SetRun(false);
        SetTargeting(false);
    }

    public void ToggleRun()
    {
        SetRun(!isRun);
    }

    public void SetRun(bool val)
    {
        isRun = val;
        animator.SetBool(ANIMATOR_RUN, isRun);
    }

    public void ToggleTargeting()
    {
        SetTargeting(!isTargeting);
    }

    void SetTargeting(bool val)
    {
        isTargeting = val;
        animator.SetBool(ANIMATOR_TARGETING, isTargeting);
    }
}
