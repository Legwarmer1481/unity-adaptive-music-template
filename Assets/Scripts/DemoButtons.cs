using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoButtons : MonoBehaviour
{
    [SerializeField] MusicData song;
    MusicManager musicManager;
    float quietVolume = 1f;
    float mediumVolume = 1f;
    float dynamicVolume = 1f;
    float otherVolume = 1f;

    void Start(){

        musicManager = GetComponent<MusicManager>();
    }

// ==================================================================
    public void StartMusic(){

        musicManager.MusicStart(song);
    }
    
    public void StartQuiet(){

        musicManager.MusicStart(song, 1f, 0f, 0f, 0f);
        quietVolume = 1f;
        mediumVolume = 0f;
        dynamicVolume = 0f;
        otherVolume = 0f;
    }
    
    public void StartMedium(){

        musicManager.MusicStart(song, 0f, 1f, 0f, 0f);
        quietVolume = 0f;
        mediumVolume = 1f;
        dynamicVolume = 0f;
        otherVolume = 0f;
    }
    
    public void StartDynamic(){

        musicManager.MusicStart(song, 0f, 0f, 1f, 0f);
        quietVolume = 0f;
        mediumVolume = 0f;
        dynamicVolume = 1f;
        otherVolume = 0f;
    }
    
    public void StartOther(){

        musicManager.MusicStart(song, 0f, 0f, 0f, 1f);
        quietVolume = 0f;
        mediumVolume = 0f;
        dynamicVolume = 0f;
        otherVolume = 1f;
    }

    // ==============================================================

    public void QuietOn(){

        musicManager.EditLayer(1f, mediumVolume, dynamicVolume, otherVolume);
        quietVolume = 1f;
    }

    public void MediumOn(){

        musicManager.EditLayer(quietVolume, 1f, dynamicVolume, otherVolume);
        mediumVolume = 1f;
    }

    public void DynamicOn(){

        musicManager.EditLayer(quietVolume, mediumVolume, 1f, otherVolume);
        dynamicVolume = 1f;
    }
    
    public void OtherOn(){

        musicManager.EditLayer(quietVolume, mediumVolume, dynamicVolume, 1f);
        otherVolume = 1f;
    }
    public void QuietOff(){

        musicManager.EditLayer(0f, mediumVolume, dynamicVolume, otherVolume);
        quietVolume = 0f;
    }

    public void MediumOff(){

        musicManager.EditLayer(quietVolume, 0f, dynamicVolume, otherVolume);
        mediumVolume = 0f;
    }

    public void DynamicOff(){

        musicManager.EditLayer(quietVolume, mediumVolume, 0f, otherVolume);
        dynamicVolume = 0f;
    }
    
    public void OtherOff(){

        musicManager.EditLayer(quietVolume, mediumVolume, dynamicVolume, 0f);
        otherVolume = 0f;
    }

    // ===============================================================

    public void Fade(){

        musicManager.EditLayer(0f, 0f, 0f, 0f);
    }

    public void Finisher(){
        
        musicManager.MusicPlayLastLoop();
    }
}
