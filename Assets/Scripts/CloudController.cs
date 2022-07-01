using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float speed = 1; // 구름 이동 속도

    private void Start()
    {
        
    }

    void Update()
    {
        // 구름이 화면 밖으로 나가면 제거
        if(transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }

        // 구름 이동
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = curPos + nextPos;

    }
}
