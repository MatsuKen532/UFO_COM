using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerContoroller : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 8.0f;
    float seconds;
    public bool isArea = false; //当たった回数を判定
    public bool touch = false;
    public bool over = true;
    bool jump = false;
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);


            jump = true;
        }

        // 左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //プレイヤーの速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // スピード制限
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
//プレイヤーが引っ張られる挙動
        if (isArea == true)
        {
            this.rigid2D.AddForce(new Vector2(0, 50.0f));
            seconds += Time.deltaTime;
            if (seconds >= 1)
            {
                Debug.Log(seconds);
                seconds = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DangerArea"))
        {
            touch = true;  // 行いたい処理
            Debug.Log("touch is true");
            isArea = true;
        }
        if (other.gameObject.CompareTag("SafeArea"))
        {
            touch = false;  // 行いたい処理
            Debug.Log("touch is false");
            over = false;
            Debug.Log("over is false");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ufo"))
        {
            isArea = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
    }
}