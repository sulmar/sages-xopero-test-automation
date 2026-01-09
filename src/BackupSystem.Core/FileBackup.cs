namespace BackupSystem.Core;

public class FileBackup
{
    public string FileName { get; set; } // Property (wlasciwosc)
    public long FileSizeInBytes { get; set; }
    public bool IsBackedUp { get; private set; } // Property (wlasciwosc)
    public DateTime CreatedOn { get; set; } // Property (wlasciwosc)

    private IFileSystem fileSystem;

    // Konstruktor (constructor) 
    // metoda uruchamiana podczas tworzenia obiektu
    // i sluzy do przekazania wymaganych parametrow np. filename
    // oraz do ustawiania parametrów domyslnych np. IsBackedUp
    public FileBackup(string filename, IFileSystem fileSystem, long fileSizeInBytes = 0)
    {
        FileName = filename;
        IsBackedUp = false;
        CreatedOn = DateTime.Now;
        FileSizeInBytes = fileSizeInBytes;
        this.fileSystem = fileSystem;
    }

    // Metoda (method)
    public void Backup()
    {        
        Validate();

        // Logika
        Thread.Sleep(10_000); // Symulacja dlugotrwajacej operacji (Sleep - uspienie watku na okreslony czas)

        IsBackedUp = true;
    }

    public async Task BackupAsync()
    {
        Validate();

        await Task.Delay(10_000); // // Symulacja dlugotrwajacej operacji (Sleep - uspienie zadamia na okreslony czas)

        IsBackedUp = true;
    }

    // Metod prywatnych nie testujemy! 
    private void Validate()
    {
        if (string.IsNullOrEmpty(FileName))
            throw new FormatException("File name is invalid");

        if (FileSizeInBytes < 0)
            throw new InvalidOperationException("File size is invalid");

        // if (!File.Exists(FileName)) // sztywna zaleznosc
         if (!fileSystem.Exists(FileName))   
            throw new FileNotFoundException("File not found", FileName);
    }

    
    public void Restore()
    {
        if (!IsBackedUp)
            throw new InvalidOperationException();

        IsBackedUp = false;
    }

}
