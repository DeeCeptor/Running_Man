using UnityEngine;
using System.Collections;

public class BottomBar : MonoBehaviour
{
    public float damageOnHit = 100;
    public float heightReset = 100;
    void Start()
    {

    }


    void Update()
    {

    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Runner")
        {
            coll.gameObject.SendMessage("TakeHit", damageOnHit);
            coll.gameObject.transform.position += new Vector3(0, heightReset, 0);
        }
    }
}
