using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Unidork.Timeline
{
    /// <summary>
    /// Playable behaviour used to pause and resume a timeline it belongs to.
    /// </summary>
    [System.Serializable]
    public class TimelinePauseBehaviour : PlayableBehaviour
    {
        public SignalAsset UnpauseSignal => unpauseSignal;
        [SerializeField] private SignalAsset unpauseSignal;
    }
}