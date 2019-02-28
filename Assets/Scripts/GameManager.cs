using System;
using System.Collections.Generic;
using UnityEngine;
using Core.MemorySystem;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
class GameManager : MonoBehaviour
{

    [SerializeField]
    Button loadGameButton;
    [SerializeField]
    Button deleteButton;
    [SerializeField]
    Button newGameButton;
    [SerializeField]
    Button saveGameButton;
    [SerializeField]
    InputField gameNameIF;

    [SerializeField]
    CurrentGameData currentGameData;

    [SerializeField]
    GameObject saveFileObj;

    public static GameManager instance;

    //Start
    void Awake()
    {
        instance = this;

        //loadGameButton.onClick.AddListener(LoadGame);
        newGameButton.onClick.AddListener(NewGame);
        saveGameButton.onClick.AddListener(SaveGame);
    }

    void Start()
    {
        PopulateSaveFilesPanel();
    }

    public void NewGame()
    {
        if (gameNameIF.text == null) return;
        MemorySystem.NewGame(gameNameIF.text);
        SceneManager.LoadScene("SampleScene");
    }

    public void SaveGame()
    {
        MemorySystem.SaveGame(currentGameData.GameData);
    }

 

    void PopulateSaveFilesPanel()
    {
        foreach (FileInfo fi in MemorySystem.FilePaths)
        {
            string gameName = Path.GetFileNameWithoutExtension(fi.Name);
            GameObject go = Instantiate(saveFileObj, saveFileObj.transform.parent) as GameObject;
            SaveFile sf = go.GetComponent<SaveFile>();
            sf.GameName = gameName;
            go.SetActive(true);
        }
    }
}
