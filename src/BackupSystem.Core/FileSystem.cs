namespace BackupSystem.Core;

// Produkcja
public class FileSystem : IFileSystem // implentuje interfejs IFileSystem
{
    public bool Exists(string path)
    {
        return File.Exists(path);
    }
}
