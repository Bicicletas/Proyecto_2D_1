using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifeTime = 1;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
