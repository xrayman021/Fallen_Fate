using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CH
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] AudioClip backgroundTrack;
        private AudioSource Audio;

        // Start is called before the first frame update
        void Start()
        {
            Audio = GetComponent<AudioSource>();
            Audio.clip = backgroundTrack;
            Audio.loop = true;
            Audio.Play();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
