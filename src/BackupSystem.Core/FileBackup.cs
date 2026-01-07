namespace BackupSystem.Core;


public class ItemBackup
{

}

public class FileBackup
{
    public string FileName { get; set; } // Property (wlasciwosc)
    public long FileSizeInBytes { get; set; }
    public bool IsBackedUp { get; private set; } // Property (wlasciwosc)
    public DateTime CreatedOn { get; set; } // Property (wlasciwosc)

    // Konstruktor (constructor) 
    // metoda uruchamiana podczas tworzenia obiektu
    // i sluzy do przekazania wymaganych parametrow np. filename
    // oraz do ustawiania parametrów domyslnych np. IsBackedUp
    public FileBackup(string filename, long fileSizeInBytes = 0)
    {
        FileName = filename;
        IsBackedUp = false;
        CreatedOn = DateTime.Now;
        FileSizeInBytes = fileSizeInBytes;
    }

    // Metoda (method)
    public void Backup()
    {        
        // Walidacja
        if (string.IsNullOrEmpty(FileName))
            throw new FormatException("File name is invalid");

        if (FileSizeInBytes < 0)
            throw new InvalidOperationException("File size is invalid");

        // Logika
        IsBackedUp = true;
    }

    
    public void Restore()
    {
        if (!IsBackedUp)
            throw new InvalidOperationException();

        IsBackedUp = false;
    }

}
