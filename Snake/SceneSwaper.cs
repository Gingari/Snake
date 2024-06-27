using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class SceneSwaper : MonoBehaviour
{
    public void ChangeScene(string name) 
    { 
        SceneManager.LoadScene(name);
    }
    public void Exit() 
    {
        Application.Quit();
    }
}
