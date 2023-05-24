using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
using System;
public class SoundSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    
    public Slider MasterSlider;
    public Slider BgmSlider;
    public Slider SfxSlider;

    // Update is called once per frame
    public void SetBgmVolume(){
        audioMixer.SetFloat("BGM", Mathf.Log10(BgmSlider.value)*20);
    }

    public void SetSFXVolume(){
        audioMixer.SetFloat("SFXS", Mathf.Log10(SfxSlider.value)*20);
    }

    public void SetMasterVolume(){
        audioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value)*20);
    }
    void Start(){
        /*
        try{
            MasterSlider.value = GameObject.Find("SoundValue").GetComponent<BringSoundSetting>().master;
            BgmSlider.value = GameObject.Find("SoundValue").GetComponent<BringSoundSetting>().bgm;
            SfxSlider.value = GameObject.Find("SoundValue").GetComponent<BringSoundSetting>().sfx;
        }
        catch(NullReferenceException ie){
            MasterSlider.value = 1;
            BgmSlider.value = 1;
            SfxSlider.value = 1;
        }
        */
    }
    public void Save(){
        PlayerPrefs.SetFloat("Master",MasterSlider.value);
        PlayerPrefs.SetFloat("BGM",BgmSlider.value);
        PlayerPrefs.SetFloat("SFX",SfxSlider.value);
    }
    
    public void Load(){
        if(PlayerPrefs.HasKey("Master")){
            MasterSlider.value = PlayerPrefs.GetFloat("Master");
            BgmSlider.value = PlayerPrefs.GetFloat("BGM");
            SfxSlider.value = PlayerPrefs.GetFloat("SFX");
        }
    }
}
