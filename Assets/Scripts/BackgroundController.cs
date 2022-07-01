using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float speed = 1;

    void Update()
    {
        Vector3 curPos = transform.position; // ���� ��ġ
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime; // ���� ��ġ Vector3.down = Vector3(0.0f, -1.0f, 0.0f) 

        // ����� y��ǥ ��ġ�� -9.5�� �Ǳ� �������� �̵�
        if (transform.position.y > -9.5f)
        {
            transform.position = curPos + nextPos; // �̵�
        }

        
    }
   
}
