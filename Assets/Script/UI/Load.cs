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
    private void OnEnable()
    {
        GenChar.onClick.AddListener(new CharacterSelector().LoadHiro);
        LoadLevel.onClick.AddListener(new CharacterSelector().LoadScen);
    }

   

    private void OnDisable()
    {
        GenChar.onClick.RemoveListener(new CharacterSelector().LoadHiro);
        LoadLevel.onClick.RemoveListener(new CharacterSelector().LoadScen);


    }


}
