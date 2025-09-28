using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public GameObject TaskPanel;
    public GameObject MainPanel;
    public GameObject BagPanel;

    bool isTaskPanelActive = false;
    bool isMainPanelActive = false;
    bool isBagPanelActive = false;


    public void OnOffTaskPanel()
    {
        if (isTaskPanelActive)
        {
            TaskPanel.SetActive(false);
            isTaskPanelActive = false;
        }
        else
        {
            MainPanel.SetActive(false);
            isMainPanelActive = false;
            BagPanel.SetActive(false);
            isBagPanelActive = false;
            TaskPanel.SetActive(true);
            isTaskPanelActive = true;
        }
    }

    public void OnOffMainPanel()
    {
        if (isMainPanelActive)
        {
            MainPanel.SetActive(false);
            isMainPanelActive = false;
        }
        else
        {
            TaskPanel.SetActive(false);
            isTaskPanelActive = false;
            BagPanel.SetActive(false);
            isBagPanelActive = false;
            MainPanel.SetActive(true);
            isMainPanelActive = true;
        }
    }

    public void OnOffBagPanel()
    {
        if (isBagPanelActive)
        {
            BagPanel.SetActive(false);
            isBagPanelActive = false;
        }
        else
        {
            TaskPanel.SetActive(false);
            isTaskPanelActive = false;
            MainPanel.SetActive(false);
            isMainPanelActive = false;
            BagPanel.SetActive(true);
            isBagPanelActive = true;
        }
    }
}
