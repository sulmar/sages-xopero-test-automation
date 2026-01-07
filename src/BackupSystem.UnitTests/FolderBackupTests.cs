using BackupSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem.UnitTests;

public class FolderBackupTests
{
    // Method_Scenario_ExpectedBehavior

    // Happy Path
    // 2. Czy wszystkie pliki sie backupuja?
    [Fact]
    public void Backup_AllValidFiles_BackUpsAllFiles()
    {
        // Arrange
        List<FileBackup> files = new List<FileBackup>
        {
            new FileBackup("file1.txt"),
            new FileBackup("file2.txt"),
            new FileBackup("file3.txt"),
        };

        FolderBackup folderBackup = new FolderBackup("a", files);

        // Act
        folderBackup.Backup();

        // Assert
        Assert.All(files, file => Assert.True(file.IsBackedUp));
        // Sprawdz czy wszystkie elementy zbioru files spelniaja warunek, ze IsBackedUp jest ustawiony na true
    }

    [Fact]
    public void Backup_HasInvalidFile_BackUpsOnlyValidFiles()
    {
        // Arrange
        List<FileBackup> files = new List<FileBackup>
        {
            new FileBackup("file1.txt"),
            new FileBackup(string.Empty),
            new FileBackup("file3.txt"),
        };

        List<FileBackup> validFiles = files.Where(file => file.FileName != "").ToList(); // podzbiór
        List<FileBackup> invalidFiles = files.Where(file => file.FileName == "").ToList(); // podzbiór

        FolderBackup folderBackup = new FolderBackup("a", files);

        // Act
        folderBackup.Backup();

        // Assert
        Assert.All(validFiles, file => Assert.True(file.IsBackedUp));
        Assert.All(invalidFiles, file => Assert.False(file.IsBackedUp));        
    }

    // Unhappy Path
    // 1. Czy pliki nie istnieja w folderze? jesli tak to niech rzuci wyjatkiem Exception
    [Fact]
    public void Backup_HasNotAnyFile_ThrowException()
    {
        // Arrange
        List<FileBackup> files = new List<FileBackup>();
        FolderBackup folderBackup = new FolderBackup("a", files);

        // Act
        Action act = () => folderBackup.Backup();

        // Assert
        Assert.Throws<Exception>(act);
    }


    // Unhappy Path
    // 3. Czy sa pliki ktore sie nie zbackupowaly?

    // Unhappy
    // 4. Czy FolderPath jest pusty? FormatException 

    // Unhappy
    // 5. Czy FolderPath jest zgodny z formatem? FormatException 


}
