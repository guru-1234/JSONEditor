using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDice : MonoBehaviour
{


   
    public float rotationSpeed = 90f;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotate 90 degrees to the left
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // Rotate 90 degrees to the right
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            // Rotate 90 degrees upwards
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // Rotate 90 degrees downwards
            transform.Rotate(Vector3.right, -rotationSpeed * Time.deltaTime);
        }

        //// Check for input to show number 1
        //if (Input.GetKey(KeyCode.Alpha1))
        //{
        //    // Rotate the dice to show number 1
        //    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //}
        //else if(Input.GetKey(KeyCode.Alpha6))
        //{
        //    transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        //}else if(Input.GetKey(KeyCode.Alpha5))
        //{
        //    transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        //}
        //else if (Input.GetKey(KeyCode.Alpha2))
        //{
        //    transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        //}
        //else if (Input.GetKey(KeyCode.Alpha4))
        //{
        //    transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        //}
        //else if (Input.GetKey(KeyCode.Alpha3))
        //{
        //    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        //}
    }

    public void KeyPressed(int val)
    {
        switch (val)
        {
            case 1:
               
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;
            case 6:
                transform.rotation = Quaternion.Euler(90f, 0f, 0f);
                break;
            case 5:
                transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
                break;
            case 2:
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                break;
            case 4:
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                break;
            default:
                // No valid key pressed
                break;
        }
    }


}
