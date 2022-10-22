using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{

    public TMP_InputField playerUsername;
    public TMP_Text bestScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        // Load player data if that was saved
        PersistentManager.Instance.LoadPlayerData();
        
        // Save player name to switch between scenes
        playerUsername.text = PersistentManager.Instance.playerName;
        bestScoreText.text = $"Best Score: {PersistentManager.Instance.playerName}: {PersistentManager.Instance.bestScore}";
        

    }

    // Update is called once per frame
    void Update()
    {
        PersistentManager.Instance.playerName = playerUsername.text;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        
    }

    public void Exit()
    {
        PersistentManager.Instance.SavePlayerData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
