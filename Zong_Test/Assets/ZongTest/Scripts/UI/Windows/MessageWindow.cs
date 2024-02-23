using DG.Tweening;
using NaughtyAttributes;
using Scripts.Chest;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Scripts.UI
{
    public class MessageWindow : UIWindow
    {
        [SerializeField] private TextMeshProUGUI textAttached;
        [SerializeField] private Transform textTransform;
        [SerializeField] private Transform startPos;
        [SerializeField] private Transform endPos;

        private void OnEnable()
        {
            ChestBehavior.OnChestCollected += ShowText;
        }

        private void OnDisable()
        {
            ChestBehavior.OnChestCollected -= ShowText;
        }

        protected override void Reset()
        {
            textAttached = GetComponentInChildren<TextMeshProUGUI>();   
            base.Reset();
        }

        [Button]
        public void ShowTest()
        {
            ShowText("Testing 1,2,3");
        }


        public void ShowText(string text)
        {
            textAttached.text = text;
            textTransform.position = startPos.position;
            textTransform.localScale = Vector3.zero;

            textTransform.DOMove(endPos.position, 1.5f);
            textTransform.DOScale(Vector3.one, 1.0f).OnComplete(() =>
            {
                textTransform.DOScale(Vector3.zero, 0.5f);
            });
        
        
        }
    }

}
