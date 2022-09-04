using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public int damage;
    void Start(){
        //Invoke("DestroyBullet", 1);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * 0.05f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Map")
            DestroyRock();
        else if (collision.gameObject.tag == "Monster")
            DestroyRock();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Map")
            DestroyRock();
        else if (other.gameObject.tag == "Monster")
            DestroyRock();
    }

    void DestroyRock(){
        Destroy(gameObject);
    }
}
