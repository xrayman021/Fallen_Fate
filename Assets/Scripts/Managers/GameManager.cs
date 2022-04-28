using UnityEngine;
using UnityEngine.SceneManagement;

namespace CH
{
    public class GameManager : MonoBehaviour
    {
        public PlayerStats playerStats;
        public SceneLoader sceneLoader;
        [SerializeField] AudioClip backgroundTrack;
        private AudioSource Audio;

        // Start is called before the first frame update
        void Start()
        {
            //playerStats = GetComponent<PlayerStats>();
            //sceneLoader = FindObjectOfType<SceneLoader>();
            Audio = GetComponent<AudioSource>();
            Audio.clip = backgroundTrack;
            Audio.loop = true;
            Audio.Play();
        }

        // Update is called once per frame
        void Update()
        {
            if(playerStats.isDead)
            {
                GameOver();
            }
        }

        public void GameOver()
        {
            sceneLoader.ReloadLevel();
            SceneManager.LoadScene("MainMenu");
        }
    }
}
