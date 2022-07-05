using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemyfactory;
    public float minCreateTime = 1;
    public float maxcreateTime = 3;
    float currentTime;
    float createTime;
    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(minCreateTime, maxcreateTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > createTime)
        {
            GameObject enemy = Instantiate(enemyfactory);
            enemy.transform.position = transform.position;

            currentTime = 0;

            Destroy(enemy, 20.0f);
        }
    }
}
