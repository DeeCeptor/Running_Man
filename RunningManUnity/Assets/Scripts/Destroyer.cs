﻿using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("Runner"))
        {
            //Destroy(gameObject);
        }
    }
}
