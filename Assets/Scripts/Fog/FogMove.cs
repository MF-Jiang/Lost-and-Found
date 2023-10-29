using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMove : MonoBehaviour
{

    public bool isMove = false;
    public float speed = 5f;

    // public float startPos = -15f;
    public float endPos = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 获取当前位置
        Vector3 currentPosition = transform.position;

        if (isMove)
        {    

            // 获取父对象的位置
            Vector3 parentPosition = transform.parent.position;

            // 更新 Fog 的 z 坐标
            float newZ = Mathf.MoveTowards(currentPosition.z, endPos, speed * Time.deltaTime);

            // 设置 Fog 的新位置，保持父对象的x和y坐标
            transform.position = new Vector3(parentPosition.x, parentPosition.y, newZ);

            // 检查是否到达目标位置
            if (Mathf.Approximately(newZ, endPos))
            {
                isMove = false; // 停止移动
            }
        }
    }
}
