using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SystemStartScene : MonoBehaviour
{

    [SerializeField] List<GameObject> ObjectsToOn = new List<GameObject>();
    [SerializeField] List<GameObject> ObjectsToOff = new List<GameObject>();
    public void StartFirstLevel() {
        SceneManager.LoadScene(1);
    }
    public void PickTheLevel()
    {
        foreach (GameObject obj in ObjectsToOff)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in ObjectsToOn)
        {
            obj.SetActive(true);
        }
    }
    public void CloseTheGame()
    {
        Application.Quit();
    }
}
