using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Track", menuName = "ScriptableObjects/Music")]
public class MusicData : ScriptableObject
{

    public AudioClip[] intro;
    public AudioClip[] loop;
    public AudioClip[] last;
    public int lastLoopSamples;
    
}
