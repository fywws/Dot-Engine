using SFML.Audio;

namespace DotEngine.FywwEngine.Audio;

public class AudioPlayer : IDisposable
{
    
    ///
    /// <summary>
    /// 
    /// Sound itself.
    /// 
    /// The sound will be played
    /// 
    /// </summary>
    ///
    private Sound _sound;
    
        
    ///
    /// <summary>
    /// Loop of the sound.
    /// 
    /// The default value for the loop is false.
    /// </summary>
    ///
    private bool loop = false;
    
    
    ///
    /// <summary>
    /// Volume of the sound.
    /// 
    /// The default value for the volume is 100.
    /// </summary>
    ///
    private float volume = 100;
    
    
    public AudioPlayer(AudioFile file)
    {
        _sound = new Sound(file.buffer);
    }
    
    public AudioPlayer(AudioFile file, bool loop)
    {
        _sound = new Sound(file.buffer);
        this.loop = loop;
    }
    
    public AudioPlayer(AudioFile file, bool loop, float volume)
    {
        _sound = new Sound(file.buffer);
        this.loop = loop;
        this.volume = volume;
    }

    public void Play()
    {
        _sound.Play();
        _sound.Volume = volume;
        _sound.Loop = loop;
    }

    public void Pause()
    {
        _sound.Pause();
    }

    public void Stop()
    {
        _sound.Stop();
    }
    
    public void Dispose()
    {
        _sound.Dispose();
    }

    public bool Loop
    {
        get => loop;
        set => loop = value;
    }

    
    public float Volume
    {
        get => volume;
        set => volume = value;
    }

}