using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject LevelButtons;
    private void Awake()
    {
        ButtonsToArray();
        int UnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < UnlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }

    }
    public void OpenLevel(int levelID)
    {
        string levelName = "Level" + levelID;
        SceneManager.LoadScene(levelName);
    }

    void ButtonsToArray()
    {
        int childCount = LevelButtons.transform.childCount;
        buttons = new Button[childCount];
        for (int i = 0; i < childCount; i++)
        {
            buttons[i] = LevelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }
}
