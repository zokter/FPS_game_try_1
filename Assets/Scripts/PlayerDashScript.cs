using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerDashScript : MonoBehaviour
{
    KeyCode[] myKeys = new KeyCode[4]; // array of 

    PlayerMovementScript moveScript;

    private KeyCode actualInput;
    private KeyCode previousInput;

    private float lastTimeInput;
    private float doubleClickTime = 0.2f;
    private float dashTime = 0.25f;
    public float dashMultiplier = 50f;

    private void Start()
    {
        moveScript = GetComponent<PlayerMovementScript>();

        myKeys[0] = (KeyCode.W);
        myKeys[1] = (KeyCode.S);
        myKeys[2] = (KeyCode.A);
        myKeys[3] = (KeyCode.D);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey) && checkIfControll(vKey))
            {
                float timeSinceLastInput = Time.time - lastTimeInput;
                writePreviousKeyCode(actualInput);
                actualInput = vKey;
                if (timeSinceLastInput < doubleClickTime)
                {
                    if (actualInput == previousInput)
                    {
                        StartCoroutine(Dash());
                    }
                    else
                    {
                    }
                }
                lastTimeInput = Time.time;
            }
        }
    }

    bool checkIfControll(KeyCode key)
    {
        for (int i = 0; i < myKeys.Length; i++)
        {
            if (key == myKeys[i])
            {
                return true;
            }
        }
        return false;
    }

    void writePreviousKeyCode(KeyCode lastActual)
    {
        previousInput = lastActual;
    }

    IEnumerator Dash()
    {
        float startStrafeTime = Time.time;
        while (Time.time < startStrafeTime + dashTime)
        {
            Debug.Log("Fuck.");
            moveScript.controller.Move(moveScript.move * dashMultiplier * Time.deltaTime);
            yield return null;
        }
    }
}