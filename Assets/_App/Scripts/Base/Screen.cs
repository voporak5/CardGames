using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace CardGames.Base
{
    public interface IScreenInterface
    {
        
    }

    public abstract class ScreenBase<T> : MonoBehaviour, IScreenInterface where T : Component
    {
        protected string id;

        //protected abstract void Setup();
        protected static T instance;

        protected virtual void Awake()
        {
            instance = GetComponent<T>();
            //DontDestroyOnLoad(this);
        }

        protected static void Show(string screen, System.Action onShow = null)
        {
            UIScreenManager.GetScreen(screen, g =>
            {
                ScreenBase<T> s = g.GetComponent<ScreenBase<T>>();
                s.id = screen;
                s.Setup();
                onShow?.Invoke();
            });
        }

        protected abstract void Setup();

        protected virtual void Close()
        {
            Addressables.ReleaseInstance(gameObject);
        }

        protected virtual void OnDestroy()
        {
            instance = null;
        }

    }
}