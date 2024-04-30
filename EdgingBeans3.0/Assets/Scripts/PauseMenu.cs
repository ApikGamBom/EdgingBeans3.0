using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused = false;
    public GameObject optionsTab;
    public float UiDelay = 3f;
    public TextMeshProUGUI countdownText;
    public GameObject CountdownObj;
    public bool CountDone;
    public bool optionOpen = false;
    // public Transform targetPosition;
    // public RawImage  compassNeedle;
    void Start()
    {

    }
    void Update()
    {
        Vector3 directionToTarget = targetPosition.position - transform.position;
        float angle = Mathf.Atan2(directionToTarget.x, directionToTarget.z) * Mathf.Rad2Deg;
        compassNeedle.rectTransform.rotation = Quaternion.Euler(0, 0, -angle);

        if (Input.GetButtonDown("Cancel") && CountDone && optionOpen == false && optionsTab.CompareTag("gameScene"))
        {
            toggleMenu();
        }
        else if (Input.GetButtonDown("Cancel") && CountDone && optionOpen && optionsTab.CompareTag("gameScene"))
        {
            optionsTab.SetActive(false);
            optionOpen = false;
            toggleMenu();
            
        }
    }

    public void toggleMenu()
    {
        StartCoroutine(ToggleUi());
    }

    public IEnumerator ToggleUi()
    {
        float remainingTime = UiDelay;

        if (isPaused == true && optionOpen == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pauseMenu.SetActive(false);
            CountDone = false;
            CountdownObj.SetActive(true);
            while (remainingTime > 0)
            {
                countdownText.text = Mathf.Ceil(remainingTime).ToString();
                yield return new WaitForSecondsRealtime(1);
                remainingTime -= 1;
            }
            Time.timeScale = 1f;
            CountDone = true;
            CountdownObj.SetActive(false);
            countdownText.text = "";
        }
        else if (isPaused == false && optionOpen == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        isPaused = !isPaused;
        CountDone = true;
    }

    public void OptionsToggle()
    {
        optionsTab.SetActive(!optionsTab.activeSelf);
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        optionOpen = !optionOpen;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }
    public void GoToGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
