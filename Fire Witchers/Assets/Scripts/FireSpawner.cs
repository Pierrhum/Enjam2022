using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    private RectTransform rt;
    private SpriteRenderer sp;
    public GameObject FirePrefab;

    private int minX, minY, maxX, maxY;
    
    void Start () {
        rt = GetComponent<RectTransform>();
        sp = GetComponent<SpriteRenderer>();

        float width = sp.bounds.size.x / 2;
        float height = sp.bounds.size.y / 2;
        minX = (int)(transform.position.x - width);
        maxX = (int)(transform.position.x + width);
        minY = (int)(transform.position.y - height);
        maxY = (int)(transform.position.y + height);
    }

    public void SpawnFlames(int number)
    {
        for (int i = 0; i < number; i++) {
            GameObject go = Instantiate(FirePrefab, new Vector3(Random.Range(minX, maxX), 
                Random.Range(minY, maxY), 0) + Vector3.up * 3 , Quaternion.identity);
            go.transform.SetParent(gameObject.transform);
        }
    }
}
