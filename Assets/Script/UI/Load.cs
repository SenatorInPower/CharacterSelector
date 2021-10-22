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
    private void OnEnable()
    {
        
        GenChar.onClick.AddListener(characterSelector.LoadHiro);
        LoadLevel.onClick.AddListener(characterSelector.LoadScen);
    }

   

    private void OnDisable()
    {
        GenChar.onClick.RemoveListener(characterSelector.LoadHiro);
        LoadLevel.onClick.RemoveListener(characterSelector.LoadScen);


    }


}
