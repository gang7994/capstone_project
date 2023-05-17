using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
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
}
