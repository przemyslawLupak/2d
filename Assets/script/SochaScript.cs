using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SochaScript : MonoBehaviour
{
    private GameObject enemy;
    public float sochaSpeed = 5f;
    public GameObject playerTarget;
    public Transform sochaPoint;
    public float TimebtwTep=5f;
    public float Timer=0f;
    bool isTriggerd = false;
    public GameObject jumpScare;
    public AudioSource smiech;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position,playerTarget.transform.position);
        if(distance<10f && distance>0.1f){
            smiech.volume = 1-distance/10;
        }
        else if(distance>10f){
            smiech.volume = 0f;
        }
        if(Timer>0){
            Timer -=Time.deltaTime;
        }
        else if(Timer<=0 && isTriggerd){
            transform.position = sochaPoint.position;
            enemy.GetComponent<enemy>().isSochaSpawned = false;
            isTriggerd = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag =="Player"){
           isTriggerd=true;
           if(Timer<=0 && enemy.GetComponent<enemy>().pckCount<=3){
               Timer = 0.5f;
           }
           else if(Timer<=0 && enemy.GetComponent<enemy>().pckCount<=6){
               Timer = 1f;
           }
           else if(Timer<=0 && enemy.GetComponent<enemy>().pckCount<=8){
               Timer=1.5f;
           }
           
        }
    }
    void OnCollisionEnter2D (Collision2D col){
        if(col.gameObject.tag == "Player"){
            SceneManager.LoadScene("jmpscr");
            Cursor.visible = true;
        }
    }
}
