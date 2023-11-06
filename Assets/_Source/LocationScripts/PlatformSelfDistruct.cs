using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;

namespace LvlScripts
{
    public class PlatformSelfDistruct : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerLayer;
        [SerializeField] private int _tuchesToDistruct;
        

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(LayerChecker.CheckLayersEquality(collision.gameObject.layer, _playerLayer))
            {
                if(_tuchesToDistruct<= 0)
                {
                    Destroy(gameObject,0.1f);
                }
                _tuchesToDistruct--;
            }
           
        }
    }
}
