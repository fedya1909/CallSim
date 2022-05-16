using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMoving : MonoBehaviour
{
    public GameObject ChoicePerson;
    public GameObject StartGame;
    public GameObject Settings;
    public GameObject Menu;
    private SnapScrolling _snapScrolling;

    public bool TrainingCheck = false;

    private void Start()
    {
        _snapScrolling = GetComponent<SnapScrolling>();
        Menu.SetActive(true);
    }

    public void StartGameClick()
    {
        Menu.SetActive(!Menu.activeSelf);
        StartGame.SetActive(true);
    }

    public void SettingsClick()
    {
        Menu.SetActive(!Menu.activeSelf);
        Settings.SetActive(!Settings.activeSelf);
    }

    public void BackMenu(GameObject gameObject)
    {
        gameObject.SetActive(false);
        Menu.SetActive(true);
    }

    public void TrainingClick(GameObject gameObject)
    {
        if (gameObject.name == "Yes")
        {
            TrainingCheck = true;
        }
        else
        {
            TrainingCheck = false;
        }
        StartGame.SetActive(false);
        ChoicePerson.SetActive(true);
    }

    public void LoadGameScene()
    {
        if (_snapScrolling.GetScrolling() == true)
        {
            return;
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
