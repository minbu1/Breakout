using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector3 spawnPosition;
    public float offset = 1;
    public int count = 10;
    public GameObject[] prefabs;
    private void Start()
    {
        for(int y = 0; y < prefabs.Length; y++)
        {
            for(int x = 0; x < count; x++)
            {
                var brick = prefabs[y];
                var position = spawnPosition + new Vector3(x * offset, y * offset, 0);
                Instantiate(brick, position, Quaternion.identity);
            }
        }
    }

}
