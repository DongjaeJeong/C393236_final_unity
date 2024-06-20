using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;

    List<GameObject>[] pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = new List<GameObject>();
        }

    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject item in pool[index])
        {
            if (item.activeSelf) continue;
            select = item;
            select.SetActive(true);
            break;
        }

        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pool[index].Add(select);
        }

        return select;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
