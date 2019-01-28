﻿using System.Collections;
using System.Collections.Generic;
using AR_Project.DataClasses.MainData;
using AR_Project.MainGame.ExperimentsLevels.ExperimentsHandlers;
using UnityEngine;
using UnityEngine.UI;

namespace AR_Project.MainGame.UI
{
    public class PrizeButtons: MonoBehaviour
    {
        public static PrizeButtons instance;

        public Button immediatePrizeButton;
        public Button secondPrizeButton;
        public Image firstButtonImage;
        public Image secondButtonImage;

        public List<Sprite> prizeImages;

        public int timerSecondPrize;

        public void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }

        public void SetSecondButtonUnavaiable()
        {
            secondPrizeButton.interactable = false;
        }

        IEnumerator TimerSecondPrizeButton()
        {
            Debug.Log("Timer Second Prize!!!");
            Debug.Log("Wait for " + timerSecondPrize);
            secondPrizeButton.interactable = false;
            yield return new WaitForSeconds(timerSecondPrize);
            Debug.Log("!!! Waited for " + timerSecondPrize);
            secondPrizeButton.interactable = true;
        }

        public void ReleaseSecondButton()
        {
            Debug.Log("released second button");
            secondPrizeButton.interactable = true;
        }

        public void StopTimer()
        {
            StopCoroutine(TimerSecondPrizeButton());
        }

        public void ClickedOnImmediatePrize()
        {
            Debug.Log("CLICKED ON IMMEDIATE PRIZE");
            var expHandler = gameObject.GetComponent<ExperimentPhaseHandler>();
            expHandler.CallbackFromUIButtons(true);
        }

        public void ClickedOnSecondPrize()
        {
            Debug.Log("CLICKED ON SECOND PRIZE");
            var expHandler = gameObject.GetComponent<ExperimentPhaseHandler>();
            expHandler.CallbackFromUIButtons(false);
        }

        public void SetButtons(string textImmediate, string textSecond, int firstPrizeValue, int secondPrizeValue)
        {
            immediatePrizeButton.GetComponentInChildren<Text>().text = textImmediate;
            secondPrizeButton.GetComponentInChildren<Text>().text = textSecond;
            firstButtonImage.sprite = GetPrizeImage(firstPrizeValue);
            secondButtonImage.sprite = GetPrizeImage(secondPrizeValue);
        }

        public Sprite GetPrizeImage(int prizeValue)
        {
            var prizes = MainData.instanceData.prizes.prizes;

            for (int i = 0; i < prizes.Count; i++)
            {
                if (prizes[i].value == prizeValue)
                {
                    return prizeImages[i];
                }
            }
            return null;
        }
    }
}
