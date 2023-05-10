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


    float stack;
    Vector3 direction;
    public float speed;
    bool isFire;

    void Start(){
        //Invoke("DestroyBullet", 1);
        if(property_type == "Fire") gameObject.GetComponent<MeshRenderer>().material = Fire;
        else if(property_type == "Lightning") gameObject.GetComponent<MeshRenderer>().material = Lightning;
        else if(property_type == "Ice") gameObject.GetComponent<MeshRenderer>().material = Ice;
        else if(property_type == "Earth") gameObject.GetComponent<MeshRenderer>().material = Earth;
        else gameObject.GetComponent<MeshRenderer>().material = Normal;
        stack = 1.0f;
        transform.position += new Vector3(0, 0.5f, 0);

    }

    public void fire(Vector3 dir,bool gun)
    {
        direction = new Vector3(dir.x, 0, dir.z);
        isFire = true;
        if (gun)
        {
            Destroy(gameObject, 5f);
        }
        else
        {
            Destroy(gameObject, 1f);
        }
        
    }

    void Update()
    {
        if (isFire)
        {
            transform.Translate(direction *  GameObject.Find("Main Camera").GetComponent<Elemental>().character_BulletSpeed * Time.deltaTime);
        }
    }


}
