using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public static void LoadSceneAsync(string SceneName)
    {
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
    }
    public static void UnloadSceneAsync(string SceneName)
    {
        SceneManager.UnloadSceneAsync(SceneName);
    }
}
