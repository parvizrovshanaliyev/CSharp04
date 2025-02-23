namespace Practice.MediaPlayer;

/// <summary>
/// Interface for media playback.
/// This interface defines basic playback operations that all media players must implement.
/// It ensures consistency in how different types of media players handle play, pause, and stop functionalities.
/// </summary>
public interface IMediaPlayer
{
    void Play();
    void Pause();
    void Stop();
}

/// <summary>
/// Interface for managing playlists.
/// This interface allows adding, removing, and displaying media items in a playlist.
/// </summary>
public interface IPlaylist
{
    void AddToPlaylist(string media);
    void RemoveFromPlaylist(string media);
    void ShowPlaylist();
}

/// <summary>
/// Represents an audio player that can play, pause, and stop audio files.
/// Implements <see cref="IMediaPlayer"/> for playback controls and <see cref="IPlaylist"/> for managing an audio playlist.
/// </summary>
public class AudioPlayer : IMediaPlayer, IPlaylist
{
    private string[] playlist = new string[10];
    private int count = 0;
    private bool isPlaying = false;

    public void Play()
    {
        if (count == 0)
        {
            Console.WriteLine("Playlist is empty.");
            return;
        }
        isPlaying = true;
        Console.WriteLine("Playing audio...");
    }

    public void Pause()
    {
        if (isPlaying)
        {
            isPlaying = false;
            Console.WriteLine("Audio paused.");
        }
    }

    public void Stop()
    {
        isPlaying = false;
        Console.WriteLine("Audio stopped.");
    }

    public void AddToPlaylist(string media)
    {
        if (count < playlist.Length)
        {
            playlist[count++] = media;
            Console.WriteLine($"Added {media} to audio playlist.");
        }
        else
        {
            Console.WriteLine("Playlist is full.");
        }
    }

    public void RemoveFromPlaylist(string media)
    {
        int index = Array.IndexOf(playlist, media, 0, count);
        if (index >= 0)
        {
            for (int i = index; i < count - 1; i++)
            {
                playlist[i] = playlist[i + 1];
            }
            playlist[--count] = null;
            Console.WriteLine($"Removed {media} from audio playlist.");
        }
        else
        {
            Console.WriteLine($"{media} not found in audio playlist.");
        }
    }

    public void ShowPlaylist()
    {
        Console.WriteLine("Audio Playlist:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($" - {playlist[i]}");
        }
    }
}

/// <summary>
/// Represents a video player that can play, pause, and stop video files.
/// Implements <see cref="IMediaPlayer"/> for playback functionality.
/// </summary>
public class VideoPlayer : IMediaPlayer
{
    private bool isPlaying = false;

    public void Play()
    {
        isPlaying = true;
        Console.WriteLine("Playing video...");
    }

    public void Pause()
    {
        if (isPlaying)
        {
            isPlaying = false;
            Console.WriteLine("Video paused.");
        }
    }

    public void Stop()
    {
        isPlaying = false;
        Console.WriteLine("Video stopped.");
    }
}

/// <summary>
/// Represents a streaming media player that can play, pause, and stop online streams.
/// Implements <see cref="IMediaPlayer"/> for playback functionality.
/// </summary>
public class StreamingPlayer : IMediaPlayer
{
    private bool isStreaming = false;

    public void Play()
    {
        isStreaming = true;
        Console.WriteLine("Streaming media...");
    }

    public void Pause()
    {
        if (isStreaming)
        {
            isStreaming = false;
            Console.WriteLine("Streaming paused.");
        }
    }

    public void Stop()
    {
        isStreaming = false;
        Console.WriteLine("Streaming stopped.");
    }
}

