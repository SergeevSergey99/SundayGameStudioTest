using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DefaultAndroidButtonHandler : MonoBehaviour
{
    [SerializeField] UnityEvent onBackButtonPressed;
    [SerializeField] UnityEvent onHomeButtonPressed;
    [SerializeField] UnityEvent onMenuButtonPressed;
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBackButtonPressed();
        }
        else if (Input.GetKeyDown(KeyCode.Menu))
        {
            OnMenuButtonPressed();
        }
        else if (Input.GetKeyDown(KeyCode.Home))
        {
            OnHomeButtonPressed();
        }
    }
    
    public void OnBackButtonPressed()
    {
        onBackButtonPressed.Invoke();
    }
    
    public void OnHomeButtonPressed()
    {
        onHomeButtonPressed.Invoke();
    }
    
    public void OnMenuButtonPressed()
    {
        onMenuButtonPressed.Invoke();
    }
    
}
