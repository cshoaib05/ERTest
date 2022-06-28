using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooler : MonoBehaviour
{
    Vector3 objposition;
    int rankey;
    public List<GameObject> objPrefab;
    private int key = 0;

    Dictionary<int, Queue<GameObject>> objDict;

    float timeElapsed = 0f;
    public float spawnTime = 1f;

    void Start()
    {
        objposition = new Vector3(0f, 0f, 10f);

        objDict = new Dictionary<int, Queue<GameObject>>();

        foreach (GameObject obj in objPrefab)
        {
            key++;
            Queue<GameObject> objpool = new Queue<GameObject>();

            for (int i = 0; i < 20; i++)
            {
                GameObject go = Instantiate(obj, obj.transform.position, obj.transform.rotation);
                go.SetActive(false);
                objpool.Enqueue(go);
            }
            objDict.Add(key, objpool);
        }

        for (int i = 0; i < 25; i++)
        {
            SpawnObs();
        }
    }


    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > spawnTime)
        {
            SpawnObs();
            timeElapsed = 0f;
        }
    }


    public void SpawnObs()
    {
        Vector3 temppos;
        rankey = Random.Range(1, objPrefab.Count + 1);
        GameObject go = objDict[rankey].Dequeue();
        go.SetActive(true);
        temppos = go.transform.position;
        temppos.z = objposition.z;
        go.transform.position = temppos;
        objposition = objposition + new Vector3(0f, 0f, 10f);
        objDict[rankey].Enqueue(go);
    }
}
