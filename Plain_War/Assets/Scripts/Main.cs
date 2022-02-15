using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject[] monsterPrefabs;

    private float timePass = 0;
    private float timeInterver = 2;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
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
    }

    private void CreateMonster()
    {
        float monsterX = Random.Range(-2, 2);
        float monsterY = 5;

        int monsterPrefeb = Random.Range(0, monsterPrefabs.Length);
        GameObject monster = Instantiate(monsterPrefabs[monsterPrefeb]);
        monster.transform.position = new Vector3(monsterX, monsterY, 0);
    }
}
