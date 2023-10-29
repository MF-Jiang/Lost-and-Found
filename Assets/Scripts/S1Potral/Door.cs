using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject box;
    public SpriteRenderer sr;

    //存一张图片
    public Sprite openSprite;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (box == null)
        {
            //将sr的图片换成openSprite
            sr.sprite = openSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //获取UIManager，执行Gameover函数
            GameObject.Find("UIManager").GetComponent<UIManager>().GameOver(true);
            collision.gameObject.GetComponent<PlayerCtrl>().speed = 0;
        }
    }
}
