﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // This Class contains what the active session data is, and is in change of loading/saving to the data file

    // Game Data
    public int totalEPIQuizPasses;
    public int totalEPIQuizFailures;

    public int totalEPIPassedSimulations;
    public int totalEPIFailedSimulations;

    // Education Data
    public bool isEducated_EPI;
    public bool isTrained_EPI;

    // Education Data - Quiz


    // Current Active Module
    public string currentModule;


    public PlayerDataSet saveData;

    public void Start()
    {
        saveData = new PlayerDataSet();
    }

    // Saves all PlayerData to a file
    public void Save() 
    {
        // Game Data
        saveData.totalEPIQuizPasses = this.totalEPIQuizPasses;
        saveData.totalEPIQuizFailures = this.totalEPIQuizFailures;

        saveData.totalPassedSimulations = this.totalEPIPassedSimulations;
        saveData.totalFailedSimulations = this.totalEPIFailedSimulations;

        // Education Data
        saveData.isEducated_EPI = this.isEducated_EPI;
        saveData.isTrained_EPI = this.isTrained_EPI;

        // Education Data - Quiz


        // Current Active Module
        saveData.currentModule = this.currentModule;


        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, saveData);
        file.Close();
    }

    // Loads PlayerData from the save file (if no save file exists, generate a new one and assign it default values)
    public void Load() 
    {
        string destination = Application.persistentDataPath + "/savefile.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            GenerateDefaults();
            Save();
            file = File.OpenRead(destination);
        }

        BinaryFormatter bf = new BinaryFormatter();
        saveData = (PlayerDataSet)bf.Deserialize(file);
        file.Close();

        this.totalEPIQuizPasses = saveData.totalEPIQuizPasses;
        this.totalEPIQuizFailures = saveData.totalEPIQuizFailures;

        this.totalEPIPassedSimulations = saveData.totalPassedSimulations;
        this.totalEPIFailedSimulations = saveData.totalFailedSimulations;

        this.isEducated_EPI = saveData.isEducated_EPI;
        this.isTrained_EPI = saveData.isTrained_EPI;

        this.currentModule = saveData.currentModule;
    }

    public void GenerateDefaults()
    {
        this.totalEPIQuizPasses = 0;
        this.totalEPIQuizFailures = 0;

        this.totalEPIPassedSimulations = 0;
        this.totalEPIFailedSimulations = 0;

        this.isEducated_EPI = false;
        this.isTrained_EPI = false;

        this.currentModule = "null";
    }
}
