using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Service;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;

namespace LvlScripts
{
    public class StarCollect : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _pointsPerHit;
        
        private float _score;
        private void Update()
        {
            _text.text = "Score:" + _score;
        }

        public void PlusScore()
        {
            _score += _pointsPerHit;
            _text.text = "Score:" + _score;
        }
    }
}
