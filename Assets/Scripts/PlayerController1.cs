using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    public float playerSpeed; // 플레이어 속도
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;

    Animator anim;

    // 초기화
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Input.GetAxisRaw(string name)를 통한 방향 값 추출 (왼: -1, 0 , 오:1 중 하나 반환)
        float h = Input.GetAxisRaw("Horizontal");

        // Border(벽)에 충돌했는데 계속 이동하려고 하여서 h 값이 1이나 -1일 때, h = 0
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;

        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v = 0;


        // transform이동은 물리적 이동X
        Vector3 curPos = transform.position; //플레이어의 현재 위치
        Vector3 nextPos = new Vector3(h, v, 0) * playerSpeed * Time.deltaTime; ; // 다음에 이동해야 할 위치

        transform.position = curPos + nextPos; // 플레이어 위치 이동


        // ** 애니메이션 작동 처리
        // 버튼을 누르거나 떼었을 때, animator의 파라미터 Input에 h값 대입
        if(Input.GetButtonDown("Horizontal") ||
            Input.GetButtonUp("Horizontal")) {
            anim.SetInteger("Input", (int)h);
        }
    }



    // ** 오브젝트와 충돌(접촉)하는 순간
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어(dog)와 벽(border) 충돌 처리
        if (collision.gameObject.tag == "BorderRL" || collision.gameObject.tag == "BorderTB")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;

                case "Bottom":
                    isTouchBottom = true;
                    break;

                case "Right":
                    isTouchRight = true;
                    break;

                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }

        // 구름 충돌 처리
        if (collision.gameObject.tag == "Cloud")
        {
            Debug.Log("구름 충돌");
            SceneManager.LoadScene("GameOverScene");
        }

        // 새 충돌 처리
        if (collision.gameObject.tag == "Bird")
        {
            Debug.Log("새 충돌");
            SceneManager.LoadScene("GameOverScene");
        }

        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("골");
            SceneManager.LoadScene("GameScene_stage2");
        }


    }


    // ** 오브젝트와 떨어지는 순간
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 플레이어(dog)와 벽(border) 떼어졌을 때 처리
        if (collision.gameObject.tag == "BorderRL" || collision.gameObject.tag == "BorderTB")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;

                case "Bottom":
                    isTouchBottom = false;
                    break;

                case "Right":
                    isTouchRight = false;
                    break;

                case "Left":
                    isTouchLeft = false;
                    break;
            }
        }
    }


    
}
