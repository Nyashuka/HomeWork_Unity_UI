using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSomeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
