using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGames.Base;
using CardGames.Core;
using UnityEngine.UI;
using System;

namespace CardGames.Screens
{

    public class Title : ScreenBase
    {
        private static Title instance;

        [SerializeField] Button garbageButton;

        public static void Show()
        {
            UIScreenManager.GetScreen(Constants.SCREENS_TITLE, g =>
            {
                instance.Setup();
            });
        }

        private void Setup()
        {
            id = Constants.SCREENS_TITLE;
        }

        private void Awake()
        {
            instance = GetComponent<Title>();           
        }

        void Start()
        {
            garbageButton.onClick.AddListener(() =>
            {
                AppManager.LoadGame(Data.GameTypes.Garbage);
            });
        }

        protected override void Close()
        {
            base.Close();
        }
    }
}