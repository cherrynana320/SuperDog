using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        Vector3 curPos = transform.position; // ���� ��ġ
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime; // ���� ��ġ
        transform.position = curPos + nextPos; // �̵�
    }
}
