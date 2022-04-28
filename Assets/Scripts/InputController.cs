using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    public event Action PressedConfirm = delegate { };
    public event Action PressedCancel = delegate { };
    public event Action PressedLeft = delegate { };
    public event Action PressedRight = delegate { };
    public event Action PressedUp = delegate { };
    public event Action PressedDown = delegate { };

    void Update()
    {
        DetectConfirm();
        DetectCancel();
        DetectLeft();
        DetectRight();
        DetectUp();
        DetectDown();

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ExitLevel();
        }
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void DetectRight()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            PressedRight?.Invoke();
        }
    }

    private void DetectLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PressedLeft?.Invoke();
        }
    }

    private void DetectCancel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PressedCancel?.Invoke();
        }
    }

    private void DetectConfirm()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PressedConfirm?.Invoke();
        }
    }

    private void DetectUp()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PressedUp?.Invoke();
        }
    }

    private void DetectDown()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PressedDown?.Invoke();
        }
    }

}
