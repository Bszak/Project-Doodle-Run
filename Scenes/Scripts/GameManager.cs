using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject spawnObject;
    public float timer;
    public float timeBetweenSpawns;
   
    public float speedMultiplier;
    private float distance;

    public Text distanceUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceUI.text = distance.ToString();
        speedMultiplier += Time.deltaTime * 0.02f;

        timer += Time.deltaTime;

        distance += Time.deltaTime * 0.8f;

        if(timer > timeBetweenSpawns)
        {
            timer = 0;
            int randNum = Random.Range(0, 7);
            Instantiate(spawnObject, spawnPoints[randNum].transform.position, Quaternion.identity);
        }
    }
}
