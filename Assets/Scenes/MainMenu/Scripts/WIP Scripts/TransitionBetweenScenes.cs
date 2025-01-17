﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

/*
 * DUE TO ISSUES WITH CUSTOM ENUMS IN UNITY EDITOR, THIS DOES NOT SEEM TO WORK
 */


public class TransitionBetweenScenes : MonoBehaviour
{
    // Keeping track of & having the ability to reference the Player's Data (and to save/load it)
    private GameObject saveManager;
    private PlayerData PD;

    // SteamVR Input Sources
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Input_Sources rightHand;

    private ModuleType upcomingModule;

    public string sceneToLoad;

    // Unity Editor menu items to quickly switch between scene settings and make the script easier to use
    private enum ModuleType
    {
        None,
        MainMenu,
        Education_EpiPen,
        Education_Other, // *** Change this to whatever additional modules are added later ***
        Training_EpiPen,
        Training_Other   // *** Change this to whatever additional modules are added later ***
    };
  
    // Actions that occur before Start()
    private void Awake()
    {
        saveManager = GameObject.FindGameObjectWithTag("SaveManager"); // Locating the saveManager within the scene
        PD = saveManager.GetComponent<PlayerData>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Depending on the option chosen in the Unity-Editor, this section will set the current module (any additional settings or updates may be added here as well)

        PD.Load(); // Loads any previously saved settings
        switch (upcomingModule)
        {
            case ModuleType.None:
                Debug.Log("A scene transition has not been assigned");
                break;
            case ModuleType.MainMenu:
                PD.currentModule = "MainMenu";
                sceneToLoad = "MainMenu";
                break;
            case ModuleType.Education_EpiPen:
                PD.currentModule = "Education_Epipen";
                sceneToLoad = "Education";
                break;
            case ModuleType.Education_Other:
                PD.currentModule = "Education_Other";
                sceneToLoad = "Education";
                break;
            case ModuleType.Training_EpiPen:
                PD.currentModule = "Training_Epipen";
                sceneToLoad = "Training";
                break;
            case ModuleType.Training_Other:
                PD.currentModule = "Training_Other";
                sceneToLoad = "Training";
                break;
        }
    }
    public void TransitionToEducation() 
    {
        // Save previously assigned settings (save is located here incase in the future, more PlayerData changes are made in this script)
        PD.Save();

        // Load the Education scene with those settings
        SceneManager.LoadScene("Education");
    }
    public void TransitionToTraining() 
    {
        // Save previously assigned settings (save is located here incase in the future, more PlayerData changes are made in this script)
        PD.Save();

        // Load the Training scene with those settings
        SceneManager.LoadScene("Training");
    }
    public void TransitionToMenu()
    {
        // Save previously assigned settings (save is located here incase in the future, more PlayerData changes are made in this script)
        PD.Save();

        // Load the MainMenu scene with those settings
        SceneManager.LoadScene("MainMenu");
    }















    // Update is called once per frame
    void Update()
    {
        /*if (SteamVR_Input.GetStateUp("GrabGrip", leftHand)) // When the object is released from the left hand
        {
            // Save previously assigned settings (save is located here incase in the future, more PlayerData changes are made in this script)
            PD.Save();

            // Load the Education scene with those settings
            SceneManager.LoadScene(sceneToLoad);
        }
        else if (SteamVR_Input.GetStateUp("GrabGrip", rightHand)) // When the object is released from the left hand
        {
            // Save previously assigned settings (save is located here incase future usage requires more PlayerData changes to be made in this script)
            PD.Save();

            // Load the Education scene with those settings
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            // Do nothing
        }*/
    }
}
