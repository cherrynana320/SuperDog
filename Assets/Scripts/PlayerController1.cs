using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    public float playerSpeed; // �÷��̾� �ӵ�
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;

    Animator anim;

    // �ʱ�ȭ
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Input.GetAxisRaw(string name)�� ���� ���� �� ���� (��: -1, 0 , ��:1 �� �ϳ� ��ȯ)
        float h = Input.GetAxisRaw("Horizontal");

        // Border(��)�� �浹�ߴµ� ��� �̵��Ϸ��� �Ͽ��� h ���� 1�̳� -1�� ��, h = 0
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;

        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v = 0;


        // transform�̵��� ������ �̵�X
        Vector3 curPos = transform.position; //�÷��̾��� ���� ��ġ
        Vector3 nextPos = new Vector3(h, v, 0) * playerSpeed * Time.deltaTime; ; // ������ �̵��ؾ� �� ��ġ

        transform.position = curPos + nextPos; // �÷��̾� ��ġ �̵�


        // ** �ִϸ��̼� �۵� ó��
        // ��ư�� �����ų� ������ ��, animator�� �Ķ���� Input�� h�� ����
        if(Input.GetButtonDown("Horizontal") ||
            Input.GetButtonUp("Horizontal")) {
            anim.SetInteger("Input", (int)h);
        }
    }



    // ** ������Ʈ�� �浹(����)�ϴ� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �÷��̾�(dog)�� ��(border) �浹 ó��
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

        // ���� �浹 ó��
        if (collision.gameObject.tag == "Cloud")
        {
            Debug.Log("���� �浹");
            SceneManager.LoadScene("GameOverScene");
        }

        // �� �浹 ó��
        if (collision.gameObject.tag == "Bird")
        {
            Debug.Log("�� �浹");
            SceneManager.LoadScene("GameOverScene");
        }

        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("��");
            SceneManager.LoadScene("GameScene_stage2");
        }


    }


    // ** ������Ʈ�� �������� ����
    private void OnTriggerExit2D(Collider2D collision)
    {
        // �÷��̾�(dog)�� ��(border) �������� �� ó��
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
