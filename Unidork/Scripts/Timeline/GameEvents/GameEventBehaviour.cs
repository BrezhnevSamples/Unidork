using Unidork.Events;
using UnityEngine;
using UnityEngine.Playables;

namespace Unidork.Timeline
{
    /// <summary>
    /// Playable behaviour used to raise a <see cref="GameEvent"/>.
    /// </summary>
    [System.Serializable]
    public class GameEventBehaviour : PlayableBehaviour
    {
        public GameEvent GameEvent => gameEvent;
        [SerializeField] private GameEvent gameEvent;
    }
}