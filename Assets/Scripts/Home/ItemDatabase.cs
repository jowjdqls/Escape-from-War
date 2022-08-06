using System.Linq;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemRandom = System.Random;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Item> itemDB = new List<Item>();
    [Space(20)]
    public GameObject fieldItemPrefab;
    public Vector3[] pos;

    private void Start()
    {
        var used = new List<int>();
        for(int i = 0; i < 21; i++)
        {
            GameObject go = Instantiate(fieldItemPrefab, pos[i], Quaternion.identity);
            var index = randomExcept(20, used);
            used.Add(index);
            go.GetComponent<FieldItems>().SetItem(itemDB[index]);
        }
    }

    private static int randomExcept(int n, List<int> except) 
    {
        var x = except.OrderBy(i => i).ToArray();
        var r = new SystemRandom();
        int result = r.Next(n - x.Length);

        for (int i = 0; i < x.Length; i++) 
        {
            if (result < x[i])
                return result;
            result++;
        }
        return result;
    }
}