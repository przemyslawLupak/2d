using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
