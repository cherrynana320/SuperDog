using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float speed = 1; // ���� �̵� �ӵ�

    private void Start()
    {
        
    }

    void Update()
    {
        // ������ ȭ�� ������ ������ ����
        if(transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }

        // ���� �̵�
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = curPos + nextPos;

    }
}
