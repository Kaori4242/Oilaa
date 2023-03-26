using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelSystem : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;


    public void OnPausePanel() {
        PausePanel.SetActive(true);
    }
    public void OffPausePanel()
    {
        PausePanel.SetActive(false);
    }

}
