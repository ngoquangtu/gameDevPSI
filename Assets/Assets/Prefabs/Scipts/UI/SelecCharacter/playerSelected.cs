using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class playerSelected : MonoBehaviour
{
    public int index;
    [SerializeField] GameObject[] characters;
    [SerializeField] Text characterName;
    [SerializeField] GameObject[] characterPrefabs;
    [SerializeField] GameObject[] inforcharacterPrefabs;
    public static GameObject selectedCharacter;
    [SerializeField] private AudioSource chooseSound;

    public static playerSelected Instance;

    private void Awake()
    {
        if(Instance==null)
        {
            Instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
     void Start()
    {
        index=0;
        selectedCharacter=characterPrefabs[0];
        inforcharacterPrefabs[0].SetActive(true);
         inforcharacterPrefabs[1].SetActive(false);
        disableCharacter();

        
    }
    public void OnPrevBtn()
    {   
        if(index>0)
        {
            index--;
        }
        PlayChooseSound();
         CharacterSelected();
         InforSelected();
    }
    public void OnNextBtn()
    {
        if(index<characters.Length-1)
        {
            index++;
        }
        PlayChooseSound();
         CharacterSelected();
         InforSelected();
    }
    private void PlayChooseSound()
    {
        if (!chooseSound.isPlaying)
        {
            chooseSound.Play();
        }
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
    private void InforSelected()
    {
        for(int i=0;i<characters.Length;i++)
        {
            if(i==index)
            {
                inforcharacterPrefabs[i].SetActive(true);
            }
            else
            {
                inforcharacterPrefabs[i].SetActive(false);
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
        SceneManager.LoadScene(2);
    }
}
