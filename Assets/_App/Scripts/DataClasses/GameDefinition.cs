using System;
using UnityEngine;

namespace CardGames.Data
{
    [Serializable]
    public class GameDefinition
    {
        [SerializeField] private string name;
        [SerializeField] private GameTypes gameType;
        [SerializeField] private string scene;

        public string Name { get { return name; } }
        public GameTypes GameType { get { return gameType; } }
        public string Scene { get { return scene; } }
    }
}