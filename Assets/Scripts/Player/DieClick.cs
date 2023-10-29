using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieClick : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = transform.parent.gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.gameObject.tag == "Grid")
        {
            Destroy(gameObject);
            anim.SetBool("isAlive", false);
            // Destroy(transform.parent.gameObject);
        }
    }
}
