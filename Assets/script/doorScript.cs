using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public float rotSpeed = 90f;
    bool isOpen = false;
    public float rotation ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col){
    if(!isOpen){
     transform.Rotate(0, 0, 90);
        isOpen=true;
    }
    else if(isOpen){
     transform.Rotate(0, 0, -90);
        isOpen=false;
    }
    
    }
}
