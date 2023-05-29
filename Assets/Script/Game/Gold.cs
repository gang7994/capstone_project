using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public Text GoldText;
    public int amount = 1000;
    AudioSource getCoin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            amount += 1000;
            GoldText.text = amount.ToString();
            getCoin.Play();

        }
    }
}
