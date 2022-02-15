using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.2f;
    public int HP = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.Translate(0, -step, 0);

        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
}
