using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateLevelButtins : MonoBehaviour
{
    [SerializeField] GameObject buttonsPrefab;
    int a;
    ChooseTheSceneSystem ChooseTheSceneSystem;

    private void Start()
    {
        a = SceneManager.sceneCountInBuildSettings;
        Debug.Log(a);
        for (int i = 1; i <= a-1; i++) {
            var b = Instantiate(buttonsPrefab, this.transform);
            ChooseTheSceneSystem = b.GetComponent<ChooseTheSceneSystem>();

            ChooseTheSceneSystem.GetSceneIndex(i);
        }
    }
}
