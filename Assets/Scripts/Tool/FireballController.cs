using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector2 direction = Vector2.right;


    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {

    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Animator>().SetBool("isBreak", true);
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //Destroy(collision.gameObject);
            StartCoroutine(Wait(collision));

        }
        if (collision.gameObject.tag == "Grid" || collision.gameObject.tag == "Ci")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Wait(Collision2D collision)
    {
        yield return new WaitForSeconds(0.0001f);
        Destroy(collision.gameObject);
    }
}
