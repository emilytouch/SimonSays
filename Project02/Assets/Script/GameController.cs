using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Button[] button;
    public List<Button> list;
    public GameObject correct;
    public GameObject wrong;
    public Text text;
    public int levelCount;

	void Start () {
        SetLevelCount();

        button[0].interactable = false;
        button[1].interactable = false;
        button[2].interactable = false;
        button[3].interactable = false;

        StartCoroutine(Sequence());
    }

    void Update () {
		
	}

    void SetLevelCount()
    {
        text.text = "Level: " + levelCount;
    }

    IEnumerator Sequence() {
        yield return new WaitForSeconds(0.5f);
    }
}
