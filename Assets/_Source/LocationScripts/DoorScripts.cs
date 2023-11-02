using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;

namespace LvlScripts
{
    public class DoorScripts : MonoBehaviour
    {
        [SerializeField] private LayerMask objectNeededLayer;
        [SerializeField] private GameObject _wallToOpen;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (LayerChecker.CheckLayersEquality(collision.gameObject.layer, objectNeededLayer))
            {
               Destroy(collision.gameObject);
                Destroy(_wallToOpen);
            }
        }
    }
}
