using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Button[] button; //putting buttons here ukno

    public List<int> list; //to keep adding
    public List<Button> buttonList; //so it can change color and shit
    public GameObject restart;

    public GameObject correct; //checkmark
    public GameObject wrong; //x mark
    public Text levelText; //displays level
    public int levelCount; //counts the level

    bool gameActive; //saves space
    int buttonNumber; //rng af
    int sequenceNumber; //keeps track of ^^

	void Start () {
        //starting from the beginning
        SetLevelCount();
        list.Clear();
        buttonList.Clear();

        button[0].interactable = false;
        button[1].interactable = false;
        button[2].interactable = false;
        button[3].interactable = false;

        correct.SetActive(false);
        wrong.SetActive(false);
        restart.SetActive(false);

        sequenceNumber = 0;
        buttonNumber = Random.Range(0, button.Length);
        buttonList.Add(button[buttonNumber]);
        list.Add(buttonNumber);
        StartCoroutine(Sequence());
    }

    void Update () {

        if(gameActive == true)
        {
            button[0].interactable = true;
            button[1].interactable = true;
            button[2].interactable = true;
            button[3].interactable = true;
        }

        else
        {
            button[0].interactable = false;
            button[1].interactable = false;
            button[2].interactable = false;
            button[3].interactable = false;
        }
	}

    void SetLevelCount()
    {
        levelText.text = "Level: " + levelCount;
    }

    IEnumerator Sequence() {
        for (int i = 0; i < list.Count; i++)
        {
            yield return new WaitForSeconds(0.65f);

            correct.SetActive(false);
            //means pls wait
            gameActive = false;

            //simulating button press vvvvv
            AudioSource audioSource = buttonList[i].GetComponent<AudioSource>();
            audioSource.Play();

            ColorBlock color = buttonList[i].colors;
            color.disabledColor = color.pressedColor;
            buttonList[i].colors = color;
            yield return new WaitForSeconds(1f);
            color.disabledColor = color.normalColor;
            buttonList[i].colors = color;

            gameActive = true;
        }
    }

    public void ButtonPress(int buttonPress)
    {
        if (gameActive == true)
        {
            if (list[sequenceNumber] == buttonPress) //meaning correct
            {
                sequenceNumber++;
                
                if (sequenceNumber >= buttonList.Count) //start again!!
                {
                    correct.SetActive(true);
                    sequenceNumber = 0;

                    buttonNumber = Random.Range(0, button.Length);
                    buttonList.Add(button[buttonNumber]);
                    list.Add(buttonNumber);
                    StartCoroutine(Sequence());
                    levelCount = levelCount + 1;
                    SetLevelCount();

                }
            }

            else //meaning wrong
            {
                gameActive = false;
                wrong.SetActive(true);
                AudioSource source = wrong.GetComponent<AudioSource>();
                source.Play();

                restart.SetActive(true);

            }
        }
    }

    public void ResetGame()
    {
        SetLevelCount();
        list.Clear();
        buttonList.Clear();

        button[0].interactable = false;
        button[1].interactable = false;
        button[2].interactable = false;
        button[3].interactable = false;

        correct.SetActive(false);
        wrong.SetActive(false);
        restart.SetActive(false);

        sequenceNumber = 0;
        buttonNumber = Random.Range(0, button.Length);
        buttonList.Add(button[buttonNumber]);
        list.Add(buttonNumber);
        StartCoroutine(Sequence());
    }
}
