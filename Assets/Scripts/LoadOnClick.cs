﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)//function fyrir menu takka sem breytir um scene
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
