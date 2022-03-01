using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        createEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        Rigidbody2D regibody = enemy.GetComponent<Rigidbody2D>();
        regibody.AddForce(new Vector2(10, 0), ForceMode2D.Impulse);
    }
}
