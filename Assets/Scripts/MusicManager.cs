using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioMixer musicMixer;

    private AudioSource[] musics;
    private MusicData musicPlaying;
    private bool insideIntro = false;

    void Start()
    {

        musics = GetComponents<AudioSource>();
        
    }

    public void MusicStart(MusicData song, float volumeQuiet = 1f, float volumeMedium = 1f, float volumeDynamic = 1f, float volumeOther = 1f){
        
        insideIntro = true;
        musicPlaying = song;

        EditLayer(volumeQuiet, volumeMedium, volumeDynamic, volumeOther, 0.01f);

        for(int i = 0; i < musics.Length; i++){
            
            if(i < song.intro.Length){

                musics[i].clip = song.loop[i];
                musics[i].loop = true;
                musics[i].PlayOneShot(song.intro[i]);
                musics[i].PlayScheduled(AudioSettings.dspTime + song.intro[i].length);
            }else{

                musics[i].clip = null;
            }
        }

        Invoke("IntroComplete", song.intro[0].length);
    }

    public void EditLayer(float volumeQuiet = 1f, float volumeMedium = 1f, float volumeDynamic = 1f, float volumeOther = 1f,  float transitionTime = 3f){
        
        StartCoroutine(FadeMixerGroup.StartFade(musicMixer, "Quiet", transitionTime, volumeQuiet));
        StartCoroutine(FadeMixerGroup.StartFade(musicMixer, "Medium", transitionTime, volumeMedium));
        StartCoroutine(FadeMixerGroup.StartFade(musicMixer, "Dynamic", transitionTime, volumeDynamic));
        StartCoroutine(FadeMixerGroup.StartFade(musicMixer, "Other", transitionTime, volumeOther));

        if(volumeQuiet == 0 && volumeMedium == 0 && volumeDynamic == 0 && volumeOther == 0){

            Invoke("StopMusic", transitionTime + 0.5f);
        }
    }

    void StopMusic(){

        musicPlaying = null; 
        insideIntro = false;
        CancelInvoke("IntroComplete");
        
        for(int i = 0; i < musics.Length; i++){

            musics[i].Stop();
            musics[i].clip = null;
        }
    }

    public void MusicPlayLastLoop(){

        int timePosition;
        int timePositionThreshold = musicPlaying.lastLoopSamples;

        if(musics[0].clip != musicPlaying.last[0] && !insideIntro){

            timePosition = musics[0].timeSamples;
            if(timePosition <= timePositionThreshold){

                for(int i = 0; i < musics.Length; i++){
                        
                    if(i < musicPlaying.last.Length){
                        
                        musics[i].clip = musicPlaying.last[i];
                        musics[i].timeSamples = timePosition;
                        musics[i].loop = false;
                        musics[i].Play();
                            
                    }else{

                        musics[i].clip = null;
                    }
                }

            }
        }
    }

    void IntroComplete(){

        insideIntro = false;
    }

}
