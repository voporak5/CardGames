using CardGames.Data;
using CardGames.Screens;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardGames
{
    public class AppManager : MonoBehaviour
    {
        private static AppManager instance;
      
        [SerializeField] private GameDefinition[] games;

        private void Awake()
        {
            instance = GetComponent<AppManager>();
        }

        // Start is called before the first frame update
        void Start()
        {
            Title.Show();
        }        

        public static void LoadGame(GameTypes g)
        {
            instance.DoLoadGame(g);
        }

        private GameDefinition GetGame(GameTypes g)
        {
            GameDefinition def = null;

            for(int i = 0; i < games.Length;i++)
            {
                if(games[i].GameType == g)
                {
                    def = games[i];
                    break;
                }
            }

            return def;
        }

        IEnumerator DoLoadGame(GameTypes g)
        {
            float progress = 0f;

            LoadingScreen.Show(() =>
            {
                return progress;
            });

            yield return null;

            string scene = GetGame(g).Scene;

            //Begin to load the Scene you specify
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);
            //Don't let the Scene activate until you allow it to
            asyncOperation.allowSceneActivation = false;

            //When the load is still in progress, output the Text and progress bar
            while (!asyncOperation.isDone)
            {
                progress = asyncOperation.progress;
                //Output the current progress
                //m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

                // Check if the load has finished
                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }

                yield return null;
            }

            progress = 1f;

            yield return new WaitForSeconds(1f);

            LoadingScreen.Hide();
        }
    }
}