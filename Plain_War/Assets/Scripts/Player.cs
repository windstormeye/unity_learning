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

            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(audio.clip);

            timeCount = 0;
        }

        float screenLeft = -2.5f;
        float screenRight = 2.5f;
        float screenTop = 5f;
        float screenBottom = -5f;

        float step = speed * Time.deltaTime;
        Vector3 prePosition = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-step, 0, 0);
            if (transform.position.x <= screenLeft)
            {
                transform.position = new Vector3(screenLeft, prePosition.y, prePosition.z);
            }
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        { 
            transform.Translate(step, 0, 0);
            if (transform.position.x >= screenRight)
            {
                transform.position = new Vector3(screenRight, prePosition.y, prePosition.z);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, step, 0);
            if (transform.position.y >= screenTop)
            {
                transform.position = new Vector3(prePosition.x, screenTop, prePosition.z);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -step, 0);
            if (transform.position.y <= screenBottom)
            {
                transform.position = new Vector3(prePosition.x, screenBottom, prePosition.z);
            }
        }
    }   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
