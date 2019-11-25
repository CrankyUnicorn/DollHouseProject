using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangePreferences : MonoBehaviour {


	// Use this for initialization
	void Start () {
        ApplyPreferences();
    }

    

    public void ApplyPreferences()
    {
        if (ContainerPreferences.ins.loadedPreferences.Language != null)
        {
            //change language
        }

        if (ContainerPreferences.ins.loadedPreferences.UITheme != null)
        {
            //change UI theme
            //BUT FIRST THE FALLOWING MUST BE ADDED TO THE CLASSPRENCES
            //buttons sprite list or name of image files list
            //music list or name of music files list
        }


        //mutes sound true or false


        if (ContainerPreferences.ins.loadedPreferences.masterVolume > 0 && ContainerPreferences.ins.loadedPreferences.masterVolume < 100)
        {
            //change language
        }

        if (ContainerPreferences.ins.loadedPreferences.musicVolume > 0 && ContainerPreferences.ins.loadedPreferences.musicVolume > 100)
        {
            //change language
        }

        if (ContainerPreferences.ins.loadedPreferences.effectVolume > 0 && ContainerPreferences.ins.loadedPreferences.effectVolume > 100)
        {
            //change language
        }

        if (ContainerPreferences.ins.loadedPreferences.voiceVolume > 0 && ContainerPreferences.ins.loadedPreferences.voiceVolume > 100)
        {
            //change language
        }


        //change fullscreen true or false

        //FRAME RATE
        if (ContainerPreferences.ins.loadedPreferences.frameRate != 0)
        {
            Application.targetFrameRate = ContainerPreferences.ins.loadedPreferences.frameRate; //changes game frame rate
        }

        //QUALITY
        string[] qualityNames = QualitySettings.names;
        for (int i = 0; i < qualityNames.Length; i++)
        {
            if (ContainerPreferences.ins.loadedPreferences.graphicQuality == qualityNames[i])
            {
                QualitySettings.SetQualityLevel(i, true);
            }
        }



        //editorEnabled true or false


        if (ContainerPreferences.ins.loadedPreferences.editorType != null)
        {
            //change editor preference on opening it
        }


        //change hotEnabled

    }
}
