using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PW_change : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public TextMesh[] password;
    private int password_point = 0;
    private int[] answer = new int[] { 1, 1, 1};

    // Update is called once per frame
    void Update()
    {
        Password_Change();
        Answer_check();
    }

    void Password_Change()
    {
        int temp = int.Parse(password[password_point].text);

        if (Input.touches.Length > 0)
        {

            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }

            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    if (temp == 9)
                        temp = 0;
                    else
                        temp++;

                    password[password_point].text = temp.ToString();
                }

                //swipe down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    if (temp == 0)
                        temp = 9;
                    else
                        temp--;

                    password[password_point].text = temp.ToString();
                }

                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    if (password_point == 0)
                        password_point = 0;
                    else
                        password_point--;
                }

                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    if (password_point == 2)
                        password_point = 2;
                    else
                        password_point++;
                }
            }
        }
    }

    void Answer_check()
    {
        int check1 = int.Parse(password[0].text);

        if (answer[0] == check1)
        {
            int check2 = int.Parse(password[1].text);

            if(answer[1] == check2)
            {
                int check3 = int.Parse(password[2].text);

                if(answer[2] == check3)
                    SceneManager.LoadScene("Next");
            }
        }
    }
}
