using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip _startingSong;
    void Start()
    {
        if (_startingSong != null)
        {
            AudioHelper.PlayClip2D(_startingSong, 1f);
        }
    }


}
