using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChooseTheSceneSystem : MonoBehaviour
{
    int loadsceneIndex = 0;
    [SerializeField]TextMeshProUGUI sceneNumber;
    public void GetSceneIndex(int SceneIndex)
    {
        loadsceneIndex = SceneIndex;
        sceneNumber.text = loadsceneIndex.ToString();
    }


    public void LoadLevel() {
        SceneManager.LoadScene(loadsceneIndex);   
    }
}
