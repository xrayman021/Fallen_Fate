using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour, IBuffable
{
    [SerializeField] MeshRenderer _renderer = null;
    [SerializeField] Color _initialColor = Color.green;
    [SerializeField] Color _buffColor = Color.red;

    void Awake()
    {
        _renderer.material.color = _initialColor;
    }

    public void Buff()
    {
        Debug.Log("!Buff Feedback!");
        _renderer.material.color = _buffColor;
    }

    public void Unbuff()
    {
        Debug.Log("...Unbuff Feedback...");
        _renderer.material.color = _initialColor;
    }

}
