using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGames.Core;
using CardGames.Base;
using UnityEngine.UI;

namespace CardGames.Screens
{
    public class LoadingScreen : ScreenBase<LoadingScreen>
    {
        public delegate float GetLoadingProgressDelegate();

        [SerializeField] Image loadingFill;

        public static void Show(GetLoadingProgressDelegate d)
        {
            Show(Constants.SCREENS_LOADING_SCREEN, () =>
            {
                instance.StartCoroutine(instance.Load(d));
            });

        }

        public static void Hide()
        {
            if (instance != null) instance.Close();
        }

        protected override void Setup()
        {

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