using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class movementScript : MonoBehaviour
{
    private Rigidbody2D  rgbody;
    private float vertical;
    private float horizontal;
    public float movementSpeed = 20f;
    public float speed = 5f;
    public float cardsCollected;
    public Text text;
    public AudioSource footsteps;
    bool isPlayed = false;
    void Start()
    {
        rgbody = GetComponent<Rigidbody2D>();
        footsteps = GetComponent<AudioSource>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
      horizontal = Input.GetAxisRaw("Horizontal");
      vertical = Input.GetAxisRaw("Vertical");
      Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
      float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
      Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
      transform.rotation = Quaternion.Slerp(transform.rotation,rotation,speed *  Time.deltaTime);
      text.text = cardsCollected.ToString();
      if(cardsCollected==8){
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
      }
    }
    void FixedUpdate(){
        if(horizontal != 0 && vertical != 0){
            horizontal *= 0.7f;
            vertical *= 0.7f;
        }
        
        rgbody.velocity = new Vector2(horizontal*movementSpeed,vertical*movementSpeed);
        if(rgbody.velocity!=new Vector2(0f,0f) && isPlayed==false){
            footsteps.Play();
            isPlayed = true;
        }
        else if(rgbody.velocity==new Vector2(0f,0f) && isPlayed==true){
            footsteps.Stop();
            isPlayed = false;
        }
    }
     
}
