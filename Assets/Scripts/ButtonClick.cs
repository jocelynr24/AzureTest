using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void HelloWorld()
    {
        Debug.Log("Hello World!");
    }

    public void AzureTest()
    {
        SceneManager.LoadScene(1);
    }

    public void PositionTest()
    {
        SceneManager.LoadScene(2);
    }
}
