using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endingScreenScript : MonoBehaviour
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
    public AudioSource shot;
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
            scenes[enterCounter].SetActive(true);
            if(enterCounter==1){
                textActivated =true;
                timer = 0.4f;
            }
            if(enterCounter==3){
                textActivated=true;
                timer=0.2f;
                index++;
            }
            skipinTimer = 0.4f;
            if(enterCounter ==4){
                shot.Play();
                textActivated=true;
                activated=false;
                index++;
                timer=0.2f;
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
            skipinTimer=3f;
            if(index>0){
                skipinTimer=1f;
            }
        }
    }
    IEnumerator Type(){
        foreach(char letter in sentences[index].ToCharArray()){
            textDisplay[index].text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
