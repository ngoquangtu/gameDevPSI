using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class playerSelected : MonoBehaviour
{
    private int index;
    [SerializeField] GameObject[] characters;
    [SerializeField] TextMeshProUGUI characterName;
    [SerializeField] GameObject[] characterPrefabs;
    public static GameObject selectedCharacter;
     void Start()
    {
        index=0;
        selectedCharacter=characterPrefabs[0];
        disableCharacter();
        
    }
    public void OnPrevBtn()
    {   
        if(index>0)
        {
            index--;
        }
         CharacterSelected();
    }
    public void OnNextBtn()
    {
        if(index<characters.Length-1)
        {
            index++;
        }
         CharacterSelected();
    }
    private void CharacterSelected()
    {
        for(int i=0;i<characters.Length;i++)
        {
            if(i==index)
            {
                characters[i].GetComponent<SpriteRenderer>().color=Color.white;
                characters[i].GetComponent<Animator>().enabled=true;
                selectedCharacter=characterPrefabs[i];
                characterName.text=characterPrefabs[i].name;
            }
            else
            {
                characters[i].GetComponent<SpriteRenderer>().color=Color.black;
                characters[i].GetComponent<Animator>().enabled=false;
            }
        }
    }
    private void disableCharacter()
    {
        characters[0].GetComponent<SpriteRenderer>().color=Color.white;
        for(int i=1;i<characters.Length;i++)
        {
            characters[i].GetComponent<SpriteRenderer>().color=Color.black;
        }
    }
    public void startScene()
    {
        SceneManager.LoadScene(1);
    }
}
