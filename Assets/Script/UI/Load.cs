using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
   
    public Button GenChar;
    public Button LoadLevel;
    CharacterSelector characterSelector => new CharacterSelector();
    private void Awake()
    {
    
        GenChar.onClick.AddListener(characterSelector.LoadHiro);
        LoadLevel.onClick.AddListener(characterSelector.LoadScenGame);
    }

   

    private void OnDestroy()
    {
        GenChar.onClick.RemoveListener(characterSelector.LoadHiro);
        LoadLevel.onClick.RemoveListener(characterSelector.LoadScenGame);


    }
   


}
