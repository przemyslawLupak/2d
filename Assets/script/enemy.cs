using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float FirstCricle=15f;
    public float SecondCricle=10f;
    public float ThirdCricle=3f;
    public GameObject socha; 
    public GameObject playerTarget;
    public float speed = 2f;
    private float distance;
    public float  pckCount;
    public bool isSochaSpawned = false;
    public float spawningBreak = 5f;
    public float timebtwSpawn = 0f;
    public GameObject socha1;
    public  LayerMask sochalayer;
    public Transform sochaStartPos;
    public AudioSource heartbeat;
    bool isPlayed=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pckCount = playerTarget.GetComponent<movementScript>().cardsCollected;
        
        distance = Vector2.Distance(transform.position,playerTarget.transform.position);
        if(pckCount<=3){
            if(distance>FirstCricle){
                if(socha1!=null && (distance>(FirstCricle+5f))){
                    socha1.transform.position = sochaStartPos.position;
                    timebtwSpawn = 0;
                    isSochaSpawned=false;
                }
                transform.position = Vector2.MoveTowards(transform.position,playerTarget.transform.position,speed*Time.deltaTime);
            }
            else{
               
                if(distance<FirstCricle-5f){
                    transform.position = Vector2.MoveTowards(transform.position,playerTarget.transform.position,-5f*Time.deltaTime);
                }
                if(!isSochaSpawned && timebtwSpawn <=0){
                    Vector2 spawn_pos = new Vector2(transform.position.x+Random.Range(-ThirdCricle,ThirdCricle),transform.position.y+Random.Range(-ThirdCricle,ThirdCricle));
                    Collider2D detection = Physics2D.OverlapCircle(spawn_pos,1,sochalayer);
                    while(detection !=null){
                        spawn_pos = new Vector2(transform.position.x+Random.Range(-ThirdCricle,ThirdCricle),transform.position.y+Random.Range(-ThirdCricle,ThirdCricle));
                        detection = Physics2D.OverlapCircle(spawn_pos,1,sochalayer);
                    }
                    socha1.transform.position = spawn_pos;
                    isSochaSpawned=true;
                    timebtwSpawn = spawningBreak;
                }
            }
        }
        else if(pckCount<=6){
            spawningBreak=3f;
          
           if(distance>SecondCricle){
                if(socha1!=null && (distance>(SecondCricle+3f))){
                    socha1.transform.position = sochaStartPos.position;
                    timebtwSpawn = 0;
                    isSochaSpawned=false;
                }
                transform.position = Vector2.MoveTowards(transform.position,playerTarget.transform.position,speed*1.25f*Time.deltaTime);
            }
            else{
                
                
                if(distance<SecondCricle-3f){
                    transform.position = Vector2.MoveTowards(transform.position,playerTarget.transform.position,-5f*Time.deltaTime);
                }
                if(!isSochaSpawned && timebtwSpawn <=0){
                    Vector2 spawn_pos = new Vector2(transform.position.x+Random.Range(-ThirdCricle,ThirdCricle),transform.position.y+Random.Range(-ThirdCricle,ThirdCricle));
                    Collider2D detection = Physics2D.OverlapCircle(spawn_pos,1,sochalayer);
                    while(detection !=null){
                        spawn_pos = new Vector2(transform.position.x+Random.Range(-ThirdCricle,ThirdCricle),transform.position.y+Random.Range(-ThirdCricle,ThirdCricle));
                        detection = Physics2D.OverlapCircle(spawn_pos,1,sochalayer);
                    }
                    socha1.transform.position = spawn_pos;
                    isSochaSpawned=true;
                    timebtwSpawn = spawningBreak;
                }
            }
        }
        else{
            spawningBreak = 1.5f;
       
            if(distance>ThirdCricle){
                if(socha1!=null && (distance>(ThirdCricle+3f))){
                    socha1.transform.position = sochaStartPos.position;
                    timebtwSpawn = 0;
                    isSochaSpawned=false;
                }
                transform.position = Vector2.MoveTowards(transform.position,playerTarget.transform.position,speed*1.4f*Time.deltaTime);
            }
            else{
                
                if(distance<ThirdCricle){
                    transform.position = Vector2.MoveTowards(transform.position,playerTarget.transform.position,-10f*Time.deltaTime);
                }
                if(!isSochaSpawned && timebtwSpawn <=0){
                    Vector2 spawn_pos = new Vector2(transform.position.x+Random.Range(-ThirdCricle+1f,ThirdCricle-1f),transform.position.y+Random.Range(-ThirdCricle+1f,ThirdCricle-1f));
                    Collider2D detection = Physics2D.OverlapCircle(spawn_pos,1,sochalayer);
                    while(detection !=null){
                        spawn_pos = new Vector2(transform.position.x+Random.Range(-ThirdCricle+1f,ThirdCricle-1f),transform.position.y+Random.Range(-ThirdCricle+1f,ThirdCricle-1f));
                        detection = Physics2D.OverlapCircle(spawn_pos,1,sochalayer);
                    }
                    socha1.transform.position = spawn_pos;
                    isSochaSpawned=true;
                    timebtwSpawn = spawningBreak;
                }
            }
        }
        
        
        if(distance<=1f+ThirdCricle){
                heartbeat.volume =0.6f;
                heartbeat.pitch = 1.5f;
        }
        else if(distance<=SecondCricle){
             heartbeat.volume = 0.3f;
             heartbeat.pitch = 1.2f;
        }
        else if(distance<=FirstCricle){
              if(isPlayed==false){
                    heartbeat.Play();
                    heartbeat.volume = 0.1f;
                    heartbeat.pitch = 1f;
                    isPlayed =true;
                }
        }
        else if(distance>FirstCricle){
            if(isPlayed==true){
            heartbeat.volume = 0.1f;
            heartbeat.Stop();
            isPlayed = false;
            }
        }
        
        if(!isSochaSpawned && timebtwSpawn >0){
                timebtwSpawn -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,FirstCricle);
        Gizmos.DrawWireSphere(transform.position,SecondCricle);
        Gizmos.DrawWireSphere(transform.position,ThirdCricle);
    
    }
}
