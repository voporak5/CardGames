using UnityEngine;

namespace CardGames.Data
{
    [CreateAssetMenu(fileName = "Games", menuName = "ScriptableObjects/Games", order = 2)]
    public class Games : ScriptableObject
    {
        public GameDefinition[] definitions;
    }
}