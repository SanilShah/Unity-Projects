using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private GroundManager gm;


    public GameObject[] obstacles;
    public float timerSpawn;
    public float obstacleSpeedMovement;

    private List<Vector3> listposition = new List<Vector3>();

    public GameObject[] Obstacles { get => obstacles; set => obstacles = value; }

    void Start()
    {
        int i = -5;
        while(i <= 5)
        {
            Vector3 pos = transform.position + new Vector3(0, 0, i);
            listposition.Add(pos);
            i += 2;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(timerSpawn);

        // (FindObjectOfType<GroundManager>())
    }
}
