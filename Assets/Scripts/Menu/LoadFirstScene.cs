using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoadFirstScene : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(GetSceneName.firstRoom);
    }
}
