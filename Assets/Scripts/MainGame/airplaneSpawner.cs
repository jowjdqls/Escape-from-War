using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airplaneSpawner : MonoBehaviour
{
    public GameObject enemyFactory;
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
            GameObject airplane = Instantiate(enemyFactory);
            airplane.transform.position = transform.position;

            currentTime = 0;

            Destroy(airplane, 15.0f);
        }
    }
}
