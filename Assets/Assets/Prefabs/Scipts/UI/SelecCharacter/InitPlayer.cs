using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InitPlayer : MonoBehaviour
{   
    public static Character player;
    [SerializeField] private CinemachineVirtualCamera  virtualCamera;
    void Start()
    {
        if (playerSelected.selectedCharacter == null)
        {
            Debug.LogError("Selected character is null.");
            return;
        }
        GameObject selectedCharater=playerSelected.selectedCharacter;
        GameObject playerObject=Instantiate(selectedCharater,transform.position,Quaternion.identity);
        virtualCamera.Follow=playerObject.transform;
        virtualCamera.LookAt=playerObject.transform;
        playerObject.name="Player";

    }
}
