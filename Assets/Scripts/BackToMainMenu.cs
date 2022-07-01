using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(GetSceneName.mainMenu);
    }
}
