using Unidork.Events;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Unidork.Timeline
{
    /// <summary>
    /// Timeline clip used to raise a <see cref="GameEvent"/>.
    /// </summary>
    public class GameEventClip : PlayableAsset
    {
        [NotKeyable]
        public GameEventBehaviour Template = new();
        public override double duration => 0.5f;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<GameEventBehaviour>.Create(graph, Template);
        }
    }
}