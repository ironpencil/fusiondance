using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour {

    public PlayerInput playerInput;

    public List<GameObject> characters;

    int activeCharacterIndex = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            int index = activeCharacterIndex + 1;
            if (index >= characters.Count) { index = 0; }
            SwitchToCharacter(index);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            int index = activeCharacterIndex - 1;
            if (index < 0) { index = characters.Count - 1; }
            SwitchToCharacter(index);
        }

    }

    void SwitchToCharacter(int index)
    {
        index = Mathf.Clamp(index, 0, characters.Count - 1);

        if (index == activeCharacterIndex) { return; }

        GameObject currentChar = characters[activeCharacterIndex];
        GameObject newChar = characters[index];

        newChar.transform.position = currentChar.transform.position;
        currentChar.SetActive(false);
        newChar.SetActive(true);

        playerInput.movementController = newChar.GetComponent<BaseMovement>();
        playerInput.facingHandler = newChar.GetComponent<FacingHandler>();

        activeCharacterIndex = index;
        
    }
}
