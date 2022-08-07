using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerMove : MonoBehaviour
{
    public  float speed = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

        if(h != 0.0f || v != 0.0f)
        {
            Vector3 dir = h * Vector3.right + v * Vector3.forward;
            transform.rotation = Quaternion.LookRotation(dir);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            GetComponent<Animator>().SetBool("isMove", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isMove", false);
        }
        
    }
}
