using UnityEngine;
using MestreTramador.Util;

/// <summary>
/// Control both <see cref="AudioSource"/> and <see cref="AudioClip"/> of a <see cref="GameObject"/>.
/// </summary>
public sealed class AudioControl : MonoBehaviour
{
    /// <summary>
    /// The <see cref="GameObject"/> Source component.
    /// </summary>
    private AudioSource Source { get; set; }

    /// <summary>
    /// The same <see cref="Source"/> component's <see cref="AudioClip"/>.
    /// </summary>
    private AudioClip Clip { get; set; }

    /// <summary>
    /// On Start, initialize the the <see cref="AudioSource"/> component and,
    /// if present, the <see cref="AudioClip"/>.
    /// </summary>
    void Start()
    {
        Source = gameObject.GetComponent<AudioSource>();

        if(!(Source.clip is null))
        {
            Clip = Source.clip;
        }
    }

    /// <summary>
    /// Verify if there is a <see cref="AudioClip"/> on the <see cref="GameObject"/>.
    /// </summary>
    /// <returns><c>TRUE</c> if the <see cref="Clip"/> is present.</returns>
    public bool HaveClip() => !(Clip is null);

    /// <summary>
    /// If the <see cref="Source"/> is not playing, then play its <see cref="Clip"/>.
    /// </summary>
    public void PlayClip()
    {
        if(!Source.isPlaying)
        {
            Source.Play();
        }        
    }

    /// <summary>
    /// If the <see cref="Source"/> is playing, then stop its <see cref="Clip"/>.
    /// </summary>
    public void StopClip()
    {
        if(Source.isPlaying)
        {
            Source.Stop();
        }
    }

    /// <summary>
    /// Set the <see cref="AudioClip"/> of the component, if none is present.
    /// </summary>
    /// <param name="clip">The Clip to fill the <see cref="Clip"/>.</param>
    public void SetClip(AudioClip clip)
    {
        if(!HaveClip())
        {
            Clip = clip;
            Source.clip = clip;

            return;
        }        
    }

    /// <summary>
    /// Set the <see cref="AudioClip"/> of the component, if none is present.
    /// </summary>
    /// <param name="pathToClip">The path to the Clip.</param>
    public void SetClip(string pathToClip)
    {
        if(!HaveClip())
        {
            AudioClip newClip = Helper.LoadResource<AudioClip>(pathToClip);

            if(!(newClip is null))
            {
                SetClip(newClip);               
            }
        }
    }
}
