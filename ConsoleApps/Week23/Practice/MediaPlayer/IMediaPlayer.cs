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

    /// <summary>
    /// Adds a media item to the playlist if there is available space.
    /// </summary>
    /// <param name="media">The name of the media item to be added to the playlist.</param>
    public void AddToPlaylist(string media)
    {
        // Check if there is room in the playlist array
        if (count < playlist.Length)
        {
            // Add the media to the next available slot and increment the count
            playlist[count++] = media;

            // Notify the user that the media item has been successfully added
            Console.WriteLine($"Added {media} to audio playlist.");
        }
        else
        {
            // Notify the user if the playlist is already at full capacity
            Console.WriteLine("Playlist is full.");
        }
    }


    /// <summary>
    /// Removes a specified media item from the playlist.
    /// </summary>
    /// <param name="media">The name of the media item to remove.</param>
    public void RemoveFromPlaylist(string media)
    {
        // Find the index of the media item in the playlist array
        int index = Array.IndexOf(playlist, media, 0, count);

        // If the media item is found in the playlist
        if (index >= 0)
        {
            // Shift all elements to the left to overwrite the removed item
            for (int i = index; i < count - 1; i++)
            {
                playlist[i] = playlist[i + 1];
            }

            // Decrement count and set the last item to null to avoid duplicate references
            playlist[--count] = null;

            // Notify the user that the item has been removed
            Console.WriteLine($"Removed {media} from audio playlist.");
        }
        else
        {
            // Notify the user if the media item was not found in the playlist
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

