using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer vol;

    public void SetVol(float SliderVal)
    {
        vol.SetFloat("MusicVol", Mathf.Log10( SliderVal)*20);
    }
}
