using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public Text[] password;
    private int password_point = 0;

    // Update is called once per frame
    void Update()
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
}
