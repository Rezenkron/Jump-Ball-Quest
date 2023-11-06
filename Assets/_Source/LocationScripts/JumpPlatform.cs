using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;

namespace LvlScripts
{
    public class JumpPlatform : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerLayer;
        [SerializeField] private float _knockForce;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (LayerChecker.CheckLayersEquality(collision.gameObject.layer, _playerLayer))
            {
                Vector2 ballDirection = transform.position - collision.gameObject.transform.position;
                
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(ballDirection.x, Mathf.Abs( ballDirection.y * _knockForce)), ForceMode2D.Impulse);
            }
        }
    }
}
