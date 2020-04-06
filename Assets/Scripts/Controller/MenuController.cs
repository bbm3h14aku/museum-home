using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Editor()
    {
        SceneManager.LoadScene(1);
        this.Close();
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}
