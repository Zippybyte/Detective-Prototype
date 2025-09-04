using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using UnityEditor.SearchService;
using UnityEngine.Rendering.Universal;
using UnityEditor;

public class SceneSwitcher : MonoBehaviour
{
    // List of Scenes
    public List<string> scenes;
    public List<string> allScenes = new List<string>();

    public void Start()
    {
        // Add all scenes in the build editor into the allScenes list
        foreach (var scene in EditorBuildSettings.scenes)
        {
            var sceneParts = scene.path.Split('/');
            var sceneTitle = sceneParts[sceneParts.Length - 1].Split('.')[0];

            // Debug.Log("Scene in build settings: " + sceneTitle);
            allScenes.Add(sceneTitle);
        }

        int sceneCount = SceneManager.sceneCountInBuildSettings;
        if (sceneCount < scenes.Count)
        {
            Debug.LogWarning("SceneSwitcher: There are more scenes in the list than in the build settings. Check Scene List.");
        }

        // Validate scene names
        foreach (var scene in scenes)
        {
            if (!allScenes.Contains(scene))
            {
                Debug.LogWarning("SceneSwitcher: Scene '" + scene + "' is not in the build settings. Check SceneSwitcher.");
            }
        }
    }

    public void switchSceneByName(string sceneName)
    {
        if (!allScenes.Contains(sceneName))
        {
            Debug.LogWarning("switchSceneByName: Scene '" + sceneName + "' is not valid. ");
            return;
        }

        SceneManager.LoadSceneAsync(sceneName);
    }
}
