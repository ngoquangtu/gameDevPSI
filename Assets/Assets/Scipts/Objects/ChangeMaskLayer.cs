using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cainos.PixelArtTopDown_Basic
{
public class ChangeMaskLayer : MonoBehaviour
{
        public LayerMask layerMask;
        public string sortingLayer;

        private void OnTriggerExit2D(Collider2D other)
        {
            if ((layerMask.value & (1 << other.gameObject.layer)) != 0)
            {
                other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
                SpriteRenderer[] srs = other.gameObject.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer sr in srs)
                {
                    sr.sortingLayerName = sortingLayer;
                }
            }
        }
}
}


