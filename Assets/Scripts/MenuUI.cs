using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI highestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowScoreCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNew()
    {
        DataManager.Instance.SaveName();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void SaveUserName(string input)
    {
        DataManager.Instance.userName = input;
        Debug.Log(DataManager.Instance.userName);
    }

    IEnumerator ShowScoreCoroutine()
    {
        yield return new WaitForSeconds(2);
        highestScoreText.text = "Best score: " + DataManager.Instance.userName;
    }
}
