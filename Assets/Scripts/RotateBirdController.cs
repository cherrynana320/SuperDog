using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBirdController : MonoBehaviour
{
    public float rotationSpeed; // 회전 속도
    public GameObject center; // 회전축이 되는 empty오브젝트

    void Start()
    {
        // hierarchy창에서 center이름 가진 오브젝트 가져오기
        // center를 중심으로 새가 회전하기 위함.
        center = GameObject.Find("center");
    }


    void Update()
    {
        // center를 중심으로 왼쪽으로 회전.
        // Vector3.forward = new Vector3(0.0f, 0.0f, 1.0f)
        transform.RotateAround(center.transform.position, Vector3.forward, 
            rotationSpeed*Time.deltaTime);

        // 새가 화면 밖으로 나가면 제거
        if (transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }
    }
}
