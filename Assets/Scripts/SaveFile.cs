    using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class SaveFile : MonoBehaviour
{
    string gameName;

    public GameObject panel;

    Button myButton;
    [SerializeField]
    Text gameNameText;

    public string GameName { get => gameName; set => gameName = value; }

    private void Awake()
    {
        myButton = GetComponent<Button>();
      
    }

    private void Start()
    {
        gameNameText.text = gameName;
    }

    


  

    public void openPanel()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;

            panel.SetActive(panel);
        }
    }

}

