using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs; // Tiles the manager will spawn
    private Transform playerTransform;
    private float spawnZ = -20.0f;
    private float tileLength = 10.0f;
    private float safeZone = 50.0f;
    private int amnTilesOnScreen = 7;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;

	// Use this for initialization
	void Start ()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; //Find player position
        for(int i = 0; i < amnTilesOnScreen; i++) //Spawns 7 tiles on screen at the start
        {
            if (i < 4)
            {
                SpawnTile(0); //Spawn First Index for the 2 first tiles
            }
            else
            {
                SpawnTile();
            }

        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength)) //Spawns new sets of tiles and deletes old ones after the player has moved a certain distance.
        {
            SpawnTile();
            DeleteTile();
        }
	}

    private void SpawnTile (int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = lastPrefabIndex; 
        while(randomIndex == lastPrefabIndex) // To avoid the same tile spawning consecutively we get it to pick a different index.
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

}
