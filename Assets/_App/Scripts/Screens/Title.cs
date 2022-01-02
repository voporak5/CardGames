using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGames.Base;
using CardGames.Core;
using UnityEngine.UI;
using System;

namespace CardGames.Screens
{
    public class Title : ScreenBase<Title>
    {
        [SerializeField] Transform content;
        [SerializeField] GameObject template;

        public static void Show()
        {
            Show(Constants.SCREENS_TITLE);
        }

        protected override void Setup()
        {
            Populate();
        }

        protected override void Awake()
        {
            base.Awake();
            AppManager.OnGameLoad += Close;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            AppManager.OnGameLoad -= Close;
        }

        private void Populate()
        {
            var games = AppManager.Games;
            for (int i = 0; i < games.Length; i++)
            {
                int indx = i;
                GameObject b = Instantiate(template, content);
                b.GetComponent<UIButton>().Setup(games[indx].Name, () =>
                {
                    AppManager.LoadGame(games[indx].GameType);
                });
                b.SetActive(true);
            }
        }

        protected override void Close()
        {
            base.Close();            
        }
    }
}