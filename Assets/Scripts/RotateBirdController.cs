using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBirdController : MonoBehaviour
{
    public float rotationSpeed; // ȸ�� �ӵ�
    public GameObject center; // ȸ������ �Ǵ� empty������Ʈ

    void Start()
    {
        // hierarchyâ���� center�̸� ���� ������Ʈ ��������
        // center�� �߽����� ���� ȸ���ϱ� ����.
        center = GameObject.Find("center");
    }


    void Update()
    {
        // center�� �߽����� �������� ȸ��.
        // Vector3.forward = new Vector3(0.0f, 0.0f, 1.0f)
        transform.RotateAround(center.transform.position, Vector3.forward, 
            rotationSpeed*Time.deltaTime);

        // ���� ȭ�� ������ ������ ����
        if (transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }
    }
}
