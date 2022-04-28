using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingToken : MonoBehaviour, IBuffable
{
    [SerializeField] float _buffScaleIncrease = .5f;

    public void Buff()
    {
        transform.localScale = new Vector3(
            transform.localScale.x + _buffScaleIncrease,
            transform.localScale.y + _buffScaleIncrease,
            transform.localScale.z + _buffScaleIncrease
            );
    }

    public void Unbuff()
    {
        transform.localScale = new Vector3(
            transform.localScale.x + _buffScaleIncrease,
            transform.localScale.y + _buffScaleIncrease,
            transform.localScale.z + _buffScaleIncrease
            );
    }
}
