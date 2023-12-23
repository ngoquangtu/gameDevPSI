using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelRegame : MonoBehaviour
{
    [SerializeField] private GameObject panelRegame;
    public static PanelRegame Instance;
    public bool checkRegame=false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        panelRegame.SetActive(false);
        checkRegame=false;

    }
    private void Update()
    {
        if(healthManager.Instance.isDead)
        {
            panelRegame.SetActive(true);
        }
    }
    public void Regame()
    {
        SceneManager.LoadScene(0);
        healthManager.Instance.isDead=true;
        checkRegame=true;

    }
    public void exitGame()
    {
        Application.Quit();
    }

}
