using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CH
{
    public class Quit : MonoBehaviour
    {
        public void doquit()
        {
            Debug.Log("Has quit game.");
            Application.Quit();
        }
    }
}
