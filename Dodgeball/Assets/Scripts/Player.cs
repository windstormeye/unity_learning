using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        float step = speed * Time.deltaTime;
        float selfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;

        float screenLeft = -9.0f + selfWidth;
        float screenRight = 9.0f - selfWidth;
        // TODO: 把小球独立出来
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-step, 0, 0);
            if (transform.position.x <= screenLeft)
            {
                transform.position = new Vector3(screenLeft, transform.position.y, 0);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(step, 0, 0);
            if (transform.position.x >= screenRight)
            {
                transform.position = new Vector3(screenRight, transform.position.y, 0);
            }
        }
    }
 }
