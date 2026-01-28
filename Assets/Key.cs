/// <summary>
/// Class <c>Key</c> to manage different keys
/// </summary>
public class Key
{
    string nameMajor; //major version of this key
    string nameMinor; //minor version of this key
    string type; //major & minor
    string signs; // key in signs
    public int sharp; // how many #'s
    public int b; // how many b's
    string name;// name of this specific key

    //Dur-Tonarten: 	Ces 	Ges 	Des 	As 	Es 	B 	F 	C 	G 	D 	A 	E 	H 	Fis 	Cis
    //Moll-Tonarten: 	as  es  b   f   c   g   d   a   e   h   fis     cis     gis     dis     ais

    static Key[] All = // array with all keys as a lookup table
    {
        new Key("Ces","as","bbbbbbb",0,7),
        new Key("Ges","es","bbbbbb",0,6),
        new Key("Des","b","bbbbb",0,5),
        new Key("As","f","bbbb",0,4),
        new Key("Es","c","bbb",0,3),
        new Key("B","g","bb",0,2),
        new Key("F","d","b",0,1),
        new Key("C","a","",0,0),
        new Key("G","e", "#",1,0),
        new Key("D","h","##",2,0),
        new Key("A","fis", "###",3,0),
        new Key("E","cis", "####",4,0),
        new Key("H","gis", "#####",5,0),
        new Key("Fis","dis", "######",6,0),
        new Key("Cis","ais", "#######",7,0),
    };

    /// <summary>
    /// Constructor <c>Key</c> to create new key from scratch
    /// </summary>
    Key(string nameMajor, string nameMinor, string signs, int sharp, int b, string type = "") //create new key from scratch
    {
        this.nameMajor = nameMajor;
        this.nameMinor = nameMinor;
        this.signs = signs;
        this.sharp = sharp;
        this.b = b;
        this.type = type;
        if (type != "")
        {
            this.SetType(this.type);
        }
    }

    /// <summary>
    /// Constructor <c>Key</c> to create key from outside based on an identifier with a lookup table, identifier supports names and signs, e.g. "bb" == "g"
    /// </summary>
    public Key(string identifier, string type = "")
    {
        for (int k = 0; k < All.Length; k++)
        {
            if (All[k].signs == identifier)
            {
                this.nameMajor = All[k].nameMajor;
                this.nameMinor = All[k].nameMinor;
                this.signs = All[k].signs;
                this.sharp = All[k].sharp;
                this.b = All[k].b;
                this.SetType(type);
            }
            if (All[k].nameMajor == identifier)
            {
                this.nameMajor = All[k].nameMajor;
                this.nameMinor = All[k].nameMinor;
                this.signs = All[k].signs;
                this.sharp = All[k].sharp;
                this.b = All[k].b;
                this.name = nameMajor;
                this.type = "major";
            }
            if (All[k].nameMinor == identifier)
            {
                this.nameMajor = All[k].nameMajor;
                this.nameMinor = All[k].nameMinor;
                this.signs = All[k].signs;
                this.sharp = All[k].sharp;
                this.b = All[k].b;
                this.name = nameMinor;
                this.type = "minor";
            }
        }
    }

    /// <summary>
    /// Method <c>SetType</c> to set type of key to minor or major
    /// </summary>
    public void SetType(string type = "")
    {
        if (type != "")
        {
            this.type = type;
        }
        switch (this.type)
        {
            case "minor":
                this.name = nameMinor;
                break;
            case "major":
                this.name = nameMajor;
                break;
            default:
                UnityEngine.Debug.LogError("Wrong type: " + type + " . Should be major or minor");
                break;
        }
    }
}