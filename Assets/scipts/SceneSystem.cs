using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSystem : MonoBehaviour
{
    [SerializeField] GameObject NextButon;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCount)
        {
            Destroy(NextButon.gameObject);
        }
    }

    public void ContinueDD()
    {
        this.gameObject.SetActive(false);
    }
    public void MoveToNextScene() {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitScene()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitTheGame() {
        Application.Quit();
    }
}
