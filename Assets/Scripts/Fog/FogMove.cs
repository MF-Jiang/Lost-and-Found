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
        // ��ȡ��ǰλ��
        Vector3 currentPosition = transform.position;

        if (isMove)
        {    

            // ��ȡ�������λ��
            Vector3 parentPosition = transform.parent.position;

            // ���� Fog �� z ����
            float newZ = Mathf.MoveTowards(currentPosition.z, endPos, speed * Time.deltaTime);

            // ���� Fog ����λ�ã����ָ������x��y����
            transform.position = new Vector3(parentPosition.x, parentPosition.y, newZ);

            // ����Ƿ񵽴�Ŀ��λ��
            if (Mathf.Approximately(newZ, endPos))
            {
                isMove = false; // ֹͣ�ƶ�
            }
        }
    }
}
