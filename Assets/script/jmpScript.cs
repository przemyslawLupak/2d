using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jmpScript : MonoBehaviour
{
   public void menu(){
       SceneManager.LoadScene("mainMenu");
   }
   public void restart(){
       SceneManager.LoadScene("SampleScene");
   }
}
