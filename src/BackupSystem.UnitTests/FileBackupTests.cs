using BackupSystem.Core;

namespace BackupSystem.UnitTests;

// TODO: wyjasnic IClassFixture

public class FileBackupTests
{
    private const string validFilename = "a.pdf";
    private const string emptyFilename = "";
    private const long fileSizeIsNegative = -1;


    private IFileSystem fileSystem;

    // Szablon nazewniczy 
    // MethodName_Scenario_ExpectedBehavior

    // ctor - konstruktor w xUnit jest uruchamiany dla kazdego przypadku testowego osobno
    // Nie potrzebujemy TearUp jak na np. nUnit
    public FileBackupTests()
    {
        fileSystem = new FakeFileSystem(fileExists: true);
    }

    // Happy Path
    [Fact] // Atrybut oznaczajacy test w bibliotece xUnit
    public void Backup_WhenFilenameIsValid_MarksFileAsBackedUp()
    {
        // Arrange
        FileBackup fileBackup = new FileBackup(validFilename, fileSystem);

        // Act - to co testujemy
        fileBackup.Backup();

        // Assert - weryfikujemy zachowanie
        Assert.True(fileBackup.IsBackedUp);
    }

    [Fact]
    public void FileBackup_WhenCreated_SetCreateOnAndBackedUpIsFalse()
    {
        // Arrange
        FileBackup fileBackup = new FileBackup(validFilename, fileSystem);

        // Act

        // Assert
        Assert.NotEqual(DateTime.MinValue, fileBackup.CreatedOn);
        Assert.False(fileBackup.IsBackedUp);
    }

    // Unhappy Path

    [Fact]
    public void Backup_WhenFilenameIsEmpty_ThrowsFormatException()
    {
        // Arrange
        FileBackup fileBackup = new FileBackup(emptyFilename, fileSystem);

        // Act
        Action act = () => fileBackup.Backup(); // zapis strzałkowy = wyrażenie lambda 

        // Assert
        Assert.Throws<FormatException>(act);

        // Act & Assert
        Assert.Throws<FormatException>(() => fileBackup.Backup());

        /* w srodku co do zasady dzialania jest kod podobny do ponizszego
         
        try
        {
            act.Invoke(); // fileBackup.Backup()

            Assert.Fail();
        }
        catch (FormatException)
        {
            
        }
        */

    }

    [Fact]
    public void Backup_WhenFileSizeIsNegative_ThrowsInvalidOperationException()
    {
        // Arrange
        FileBackup fileBackup = new FileBackup(validFilename, fileSystem, fileSizeIsNegative);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => fileBackup.Backup());
    }

    // Happy Path
    [Fact]
    public void Restore_WhenBackuped_MarksFileAsNotBackedUp()
    {
        // Arrange
        FileBackup fileBackup = new FileBackup(validFilename, fileSystem);
        fileBackup.Backup();

        // Act
        fileBackup.Restore();

        // Assert
        Assert.False(fileBackup.IsBackedUp);
    }

    // Unhappy Path
    [Fact]
    public void Restore_WhenNotBackuped_ThrowsInvalidOperationException()
    {
        // Arrange
        FileBackup fileBackup = new FileBackup(validFilename, fileSystem);

        // Act
        Action act = () => fileBackup.Restore();

        // Assert
        Assert.Throws<InvalidOperationException>(act);

    }

  
}
