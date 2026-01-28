/// <summary>
/// Class <c>GameSettings</c> for the game (static)
/// </summary>
public static class GameSettings
{
    public static string gameMode; //"notes","chords"
    public static string trainingMode = "testing"; //"addaptive", "random", "testing"
    
    public static string language = "de"; //"addaptive", "

    public static string input = "buttons"; //"keyboard","buttons","midi"
    public static bool keyboardLabel = false; // 

    public static string sound = "input";  //"off","note","input" ,"note&input"
    public static string[] clefs = { "violin" }; //"violin", "bass", "all"

    public static int maxNoteViolin = 0;
    public static int minNoteViolin = 55;    
    public static int maxNoteBass = 0;
    public static int minNoteBass = 55;

    public static string sign; //"none", "b","#" ,"#&b"
    public static string soundPack = "petrof"; // rhodes, steinway, petrof

    public static int nNotes = 1;

    public static int trainingTime = 60;
}


