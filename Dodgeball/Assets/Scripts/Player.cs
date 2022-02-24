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

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-step, 0, 0);
            // TODO: ±ﬂΩÁ≈–∂œ
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(step, 0, 0);
            // TODO: ±ﬂΩÁ≈–∂œ
        }

        // TODO: Ã¯‘æ

    }
 }
