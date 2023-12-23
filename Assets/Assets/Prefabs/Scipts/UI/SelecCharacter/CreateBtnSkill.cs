using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateBtnSkill : MonoBehaviour
{

   [SerializeField] private GameObject redAvt;
    [SerializeField] private GameObject yellowAvt;  
    [SerializeField] private GameObject swordskillBtn;
    [SerializeField] private GameObject bombskillBtn;
    [SerializeField] private float fillSpeed = 0.1f;
    private Image imageswordSkill;
    private Image imagebombSkill;
    private bool number1Pressed=false;
    private bool spacePressed=false;
    private float fillswordTimer;
    private float fillbombTimer;
    [SerializeField] private float fillswordSkillDuration=7.0f;
    [SerializeField] private float fillbombSkillDuration=7.0f;

    private void CheckCharacter()
    {
        if(playerSelected.Instance.index==1)
        {
            CreateButton();
        }
        CreateAvartar();
    }
    private void Awake()
    {
        imageswordSkill = swordskillBtn.GetComponent<Image>();
        imagebombSkill = bombskillBtn.GetComponent<Image>();
    }
    private void Update()
    {
        UpdatebombSkillBtn();
        UpdateswordSkillBtn();
    }
    private void Start()
    {
        swordskillBtn.SetActive(false);
        bombskillBtn.SetActive(false);
        redAvt.SetActive(false);
        yellowAvt.SetActive(false);
        imageswordSkill.fillAmount=1;
        imagebombSkill.fillAmount=1;
        CheckCharacter();
    }
    void CreateButton()
    {
        swordskillBtn.SetActive(true);
        bombskillBtn.SetActive(true);
    }
    void CreateAvartar()
    {
        if(playerSelected.Instance.index==0)
        {
            yellowAvt.SetActive(true);
            redAvt.SetActive(false);
            
        }
        else if(playerSelected.Instance.index==1)
        {
            yellowAvt.SetActive(false);
            redAvt.SetActive(true);
        }
    }

    void UpdatebombSkillBtn()
    {
        if (bombskillBtn != null)
        {
            if (Input.GetKey("space") && !spacePressed)
            {
                spacePressed = true;
                imagebombSkill.fillAmount = 0;
                fillbombTimer = 0f;
            }

            if (spacePressed)
            {
                fillbombTimer += Time.deltaTime;

                float fillRatio = Mathf.Clamp01(fillbombTimer / fillbombSkillDuration);
                imagebombSkill.fillAmount = fillRatio;
                if (fillRatio >= 1.0f)
                {
                    spacePressed = false;
                }
            }
        }
    }
    void UpdateswordSkillBtn()
    {
        if (swordskillBtn != null)
        {
            if (Input.GetKey("1") && !number1Pressed)
            {
                number1Pressed = true;
                imageswordSkill.fillAmount = 0;
                fillswordTimer = 0f;
            }

            if (number1Pressed)
            {
                fillswordTimer += Time.deltaTime;


                float fillRatio = Mathf.Clamp01(fillswordTimer / fillswordSkillDuration);
                imageswordSkill.fillAmount = fillRatio;
                if (fillRatio >= 1.0f)
                {
                    number1Pressed = false;
                }
            }
        }
    } 
}
