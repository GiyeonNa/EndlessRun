using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float spawnPoint;
    public float tileLength = 30;
    public Transform playerTransform;

    private List<GameObject> activeTile = new List<GameObject>(); 

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<tilePrefabs.Length; i++)
        {
            if (i == 0) SpawnTile(0);
            else SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35f > spawnPoint - (tilePrefabs.Length * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject tempTile = Instantiate(tilePrefabs[tileIndex],transform.forward * spawnPoint, transform.rotation);
        activeTile.Add(tempTile);
        spawnPoint += tileLength;
    }

    public void DeleteTile()
    {
        Destroy(activeTile[0]);
        activeTile.RemoveAt(0); 
    }
}
