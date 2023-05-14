using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletAtk;
    public string property_type;

    public Material Fire;
    public Material Lightning;
    public Material Ice;
    public Material Earth;
    public Material Normal;
    public int can_fierce;


    float stack;
    Vector3 direction;
    public float speed;
    bool isFire;

    void Start(){
        //Invoke("DestroyBullet", 1);
        if(property_type == "Fire") gameObject.GetComponent<TrailRenderer>().material = Fire;
        else if(property_type == "Lightning") gameObject.GetComponent<TrailRenderer>().material = Lightning;
        else if(property_type == "Ice") gameObject.GetComponent<TrailRenderer>().material = Ice;
        else if(property_type == "Earth") gameObject.GetComponent<TrailRenderer>().material = Earth;
        else gameObject.GetComponent<TrailRenderer>().material = Normal;
        stack = 1.0f;
        transform.position += new Vector3(0, 0.5f, 0);
        can_fierce = GameObject.Find("Main Camera").GetComponent<Elemental>().lightning_fierce;


    }

    public void fire(Vector3 dir,bool gun)
    {
        direction = new Vector3(dir.x, 0, dir.z);
        isFire = true;
        if (gun)
        {
            Destroy(gameObject, GameObject.Find("Main Camera").GetComponent<Elemental>().character_atkRange);
        }
        /*
        else
        {
            Destroy(gameObject, 1f);
        }
        */
        
    }

    void Update()
    {
        if (isFire)
        {
            transform.Translate(direction *  GameObject.Find("Main Camera").GetComponent<Elemental>().character_BulletSpeed * Time.deltaTime);
        }

    }


}
