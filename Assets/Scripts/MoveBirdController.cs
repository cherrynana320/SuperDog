using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBirdController : MonoBehaviour
{
    public float moveSpeed; // 새 이동속도
    

    void Start()
    {
        
    }

    void Update()
    {
        // 새가 화면 밖으로 나가면 제거
        if (transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }

        // 새 좌우로 이동
        Vector3 curPos = transform.position;
        transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // BorderRL태그를 가진 오브젝트와 충돌하였을 때
        if (collision.gameObject.tag == "BorderRL")
        {
            moveSpeed = -moveSpeed; // 이동방향 바꿔주기
            transform.localScale *= new Vector2(-1, 1); // 좌우반전
        }

    }
}
