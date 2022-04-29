using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip menuTrack;
    private AudioSource Audio;
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        Audio.clip = menuTrack;
        Audio.loop = true;
        Audio.Play();
    }


}
