using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IN : MonoBehaviour
{
    public GameObject box;
    private BoxCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //��⵽box������
        if (box == null)
        {
            coll.enabled = true;
        }
    }
}
