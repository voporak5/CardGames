using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CardGames.Core;
using CardGames.Base;

namespace CardGames.Screens
{
    public class Game : ScreenBase<Game>
    {
        [SerializeField] private TextMeshProUGUI labelTitle;

        [SerializeField] private Button buttonPlay;
        [SerializeField] private Button buttonSetup;
        [SerializeField] private Button buttonRules;
        [SerializeField] private Button buttonCredit;
        [SerializeField] private Button buttonExit;


        public static void Show()
        {
            Show(Constants.SCREENS_GAME);
        }

        protected override void Setup()
        {
            
        }

        void OnPlayClicked()
        {

        }

        void OnSetupClicked()
        { 

        }

        void OnRulesClicked()
        {

        }

        void OnCreditsClicked()
        {

        }

        void OnExitClicked()
        {

        }

    }
}