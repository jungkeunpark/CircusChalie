using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TrapMaker : MonoBehaviour
{
    public GameObject Trap;
    public int count = 20;

    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 3f;
    private float timeBetSpawn;

    public float yMin = 0.0f;
    public float yMax = 1.5f;
    public float xPos = 100f;

    private GameObject[] Traps;
    private int currentIndex = 0;

    private Vector2 poolPosition = new Vector2(0, -25);
    private float lastMakeTime;

    void Start()
    {
        Traps = new GameObject[count];
        
        for(int i = 0; i < count; i++) 
        {
            Traps[i] = Instantiate(Trap,poolPosition,Quaternion.identity);
        }

        lastMakeTime = 0f;
        timeBetSpawn = 0f;
    }

    void Update()
    {
        if(GameManager.instance.isGameOver)
        {
            return;
        }
        if(Time.time>= lastMakeTime + timeBetSpawn)
        {
            lastMakeTime= Time.time;

            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            float yPos = Random.Range(yMin, yMax);

            Traps[currentIndex].SetActive(false);
            Traps[currentIndex].SetActive(true);

            Traps[currentIndex].transform.position = new Vector2(xPos, yPos);
            currentIndex++;

            if(currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }
}
