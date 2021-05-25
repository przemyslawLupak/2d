using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                        

public class pckScript : MonoBehaviour
{
    private GameObject player;
    public AudioSource pickup;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D (Collision2D col){
      player.GetComponent<movementScript>().cardsCollected +=1;
      pickup.Play();
      Destroy(gameObject,0.18f);
    }
}
