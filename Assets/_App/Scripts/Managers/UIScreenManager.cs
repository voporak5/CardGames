using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CardGames
{
    public class UIScreenManager : MonoBehaviour
    {
        private static UIScreenManager instance;
        [SerializeField] private UIScreens uiScreens;
        [SerializeField] private Camera uiCam;

        public static void GetScreen(string name, System.Action<GameObject> onComplete)
        {
            AssetReferenceGameObject a = null;
            UIScreenReference[] s = instance.uiScreens.screens;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].name == name)
                {
                    a = s[i].asset;
                    break;
                }
            }

            a.InstantiateAsync(instance.transform).Completed += (asyncOperationHandle) =>
            {
                GameObject screen = asyncOperationHandle.Result;
                Canvas canvas = screen.GetComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = instance.uiCam;

                onComplete?.Invoke(asyncOperationHandle.Result);
            };
        }

        public static void ReleaseScreen(string name)
        {
            AssetReferenceGameObject a = null;
            UIScreenReference[] s = instance.uiScreens.screens;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].name == name)
                {
                    a = s[i].asset;
                    break;
                }
            }

            a.ReleaseAsset();
        }

        private void Awake()
        {
            instance = GetComponent<UIScreenManager>();
        }
    }
}