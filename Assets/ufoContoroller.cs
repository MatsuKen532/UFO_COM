using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ufoContoroller : MonoBehaviour
{
    private Vector2 pos;
    public int num = 1;
    private GameObject target;

    void Start()
    {
        target = GameObject.Find("player");
        Vector2 firstpos = GameObject.Find("ufo").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        transform.Translate(transform.right * Time.deltaTime * 3 * num);
        if (target.GetComponent<playerContoroller>().touch == false && target.GetComponent<playerContoroller>().over == true)
        {
            if (pos.x > -2)
            {
                num = -1;
            }
            if (pos.x < -11)
            {
                num = 1;
            }
        }
        if (target.GetComponent<playerContoroller>().touch == false && target.GetComponent<playerContoroller>().over == false)
        {
            GetComponent<Renderer>().material.color = Color.white;
            GameObject.Find("ufo").transform.position = new Vector2(-3.0f, 0);
        }
        if (target.GetComponent<playerContoroller>().touch == true)
        {
            GetComponent<Renderer>().material.color = Color.red;
            Vector2 targeting = (target.transform.position - this.transform.position).normalized;
            if (targeting.x > 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }

            //xï˚å¸Ç…ÇÃÇ›ÉvÉåÉCÉÑÅ[Çí«Ç§
            this.GetComponent<Rigidbody2D>().velocity = new Vector2((targeting.x * 7), 0);
        }

    }
}
