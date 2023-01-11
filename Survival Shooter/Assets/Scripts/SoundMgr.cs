using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMgr : MonoBehaviour
{
    private static SoundMgr instance;
    public static SoundMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundMgr>();
            }
            return instance;
        }
    }

    public List<AudioSource> effectAudioSources;

    public Camera cam;

    public Slider musicSlider;
    public Slider effectSlider;
    private bool isOn = true;
    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.        
        musicSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        effectSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        SetBgVolume(musicSlider.value);
        SetEffVolume(effectSlider.value);
    }

    void SetEffVolume(float volume)
    {
        foreach (AudioSource source in effectAudioSources)
        {
            if (source != null)
            {
                source.volume = volume;
            }
        }
    }
    void SetBgVolume(float volume)
    {
        var musicAudio = cam.GetComponent<AudioSource>();
        musicAudio.volume = volume;
    }

    public void OnOffSound(bool acitve)
    {
        Debug.Log("µé¾î¿È");
        isOn = !isOn;
        if (isOn)
        {
            SetEffVolume(50f);
            SetBgVolume(50f);
        }
        else
        {
            SetEffVolume(0f);
            SetBgVolume(0f);
        }
    }
}
