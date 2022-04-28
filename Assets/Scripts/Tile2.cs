using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile2 : MonoBehaviour
{
    public int type;
    public Material[] costumes;
    public string[] labels;
    public bool walkable;
    public GameObject occupier = null;
    //private GameObject currentcostume;
    public MeshRenderer renderer;

    public void Initialize(int newType, bool newWalkable)
    {
        type = newType;
        walkable = newWalkable;
        renderer.material = costumes[type];

    }

    public void Change(int newType, bool newWalkable)
    {
        type = newType;
        walkable = newWalkable;
        //Destroy(currentcostume);
        renderer.material = costumes[type];
    }

}
