using LvlScripts;
using Service;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    private StarCollect _starCollect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerChecker.CheckLayersEquality(collision.gameObject.layer, _playerLayer))
        {
            _starCollect = collision.gameObject.GetComponent<StarCollect>();
            _starCollect.PlusScore();
            Destroy(gameObject);
        }
    }
}
