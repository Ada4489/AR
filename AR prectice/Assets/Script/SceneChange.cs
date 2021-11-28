using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{

    public TextMesh[] password;
    private int[] answer = new int[] { 1, 1, 1 };

    // Update is called once per frame
    void Update()
    {
        Answer_Check();
    }

    void Answer_Check()
    {
        int[] temp = new int[] { 0, 0, 0 };

        for (int i = 0; i < 3; i++)
            temp[i] = int.Parse(password[i].text);

        if(answer == temp)
        {
            SceneManager.LoadScene("Next");
        }
    }
}
