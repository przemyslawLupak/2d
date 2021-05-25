using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject package;
    bool Spawned = false;
    public LayerMask spawnLayer;
    public float pkNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Spawned){
            spawn();
        }
    }
    public void spawn(){
        for(int i = 0;i<pkNumber;i++){
            Transform spawn_pos = SpawnPoints[Random.Range(0,SpawnPoints.Length)];
            Collider2D detection = Physics2D.OverlapCircle(spawn_pos.position,1,spawnLayer);
            while(detection !=null){
                spawn_pos = SpawnPoints[Random.Range(0,SpawnPoints.Length)];
                detection = Physics2D.OverlapCircle(spawn_pos.position,1,spawnLayer);
            }
            Instantiate(package,spawn_pos.position,Quaternion.identity);
        }
        Spawned=true;
    }
}
