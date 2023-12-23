using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    private AudioSource selectedSound;
    public Button button;

    private void Awake()
    {
        selectedSound=GetComponent<AudioSource>();
    }
    private void Start()
    {
        // Add a listener to the button click event
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // Play sound when the button is clicked
        selectedSound.Play();

        // Add your additional logic here if needed

        // Load the next scene
        startScene();
    }

    public void startScene()
    {
        SceneManager.LoadScene(1);
    }
}
