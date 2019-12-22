using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolePool : MonoBehaviour
{
    public int polePoolSize = 5;
    public GameObject polePrefab;
    public float spawnRate = 4;
    public float poleMin = -1f;
    public float poleMax = 3.5f;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private GameObject[] poles;
    private float timeSinceLastSpawned;
    private float spawnXPosition = 5;
    private int currentPole = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        poles = new GameObject[polePoolSize];
        for (int i = 0; i < polePoolSize; i++)
        {
            poles[i] = (GameObject) Instantiate (polePrefab, objectPoolPosition, Quaternion.identity);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if(GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(poleMin, poleMax);
            poles[currentPole].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentPole++;
            if(currentPole >= polePoolSize) {
                currentPole = 0;
            }
        }
    }
}
