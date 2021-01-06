﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
    //================================================================================
    // Public Variables ==============================================================
    //================================================================================
    public Button playButton;
    public Button optionsButton;
    public Button backButton;
    public Button quitButton;
    public GameObject mainMenu;
    public GameObject optionMenu;

    //================================================================================
    // Private Variables =============================================================
    //================================================================================

    //================================================================================
    // Start is called before the first frame update =================================
    //================================================================================
    void Start()
    {
        playButton.onClick.AddListener(PlayMaze);
        quitButton.onClick.AddListener(QuitMaze);
        optionsButton.onClick.AddListener(OptionsMenu);
        backButton.onClick.AddListener(BackToMain);
    }

    //================================================================================
    // Update is called once per frame ===============================================
    //================================================================================
    void FixedUpdate()
    {
        
    }

    //================================================================================
    // Other Functions ===============================================================
    //================================================================================
    // Start the game
    public void PlayMaze()
    {
        SceneManager.LoadScene("maze");
    }
    // Ends the game...
    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
    // Takes out the options
    public void OptionsMenu()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }
    // Go back to main
    public void BackToMain()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
    }

}
