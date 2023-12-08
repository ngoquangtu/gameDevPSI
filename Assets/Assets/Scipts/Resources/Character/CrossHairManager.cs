using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairManager : MonoBehaviour
{
    [SerializeField] private GameObject crossHair;
    private Vector3 crosshairPosition;
    private Vector3 mousePosition;
    private float smoothSpeed = 100f;

    public void UpdateCrosshair()
    {
          if (crossHair != null)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StartPosCrossHair();
        }
        else
        {
            Debug.LogError("Crosshair object is not assigned.");
        }
    }

    private void StartPosCrossHair()
    {
        crosshairPosition = crossHair.transform.position;
        Vector3 targetPosition = new Vector3(mousePosition.x, mousePosition.y, 0f);
        crosshairPosition = Vector3.Lerp(crosshairPosition, targetPosition, smoothSpeed * Time.deltaTime);
        crossHair.transform.localPosition = crosshairPosition;
    }
}
