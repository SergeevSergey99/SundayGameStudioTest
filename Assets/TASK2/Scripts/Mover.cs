using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] private float rotatingSpeed = 1;
    [SerializeField] private float maxRotating = 1;

    private bool isRun = false;
    private float rotating = 0;

    private AnimationChanger animationChanger;
    private void Start()
    {
        animationChanger = GetComponent<AnimationChanger>();
    }

    public void AddRotating(float val)
    {
        rotating += val;
        rotating = Mathf.Clamp(rotating, -maxRotating, maxRotating);
    }
    public void SetIsRun(bool val)
    {
        isRun = val;
        if (animationChanger != null)
        {
            animationChanger.SetRun(val);
        }
    }

    public void ToggleRun()
    {
        SetIsRun(!isRun);
    }

    private void Update()
    {
        if (rotating != 0)
        {
            transform.RotateAround(Vector3.up, rotating * rotatingSpeed * Time.deltaTime);
        }
        if (isRun)
        {
            transform.Translate(transform.worldToLocalMatrix.MultiplyVector(transform.forward) * Time.deltaTime * speed);
        }
    }
}
