using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace CardGames.Base
{
    interface IScreenInterface
    {
        //abstract void Show();
        
    }

    public abstract class ScreenBase : MonoBehaviour, IScreenInterface
    {
        protected string id;

        //protected abstract void Setup();

        protected virtual void Close()
        {
            Addressables.ReleaseInstance(gameObject);
        }
    }
}