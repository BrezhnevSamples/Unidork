using UniRx;

namespace Unidork.Utility
{
	/// <summary>
	/// Interface that can be implemented in components so that they can be handled by the <see cref="PauseManager"/>
	/// </summary>
	public interface IPausable
	{
		/// <summary>
		/// Is the component currently paused?
		/// </summary>
		ReactiveProperty<bool> isPaused { get; }

		/// <summary>
		/// Pauses the component.
		/// </summary>
		void Pause() => isPaused.Value = true;

		/// <summary>
		/// Unpauses the component.
		/// </summary>
		void Unpause() => isPaused.Value = false;
	}    
}