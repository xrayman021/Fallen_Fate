using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CH
{
    public class FallDeath : MonoBehaviour
    {
        public GameManager gameManager;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.name == "Player")
            {
                gameManager.GameOver();
            }
            
        }
    }
}
