using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Core.MemorySystem;
using UnityEngine.SceneManagement;

public class MenuBoton : MonoBehaviour
{

    [SerializeField]
    Button loadGameButton;

    [SerializeField]
    Button confirmDeleteButton;

    [SerializeField]
    Button cancelDeleteButton;

    [SerializeField]
    Button deleteButton;

    [SerializeField]
    GameObject confirmMenu;

    [SerializeField]
    Button closeButton;

    [SerializeField]
    Text gameName;

    [SerializeField]
    GameObject panel;

    [SerializeField]
    CurrentGameData currentGameData;

 


     void Awake()
    {
        loadGameButton.onClick.AddListener(LoadGame);
        confirmDeleteButton.onClick.AddListener(DeleteGame);
        closeButton.onClick.AddListener(ClosePanel);
        deleteButton.onClick.AddListener(ConfirmMenu);
        cancelDeleteButton.onClick.AddListener(ConfirmMenu);
    }

    public void LoadGame()
    {
        currentGameData.GameData = MemorySystem.LoadGame(gameName.text);
    }

    public void DeleteGame()
    {
        MemorySystem.EreaseGame(gameName.text);
        SceneManager.LoadScene("SampleScene");
        
    }

    public void ConfirmMenu()
    {
        bool isActive = confirmMenu.activeSelf;
        confirmMenu.SetActive(!isActive);
            

    }

    public void ClosePanel()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;

            panel.SetActive(!isActive);
        }
    }


}
