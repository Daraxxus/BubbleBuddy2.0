using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangeViaVol : MonoBehaviour
{
    private Slider slider;
    public AudioListener master;
    public AudioSource music;
    public float MaxVolume = 1.0f;
    public Image fill;
    public Color MaxVolumeColor = Color.green;
    public Color MinVolumeColor = Color.red;

    // Use this for initialization
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.minValue = 0.0f;
        slider.maxValue = MaxVolume;
        slider.value = MaxVolume;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateMasterVolumeBar(float val)
    {
        AudioListener.volume = val;
        fill.color = Color.Lerp(MinVolumeColor, MaxVolumeColor, val / MaxVolume);
    }

    public void UpdateMusicVolumeBar(float val)
    {
        music.volume = val;
        fill.color = Color.Lerp(MinVolumeColor, MaxVolumeColor, val / MaxVolume);
    }
}
