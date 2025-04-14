using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ProgressControl : MonoBehaviour
{
    public UnityEvent<string> OnStartGame;
    public UnityEvent<string> OnChallengeComplete;


    [Header("Interactables")]
    [SerializeField]
    ButtonInteractable buttonInteractable;

    [SerializeField]
    GameObject keyInteractableLight;

    [SerializeField]
    string startGameString;

    [SerializeField]
    string[] challengeStrings;

    bool startGame;
    int challengeNum;

    //Called before first frame update
    void Awake()
    {
        //Tell button interactable to list to method when it is selected
        if (buttonInteractable != null)
        {
            buttonInteractable.selectEntered.AddListener(ButtonInteractablePressed);
        }

        OnStartGame?.Invoke(startGameString);
    }

    //Method for when button is pressed
    void ButtonInteractablePressed(SelectEnterEventArgs arg0)
    {
        if (!startGame)
        {
            startGame = true;
            //Temportaty array assignment
            if (keyInteractableLight != null)
            {
                keyInteractableLight.SetActive(true);
            }

            if (challengeNum < challengeStrings.Length)
            {
                OnStartGame?.Invoke(challengeStrings[challengeNum]);
            }
        }


    }
}
