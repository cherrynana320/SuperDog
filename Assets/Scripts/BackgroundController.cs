using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float speed = 1;

    void Update()
    {
        Vector3 curPos = transform.position; // 현재 위치
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime; // 다음 위치 Vector3.down = Vector3(0.0f, -1.0f, 0.0f) 

        // 배경의 y좌표 위치가 -9.5가 되기 전까지만 이동
        if (transform.position.y > -9.5f)
        {
            transform.position = curPos + nextPos; // 이동
        }

        
    }
   
}
