using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickChapter1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnclickChapter2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void OnclickChapter3()
    {
        SceneManager.LoadScene("Help");
    }

    public void OnclickQuit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
