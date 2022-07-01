using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        Vector3 curPos = transform.position; // 현재 위치
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime; // 다음 위치
        transform.position = curPos + nextPos; // 이동
    }
}
