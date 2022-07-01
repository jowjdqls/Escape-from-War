using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misileSpawn : MonoBehaviour
{
    public GameObject misilefactory;
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
            GameObject misile = Instantiate(misilefactory);
            misile.transform.position = transform.position;

            currentTime = 0;

            Destroy(misile, 10.0f);
        }
    }
}
