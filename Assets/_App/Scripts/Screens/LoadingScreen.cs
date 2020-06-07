using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGames.Core;
using CardGames.Base;
using UnityEngine.UI;

namespace CardGames.Screens
{
    public class LoadingScreen : ScreenBase
    {
        public delegate float GetLoadingProgressDelegate();

        private static LoadingScreen instance;

        [SerializeField] Image loadingFill;

        public static void Show(GetLoadingProgressDelegate d)
        {
            UIScreenManager.GetScreen(Constants.SCREENS_LOADING_SCREEN, g =>
            {
                instance.Setup(d);
            });
        }

        public static void Hide()
        {
            if (instance != null) instance.Close();
        }

        private void Setup(GetLoadingProgressDelegate d)
        {
            id = Constants.SCREENS_LOADING_SCREEN;
            StartCoroutine(Load(d));
        }

        IEnumerator Load(GetLoadingProgressDelegate d)
        {
            float progress = 0f;

            while(progress < 1f)
            {
                progress = d();
                loadingFill.fillAmount = progress;
                yield return null;
            }
        }
    }
}