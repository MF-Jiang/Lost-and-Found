using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalIN : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerCtrl>().speed = 0;
            StartCoroutine(Wait(collision));
            
        }
    }

    IEnumerator Wait(Collider2D collision)
    {
        yield return new WaitForSeconds(0.5f);
        //将玩家的位置移动到父物体下子物体out的位置上
        collision.gameObject.transform.position = transform.parent.Find("out").position;
        collision.gameObject.GetComponent<PlayerCtrl>().VelocityDir = transform.parent.Find("out").gameObject.GetComponent<PortalOUT>().VelocityDir;
        collision.gameObject.GetComponent<PlayerCtrl>().speed = 5.0f;
    }
}
