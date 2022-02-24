using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float step = speed * Time.deltaTime;
        transform.Translate(0, step, 0);

        if (!this.GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(this.gameObject);

            Enemy enemy = collision.gameObject.GetComponent("Enemy") as Enemy;
            enemy.HP -= 1;

            if (enemy.HP == 0)
            {
                Destroy(collision.gameObject);

                Main main = GameObject.Find("Main").GetComponent("Main") as Main;
                main.addScore();
            }
        }
    }
}
