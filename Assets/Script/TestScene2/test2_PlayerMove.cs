using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class test2_PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    private bool is_top;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float v = CrossPlatformInputManager.GetAxisRaw("Vertical");
        float h1 = Input.GetAxisRaw("Horizontal");
        float v1 = Input.GetAxisRaw("Vertical");
        float shoot = Input.GetAxis("Fire2");
        is_top = GameObject.Find("Main Camera").GetComponent<BuildCamera>().isTopview;
        if ((h != 0.0f || v != 0.0f || h1 != 0.0f || v1 != 0.0f) && !is_top)
        {
            Vector3 dir = h * Vector3.right + v * Vector3.forward + h1 * Vector3.right + v1 * Vector3.forward;
            transform.rotation = Quaternion.LookRotation(dir);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            GetComponent<Animator>().SetBool("isMove", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isMove", false);
        }
        if (CrossPlatformInputManager.GetButton("Attack"))
        {
            GetComponent<Animator>().SetBool("isAttack", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isAttack", false);
        }
        if (shoot != 0)
        {
            GetComponent<Animator>().SetBool("isShoot", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isShoot", false);
        }
    }
}
