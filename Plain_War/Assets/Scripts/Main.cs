using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject[] monsterPrefabs;
    public GameObject bgPrefab;
    public float bgSpeed = 1.2f;

    private float timePass = 0;
    private float timeInterver = 2;

    private GameObject bg0;
    private GameObject bg1;
    private GameObject bg2;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        initBackground();
    }

    // Update is called once per frame
    void Update()
    {
        timePass += Time.deltaTime;
        if (timePass >= timeInterver)
        {
            CreateMonster();
            timePass = 0;
        }

        updateBackground();
    }

    private void CreateMonster()
    {
        float monsterX = Random.Range(-2, 2);
        float monsterY = 5;

        int monsterPrefeb = Random.Range(0, monsterPrefabs.Length);
        GameObject monster = Instantiate(monsterPrefabs[monsterPrefeb]);
        monster.transform.position = new Vector3(monsterX, monsterY, 0);
    }

    private void initBackground()
    {
        bg0 = Instantiate(bgPrefab);
        bg1 = Instantiate(bgPrefab);
        bg2 = Instantiate(bgPrefab);

        bg0.transform.Translate(0, 20, 0);
        bg1.transform.Translate(0, 10, 0);
        bg2.transform.Translate(0, 0, 0);
    }

    private void updateBackground()
    {
        float step = bgSpeed * Time.deltaTime;
        bg0.transform.Translate(0, -step, 0);
        bg1.transform.Translate(0, -step, 0);
        bg2.transform.Translate(0, -step, 0);

        if (bg0.transform.position.y <= -10)
        {
            bg0.transform.Translate(0, 20, 0);
        }

        if (bg1.transform.position.y <= -10)
        {
            bg1.transform.Translate(0, 20, 0);
        }

        if (bg2.transform.position.y <= -10)
        {
            bg2.transform.Translate(0, 20, 0);
        }
    }
}
