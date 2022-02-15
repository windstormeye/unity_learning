using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 1.2f;
    public GameObject bulletPrefab;

    private float timeCount = 0f;
    private float timeInterver = 0.5f;
    private SpriteRenderer redenderer;

    // Start is called before the first frame update
    void Start()
    {
        redenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= timeInterver)
        {
            Vector3 bulletPos = transform.position + new Vector3(0, 0.5f, 0);
            GameObject bullet = Instantiate(bulletPrefab, bulletPos, transform.rotation);
            timeCount = 0;
        }

        float step = speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-step, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(step, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, step, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -step, 0);
        }
    }   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            redenderer.color = Color.red;
        }
    }
}
