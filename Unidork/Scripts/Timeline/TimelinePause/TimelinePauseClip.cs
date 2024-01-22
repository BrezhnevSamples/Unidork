using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Unidork.Timeline
{
    /// <summary>
    /// Timeline clip that is used to pause and resume a timeline that contains it.
    /// </summary>
    [System.Serializable]
    public class TimelinePauseClip : PlayableAsset
    {
        [NotKeyable]
        public TimelinePauseBehaviour Template = new();
        public override double duration => 1f;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<TimelinePauseBehaviour>.Create(graph, Template);
        }
    }
}