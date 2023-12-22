
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class SettingMenu : MonoBehaviour
{
    [Header("space between menu items")]
    [SerializeField] Vector2 spacing;

    [Header("Main button rotation")]

    [SerializeField] private float rotationDuration;
    [SerializeField] Ease rotationEase;

    [Header("Animation buttons")]

    [SerializeField] private float expandDuration;
    [SerializeField] private float collapseDuration;
    [SerializeField] Ease expandEase;
    [SerializeField] Ease collapseEase;

    [Space]
    [Header("Fading")]
    [SerializeField] float expandFadeDuration;
    [SerializeField] float collapseFadeDuration;
    Button mainButton;
    SettingMenuItem[] menuItems;
    bool isExpanded = false;
    Vector2 mainButtonPosition;
    int itemCount;
    void Start()
    {
        itemCount=transform.childCount-1;
        menuItems = new SettingMenuItem[itemCount];
        for(int i=0; i<itemCount; i++)
        {
            menuItems[i]= transform.GetChild(i+1).GetComponent<SettingMenuItem>();
        }
        mainButton=transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling();
        mainButtonPosition=mainButton.transform.position;
        ResetPosition();
    }
    void ResetPosition()
    {
        for(int i=0; i<itemCount; i++)
        {
            menuItems[i].trans.position=mainButtonPosition;
        }
    }
    void ToggleMenu()
    {
        isExpanded=!isExpanded;
        if(isExpanded)
        {
            for(int i = 0; i <itemCount ; i++) {
                // menuItems[i].trans.position=mainButtonPosition+spacing*(i+1);
                menuItems[i].trans.DOMove(mainButtonPosition+spacing*(i+1),expandDuration).SetEase(expandEase);
                menuItems[i].img.DOFade(1f,expandFadeDuration).From(0f);
            }
        }
        else
        {
            for(int i = 0; i <itemCount ; i++)
            {
                // menuItems[i].trans.position=mainButtonPosition;
                 menuItems[i].trans.DOMove(mainButtonPosition,collapseDuration).SetEase(collapseEase);
                menuItems[i].img.DOFade(1f,collapseFadeDuration).From(0f);

            }
        }
        mainButton.transform.DORotate(Vector3.forward*180f,rotationDuration).From(Vector3.zero).SetEase(rotationEase);
    }
    void OnDestroy()
    {
        mainButton.onClick.RemoveListener(ToggleMenu);
    }
}
