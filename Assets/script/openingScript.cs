using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class openingScript : MonoBehaviour
{
    int enterCounter=0;
    public GameObject[] scenes;
    public string[] sentences;
    public TextMeshProUGUI[] textDisplay;
    public GameObject[] textObjects;
    public int index = 0;
    public float typingSpeed= 0.2f;
    bool  textActivated = false;
    public float timer;
    public float skipinTimer = 0;
    public GameObject enterBtn;
    bool activated = true;
    // Start is called before the first frame update
    void Start()
    {
        scenes[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if(Input.GetKeyDown(KeyCode.Return)&&skipinTimer<=0f && activated==true){
            enterCounter++;
            if(enterCounter<8){
                scenes[enterCounter].SetActive(true);
            }
            if(enterCounter==1){
                textActivated =true;
                timer = 0.2f;
            }
            if(enterCounter==3){
                textActivated=true;
                timer=0.2f;
                index++;
            }
            skipinTimer = 0.4f;
            if(enterCounter ==5){
                textActivated=true;
                index++;
                timer=0.2f;
            }
            if(enterCounter ==6){
                textActivated=true;
                index++;
                timer=0.2f;
            }
            if(enterCounter ==7){
                textActivated=true;
                index++;
                timer=0.2f;
            }
            if(enterCounter==8){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }

        }
        if(skipinTimer>0){
            skipinTimer-= Time.deltaTime;
            enterBtn.SetActive(false);
        }else{
            enterBtn.SetActive(true);
        }
        if(timer>0){
            timer -= Time.deltaTime;
        }
        if(timer<=0 && textActivated){
            textObjects[index].SetActive(true);
            StartCoroutine(Type());
            textActivated = false;
            skipinTimer=2f;
          
        }
    }
    IEnumerator Type(){
        foreach(char letter in sentences[index].ToCharArray()){
            textDisplay[index].text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
