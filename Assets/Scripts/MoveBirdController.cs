using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBirdController : MonoBehaviour
{
    public float moveSpeed; // �� �̵��ӵ�
    

    void Start()
    {
        
    }

    void Update()
    {
        // ���� ȭ�� ������ ������ ����
        if (transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }

        // �� �¿�� �̵�
        Vector3 curPos = transform.position;
        transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // BorderRL�±׸� ���� ������Ʈ�� �浹�Ͽ��� ��
        if (collision.gameObject.tag == "BorderRL")
        {
            moveSpeed = -moveSpeed; // �̵����� �ٲ��ֱ�
            transform.localScale *= new Vector2(-1, 1); // �¿����
        }

    }
}
