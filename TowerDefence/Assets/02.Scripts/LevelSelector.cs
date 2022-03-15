using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    private string selectedLevelSceneName;
    public void SelectLevel(string sceneName)
    {
        selectedLevelSceneName = sceneName;
    }
    public void PlaySelectedLevel()
    {

        GameManager.LoadSceneByName(selectedLevelSceneName);
    }
}
