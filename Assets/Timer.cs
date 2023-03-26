using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int sec = 0 , maxSec = 10;
    Coroutine da;
    bool isWorking = true;
    [SerializeField] Button PlayButton;
    [SerializeField] TextMeshProUGUI TimerText;

    public void Start()
    {
        da = StartCoroutine(timer());
    }
    private void Update()
    {
        if (!isWorking && PlayButton.interactable) {
            da = StartCoroutine(timer());
            isWorking = true;
        }
    }
    public void StartButtonClicked() {
        isWorking = false;
        sec = 0;
        StopCoroutine(da);
        TimerText.text = "00:00" ;
        
    }

    IEnumerator timer() {
        while (sec < maxSec + 1) {
            yield return new WaitForSeconds(1f);
            sec++;
            if (sec < 10)
            {
                TimerText.text = "00:0" + sec.ToString();
            }
            else {
                TimerText.text = "00:" + sec.ToString();
            }
            


        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
