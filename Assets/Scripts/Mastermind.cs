using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mastermind : MonoBehaviour
{
    public bool AmIStart;
    public TextMeshProUGUI startText;

    public string leveltoload = "MainLevel";
    
    void Start()
    {
        startText.SetText( (AmIStart) ? "Start The Game\nClick Space" : "Restart The Game\nClick Space" );
        startText.color = (AmIStart) ? Color.green : Color.red;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Play();
        }
    }
    
    public void Play()
    {
        SceneManager.LoadScene(leveltoload);
    }
    
}
