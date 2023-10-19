using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
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
        SceneManager.LoadScene("Main");
    }

    public void OnclickChapter2()
    {
        SceneManager.LoadScene("SampleScene 1");
    }
}
