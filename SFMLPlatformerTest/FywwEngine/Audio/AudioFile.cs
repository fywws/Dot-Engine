﻿using SFML.Audio;
using Buffer = SFML.System.Buffer;

namespace DotEngine.FywwEngine.Audio;

public class AudioFile : IDisposable
{
    
    public SoundBuffer buffer;
    
    public AudioFile(string filePath)
    {
        buffer = new SoundBuffer(filePath);
    }


    public void Dispose()
    {
        buffer.Dispose();
    }
}