using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public struct GameData
{
   public int[] _scores;
} 

public class SaveGameData:MonoBehaviour
{

    public GameData gameData;
    private const string saveName = "SaveGame";
    private const string directoryName = "Saves";

    //Singleton objects
    private static SaveGameData _instance;

    public static SaveGameData Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gameObject = new GameObject();
                _instance = gameObject.AddComponent<SaveGameData>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }


    // After each game over call this to save the best scores
    public void SaveToFile(int [] scores)
    {
        //To save the data into a directory it must be created first
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }
        
        //The formater will convert the data into a binary file
        BinaryFormatter formatter = new BinaryFormatter();

        //Chose the save location
        FileStream saveFile = File.Create(directoryName + "/" + saveName + ".bin");


        //copping data

        if(gameData._scores == null)
        {
            gameData._scores = new int[scores.Length];
        }

        for (int i = 0; i < scores.Length; i++)
        {
            gameData._scores[i] = scores[i];
        }


        //write our C# game data type to a binary file
        formatter.Serialize(saveFile, gameData);
        saveFile.Close();

        //Success message debug

        Debug.Log("Game Saved to " + Directory.GetCurrentDirectory().ToString() + "/Saves/" + saveName + ".bin");

    }



    //Load Game

    public GameData LoadGameScore()
    {

        if (Directory.Exists(directoryName) && File.Exists(directoryName + "/" + saveName + ".bin"))
        {

            //Converte Binary file back into readable data for unity game
            BinaryFormatter formatter = new BinaryFormatter();

            //Chosing the saved file to open
            FileStream saveFile = File.Open(directoryName + "/" + saveName + ".bin", FileMode.Open);

            //Convert the file data into 'save game data formate' to use in game
            GameData loadData = (GameData)formatter.Deserialize(saveFile);

            saveFile.Close();

            return loadData;
        }


        return gameData;
    }

}


