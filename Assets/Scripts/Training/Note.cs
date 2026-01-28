using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.AI;
using Unity.VisualScripting;



/// Class <c>Note</c>
public class Note
{
    public string name;
    public string nameLang;
    public string sign;
    public string clef;
    public int midiIdx;
    public float frequency;
    public string[] possibleClefs;
    public int baseIdx;


    public static Note[] allNotesSharp =
    {
        new Note(0, "C-1", 8.18f, "", new string[]{}),
        new Note(1, "C#-1", 8.66f, "#", new string[]{}),
        new Note(2, "D-1", 9.18f, "", new string[]{}),
        new Note(3, "D#-1", 9.72f, "#", new string[]{}),
        new Note(4, "E-1", 10.30f, "", new string[]{}),
        new Note(5, "F-1", 10.91f, "", new string[]{}),
        new Note(6, "F#-1", 11.56f, "#", new string[]{}),
        new Note(7, "G-1", 12.25f, "", new string[]{}),
        new Note(8, "G#-1", 12.98f, "#", new string[]{}),
        new Note(9, "A-1", 13.75f, "", new string[]{}),
        new Note(10, "A#-1", 14.57f, "#", new string[]{}),
        new Note(11, "B-1", 15.43f, "", new string[]{}),
        new Note(12, "C0", 16.35f, "", new string[]{}),
        new Note(13, "C#0", 17.32f, "#", new string[]{}),
        new Note(14, "D0", 18.35f, "", new string[]{}),
        new Note(15, "D#0", 19.45f, "#", new string[]{}),
        new Note(16, "E0", 20.60f, "", new string[]{}),
        new Note(17, "F0", 21.83f, "", new string[]{}),
        new Note(18, "F#0", 23.12f, "#", new string[]{}),
        new Note(19, "G0", 24.50f, "", new string[]{}),
        new Note(20, "G#0", 25.96f, "#", new string[]{}),
        new Note(21, "A0", 27.50f, "", new string[]{"bass"}),
        new Note(22, "A#0", 29.14f, "#", new string[]{"bass"}),
        new Note(23, "B0", 30.87f, "", new string[]{"bass"}),
        new Note(24, "C1", 32.70f, "", new string[]{"bass"}),
        new Note(25, "C#1", 34.65f, "#", new string[]{"bass"}),
        new Note(26, "D1", 36.71f, "", new string[]{"bass"}),
        new Note(27, "D#1", 38.89f, "#", new string[]{"bass"}),
        new Note(28, "E1", 41.20f, "", new string[]{"bass"}),
        new Note(29, "F1", 43.65f, "", new string[]{"bass"}),
        new Note(30, "F#1", 46.25f, "#", new string[]{"bass"}),
        new Note(31, "G1", 49.00f, "", new string[]{"bass"}),
        new Note(32, "G#1", 51.91f, "#", new string[]{"bass"}),
        new Note(33, "A1", 55.00f, "", new string[]{"bass"}),
        new Note(34, "A#1", 58.27f, "#", new string[]{"bass"}),
        new Note(35, "B1", 61.74f, "", new string[]{"bass"}),
        new Note(36, "C2", 65.41f, "", new string[]{"bass"}),
        new Note(37, "C#2", 69.30f, "#", new string[]{"bass"}),
        new Note(38, "D2", 73.42f, "", new string[]{"bass"}),
        new Note(39, "D#2", 77.78f, "#", new string[]{"bass"}),
        new Note(40, "E2", 82.41f, "", new string[]{"bass"}),
        new Note(41, "F2", 87.31f, "", new string[]{"bass"}),
        new Note(42, "F#2", 92.50f, "#", new string[]{"bass"}),
        new Note(43, "G2", 98.00f, "", new string[]{"bass"}),
        new Note(44, "G#2", 103.83f, "#", new string[]{"bass"}),
        new Note(45, "A2", 110.00f, "", new string[]{"bass"}),
        new Note(46, "A#2", 116.54f, "#", new string[]{"bass"}),
        new Note(47, "B2", 123.47f, "", new string[]{"bass"}),
        new Note(48, "C3", 130.81f, "", new string[]{"bass","violin"}),
        new Note(49, "C#3", 138.59f, "#", new string[]{"bass","violin"}),
        new Note(50, "D3", 146.83f, "", new string[]{"bass","violin"}),
        new Note(51, "D#3", 155.56f, "#", new string[]{"bass","violin"}),
        new Note(52, "E3", 164.81f, "", new string[]{"bass","violin"}),
        new Note(53, "F3", 174.61f, "", new string[]{"bass","violin"}),
        new Note(54, "F#3", 185.00f, "#", new string[]{"bass","violin"}),
        new Note(55, "G3", 196.00f, "", new string[]{"bass","violin"}),
        new Note(56, "G#3", 207.65f, "#", new string[]{"bass","violin"}),
        new Note(57, "A3", 220.00f, "", new string[]{"bass","violin"}),
        new Note(58, "A#3", 233.08f, "#", new string[]{"bass","violin"}),
        new Note(59, "B3", 246.94f, "", new string[]{"bass","violin"}),
        new Note(60, "C4", 261.63f, "", new string[]{"bass","violin"}), // the middle C
        new Note(61, "C#4", 277.18f, "#", new string[]{"bass","violin"}),
        new Note(62, "D4", 293.66f, "", new string[]{"bass","violin"}),
        new Note(63, "D#4", 311.13f, "#", new string[]{"bass","violin"}),
        new Note(64, "E4", 329.63f, "", new string[]{"bass","violin"}),
        new Note(65, "F4", 349.23f, "", new string[]{"bass","violin"}),
        new Note(66, "F#4", 369.99f, "#", new string[]{"bass","violin"}),
        new Note(67, "G4", 392.00f, "", new string[]{"bass","violin"}),
        new Note(68, "G#4", 415.30f, "#", new string[]{"bass","violin"}),
        new Note(69, "A4", 440.00f, "", new string[]{"bass","violin"}),
        new Note(70, "A#4", 466.16f, "#", new string[]{"bass","violin"}),
        new Note(71, "B4", 493.88f, "", new string[]{"bass","violin"}),
        new Note(72, "C5", 523.25f, "", new string[]{"bass","violin"}),
        new Note(73, "C#5", 554.37f, "#", new string[]{"violin"}),
        new Note(74, "D5", 587.33f, "", new string[]{"violin"}),
        new Note(75, "D#5", 622.25f, "#", new string[]{"violin"}),
        new Note(76, "E5", 659.26f, "", new string[]{"violin"}),
        new Note(77, "F5", 698.46f, "", new string[]{"violin"}),
        new Note(78, "F#5", 739.99f, "#", new string[]{"violin"}),
        new Note(79, "G5", 783.99f, "", new string[]{"violin"}),
        new Note(80, "G#5", 830.61f, "#", new string[]{"violin"}),
        new Note(81, "A5", 880.00f, "", new string[]{"violin"}),
        new Note(82, "A#5", 932.33f, "#", new string[]{"violin"}),
        new Note(83, "B5", 987.77f, "", new string[]{"violin"}),
        new Note(84, "C6", 1046.50f, "", new string[]{"violin"}),
        new Note(85, "C#6", 1108.73f, "#", new string[]{"violin"}),
        new Note(86, "D6", 1174.66f, "", new string[]{"violin"}),
        new Note(87, "D#6", 1244.51f, "#", new string[]{"violin"}),
        new Note(88, "E6", 1318.51f, "", new string[]{"violin"}),
        new Note(89, "F6", 1396.91f, "", new string[]{"violin"}),
        new Note(90, "F#6", 1479.98f, "#", new string[]{"violin"}),
        new Note(91, "G6", 1567.98f, "", new string[]{"violin"}),
        new Note(92, "G#6", 1661.22f, "#", new string[]{"violin"}),
        new Note(93, "A6", 1760.00f, "", new string[]{"violin"}),
        new Note(94, "A#6", 1864.66f, "#", new string[]{"violin"}),
        new Note(95, "B6", 1975.53f, "", new string[]{"violin"}),
        new Note(96, "C7", 2093.00f, "", new string[]{"violin"}),
        new Note(97, "C#7", 2217.46f, "#", new string[]{"violin"}),
        new Note(98, "D7", 2349.32f, "", new string[]{"violin"}),
        new Note(99, "D#7", 2489.02f, "#", new string[]{"violin"}),
        new Note(100, "E7", 2637.02f, "", new string[]{"violin"}),
        new Note(101, "F7", 2793.83f, "", new string[]{"violin"}),
        new Note(102, "F#7", 2959.96f, "#", new string[]{"violin"}),
        new Note(103, "G7", 3135.96f, "", new string[]{"violin"}),
        new Note(104, "G#7", 3322.44f, "#", new string[]{"violin"}),
        new Note(105, "A7", 3520.00f, "", new string[]{"violin"}),
        new Note(106, "A#7", 3729.31f, "#", new string[]{"violin"}),
        new Note(107, "B7", 3951.07f, "", new string[]{"violin"}),
        new Note(108, "C8", 4186.01f, "", new string[]{"violin"}),
        new Note(109, "C#8", 4434.92f, "#", new string[]{}),
        new Note(110, "D8", 4698.63f, "", new string[]{}),
        new Note(111, "D#8", 4978.03f, "#", new string[]{}),
        new Note(112, "E8", 5274.04f, "", new string[]{}),
        new Note(113, "F8", 5587.65f, "", new string[]{}),
        new Note(114, "F#8", 5919.91f, "#", new string[]{}),
        new Note(115, "G8", 6271.93f, "", new string[]{}),
        new Note(116, "G#8", 6644.88f, "#", new string[]{}),
        new Note(117, "A8", 7040.00f, "", new string[]{}),
        new Note(118, "A#8", 7458.62f, "#", new string[]{}),
        new Note(119, "B8", 7902.13f, "", new string[]{}),
        new Note(120, "C9", 8372.02f, "", new string[]{}),
        new Note(121, "C#9", 8869.84f, "#", new string[]{}),
        new Note(122, "D9", 9397.27f, "", new string[]{}),
        new Note(123, "D#9", 9956.06f, "#", new string[]{}),
        new Note(124, "E9", 10548.08f, "", new string[]{}),
        new Note(125, "F9", 11175.30f, "", new string[]{}),
        new Note(126, "F#9", 11839.82f, "#", new string[]{}),
        new Note(127, "G9", 12543.85f, "", new string[]{})
    };


    public static Note[] allNotesB =
    {
        new Note(0, "C-1", 8.18f, "", new string[]{}),
        new Note(1, "Db-1", 8.66f, "b", new string[]{}),
        new Note(2, "D-1", 9.18f, "", new string[]{}),
        new Note(3, "Eb-1", 9.72f, "b", new string[]{}),
        new Note(4, "E-1", 10.30f, "", new string[]{}),
        new Note(5, "F-1", 10.91f, "", new string[]{}),
        new Note(6, "Gb-1", 11.56f, "b", new string[]{}),
        new Note(7, "G-1", 12.25f, "", new string[]{}),
        new Note(8, "Ab-1", 12.98f, "b", new string[]{}),
        new Note(9, "A-1", 13.75f, "", new string[]{}),
        new Note(10, "Bb-1", 14.57f, "b", new string[]{}),
        new Note(11, "B-1", 15.43f, "", new string[]{}),
        new Note(12, "C0", 16.35f, "", new string[]{}),
        new Note(13, "Db0", 17.32f, "b", new string[]{}),
        new Note(14, "D0", 18.35f, "", new string[]{}),
        new Note(15, "Eb0", 19.45f, "b", new string[]{}),
        new Note(16, "E0", 20.60f, "", new string[]{}),
        new Note(17, "F0", 21.83f, "", new string[]{}),
        new Note(18, "Gb0", 23.12f, "b", new string[]{}),
        new Note(19, "G0", 24.50f, "", new string[]{}),
        new Note(20, "Ab0", 25.96f, "b", new string[]{}),
        new Note(21, "A0", 27.50f, "", new string[]{"bass"}),
        new Note(22, "Bb0", 29.14f, "b", new string[]{"bass"}),
        new Note(23, "B0", 30.87f, "", new string[]{"bass"}),
        new Note(24, "C1", 32.70f, "", new string[]{"bass"}),
        new Note(25, "Db1", 34.65f, "b", new string[]{"bass"}),
        new Note(26, "D1", 36.71f, "", new string[]{"bass"}),
        new Note(27, "Eb1", 38.89f, "b", new string[]{"bass"}),
        new Note(28, "E1", 41.20f, "", new string[]{"bass"}),
        new Note(29, "F1", 43.65f, "", new string[]{"bass"}),
        new Note(30, "Gb1", 46.25f, "b", new string[]{"bass"}),
        new Note(31, "G1", 49.00f, "", new string[]{"bass"}),
        new Note(32, "Ab1", 51.91f, "b", new string[]{"bass"}),
        new Note(33, "A1", 55.00f, "", new string[]{"bass"}),
        new Note(34, "Bb1", 58.27f, "b", new string[]{"bass"}),
        new Note(35, "B1", 61.74f, "", new string[]{"bass"}),
        new Note(36, "C2", 65.41f, "", new string[]{"bass"}),
        new Note(37, "Db2", 69.30f, "b", new string[]{"bass"}),
        new Note(38, "D2", 73.42f, "", new string[]{"bass"}),
        new Note(39, "Eb2", 77.78f, "b", new string[]{"bass"}),
        new Note(40, "E2", 82.41f, "", new string[]{"bass"}),
        new Note(41, "F2", 87.31f, "", new string[]{"bass"}),
        new Note(42, "Gb2", 92.50f, "b", new string[]{"bass"}),
        new Note(43, "G2", 98.00f, "", new string[]{"bass"}),
        new Note(44, "Ab2", 103.83f, "b", new string[]{"bass"}),
        new Note(45, "A2", 110.00f, "", new string[]{"bass"}),
        new Note(46, "Bb2", 116.54f, "b", new string[]{"bass"}),
        new Note(47, "B2", 123.47f, "", new string[]{"bass"}),
        new Note(48, "C3", 130.81f, "", new string[]{"bass","violin"}),
        new Note(49, "Db3", 138.59f, "b", new string[]{"bass","violin"}),
        new Note(50, "D3", 146.83f, "", new string[]{"bass","violin"}),
        new Note(51, "Eb3", 155.56f, "b", new string[]{"bass","violin"}),
        new Note(52, "E3", 164.81f, "", new string[]{"bass","violin"}),
        new Note(53, "F3", 174.61f, "", new string[]{"bass","violin"}),
        new Note(54, "Gb3", 185.00f, "b", new string[]{"bass","violin"}),
        new Note(55, "G3", 196.00f, "", new string[]{"bass","violin"}),
        new Note(56, "Ab3", 207.65f, "b", new string[]{"bass","violin"}),
        new Note(57, "A3", 220.00f, "", new string[]{"bass","violin"}),
        new Note(58, "Bb3", 233.08f, "b", new string[]{"bass","violin"}),
        new Note(59, "B3", 246.94f, "", new string[]{"bass","violin"}),
        new Note(60, "C4", 261.63f, "", new string[]{"bass","violin"}), // the middle C
        new Note(61, "Db4", 277.18f, "b", new string[]{"bass","violin"}),
        new Note(62, "D4", 293.66f, "", new string[]{"bass","violin"}),
        new Note(63, "Eb4", 311.13f, "b", new string[]{"bass","violin"}),
        new Note(64, "E4", 329.63f, "", new string[]{"bass","violin"}),
        new Note(65, "F4", 349.23f, "", new string[]{"bass","violin"}),
        new Note(66, "Gb4", 369.99f, "b", new string[]{"bass","violin"}),
        new Note(67, "G4", 392.00f, "", new string[]{"bass","violin"}),
        new Note(68, "Ab4", 415.30f, "b", new string[]{"bass","violin"}),
        new Note(69, "A4", 440.00f, "", new string[]{"bass","violin"}),
        new Note(70, "Bb4", 466.16f, "b", new string[]{"bass","violin"}),
        new Note(71, "B4", 493.88f, "", new string[]{"bass","violin"}),
        new Note(72, "C5", 523.25f, "", new string[]{"bass","violin"}),
        new Note(73, "Db5", 554.37f, "b", new string[]{"violin"}),
        new Note(74, "D5", 587.33f, "", new string[]{"violin"}),
        new Note(75, "Eb5", 622.25f, "b", new string[]{"violin"}),
        new Note(76, "E5", 659.26f, "", new string[]{"violin"}),
        new Note(77, "F5", 698.46f, "", new string[]{"violin"}),
        new Note(78, "Gb5", 739.99f, "b", new string[]{"violin"}),
        new Note(79, "G5", 783.99f, "", new string[]{"violin"}),
        new Note(80, "Ab5", 830.61f, "b", new string[]{"violin"}),
        new Note(81, "A5", 880.00f, "", new string[]{"violin"}),
        new Note(82, "Bb5", 932.33f, "b", new string[]{"violin"}),
        new Note(83, "B5", 987.77f, "", new string[]{"violin"}),
        new Note(84, "C6", 1046.50f, "", new string[]{"violin"}),
        new Note(85, "Db6", 1108.73f, "b", new string[]{"violin"}),
        new Note(86, "D6", 1174.66f, "", new string[]{"violin"}),
        new Note(87, "Eb6", 1244.51f, "b", new string[]{"violin"}),
        new Note(88, "E6", 1318.51f, "", new string[]{"violin"}),
        new Note(89, "F6", 1396.91f, "", new string[]{"violin"}),
        new Note(90, "Gb6", 1479.98f, "b", new string[]{"violin"}),
        new Note(91, "G6", 1567.98f, "", new string[]{"violin"}),
        new Note(92, "Ab6", 1661.22f, "b", new string[]{"violin"}),
        new Note(93, "A6", 1760.00f, "", new string[]{"violin"}),
        new Note(94, "Bb6", 1864.66f, "b", new string[]{"violin"}),
        new Note(95, "B6", 1975.53f, "", new string[]{"violin"}),
        new Note(96, "C7", 2093.00f, "", new string[]{"violin"}),
        new Note(97, "Db7", 2217.46f, "b", new string[]{"violin"}),
        new Note(98, "D7", 2349.32f, "", new string[]{"violin"}),
        new Note(99, "Eb7", 2489.02f, "b", new string[]{"violin"}),
        new Note(100, "E7", 2637.02f, "", new string[]{"violin"}),
        new Note(101, "F7", 2793.83f, "", new string[]{"violin"}),
        new Note(102, "Gb7", 2959.96f, "b", new string[]{"violin"}),
        new Note(103, "G7", 3135.96f, "", new string[]{"violin"}),
        new Note(104, "Ab7", 3322.44f, "b", new string[]{"violin"}),
        new Note(105, "A7", 3520.00f, "", new string[]{"violin"}),
        new Note(106, "Bb7", 3729.31f, "b", new string[]{"violin"}),
        new Note(107, "B7", 3951.07f, "", new string[]{"violin"}),
        new Note(108, "C8", 4186.01f, "", new string[]{"violin"}),
        new Note(109, "Db8", 4434.92f, "b", new string[]{}),
        new Note(110, "D8", 4698.63f, "", new string[]{}),
        new Note(111, "Eb8", 4978.03f, "b", new string[]{}),
        new Note(112, "E8", 5274.04f, "", new string[]{}),
        new Note(113, "F8", 5587.65f, "", new string[]{}),
        new Note(114, "Gb8", 5919.91f, "b", new string[]{}),
        new Note(115, "G8", 6271.93f, "", new string[]{}),
        new Note(116, "Ab8", 6644.88f, "b", new string[]{}),
        new Note(117, "A8", 7040.00f, "", new string[]{}),
        new Note(118, "Bb8", 7458.62f, "b", new string[]{}),
        new Note(119, "B8", 7902.13f, "", new string[]{}),
        new Note(120, "C9", 8372.02f, "", new string[]{}),
        new Note(121, "Db9", 8869.84f, "b", new string[]{}),
        new Note(122, "D9", 9397.27f, "", new string[]{}),
        new Note(123, "Eb9", 9956.06f, "b", new string[]{}),
        new Note(124, "E9", 10548.08f, "", new string[]{}),
        new Note(125, "F9", 11175.30f, "", new string[]{}),
        new Note(126, "Gb9", 11839.82f, "b", new string[]{}),
        new Note(127, "G9", 12543.85f, "", new string[]{})
    };


    public static Note[] allNotesButton = {
        new Note("c1", ""),
        new Note("cis1", "#"),
        new Note("des1", "b"),
        new Note("d1", ""),
        new Note("dis1", "#"),
        new Note("es1","b"),
        new Note("e1",""),
        new Note("f1",""),
        new Note("fis1","#"),
        new Note("ges1","b"),
        new Note("g1",""),
        new Note("gis1","#"),
        new Note("as1","b"),
        new Note("a1",""),
        new Note("ais1","#"),
        new Note("b","b"),
        new Note("h1",""),
        new Note("c2", ""),
        new Note("cis2", "#"),
        new Note("des2", "b"),
        new Note("d2", ""),
        new Note("dis2", "#"),
        new Note("es2","b"),
        new Note("e2",""),
        new Note("f2",""),
        new Note("fis2","#"),
        new Note("ges2","b"),
        new Note("g2",""),
        new Note("gis2","#"),
        new Note("as2","b"),
        new Note("a2","")
    };

    public static Note[] allNotesKeyboard = {
        new Note("ces1", "b"),
        new Note("c1", ""),
        new Note("cis1", "#"),
        new Note("des1", "b"),
        new Note("d1", ""),
        new Note("dis1", "#"),
        new Note("es1","b"),
        new Note("e1",""),
        new Note("eis1","#"),
        new Note("fes1","b"),
        new Note("f1",""),
        new Note("fis1","#"),
        new Note("ges1","b"),
        new Note("g1",""),
        new Note("gis1","#"),
        new Note("as1","b"),
        new Note("a1",""),
        new Note("ais1","#"),
        new Note("b","b"),
        new Note("h1",""),
        new Note("his1","#"),
        new Note("ces2", "b"),
        new Note("c2", ""),
        new Note("cis2", "#"),
        new Note("des2", "b"),
        new Note("d2", ""),
        new Note("dis2", "#"),
        new Note("es2","b"),
        new Note("e2",""),
        new Note("eis2","#"),
        new Note("fes2","b"),
        new Note("f2",""),
        new Note("fis2","#"),
        new Note("ges2","b"),
        new Note("g2",""),
        new Note("gis2","#"),
        new Note("as2","b"),
        new Note("a2","")
    };

    /// <summary>
    /// internal Constructor <c>Note</c> 
    /// </summary>
    private Note(int midiIdx, string Name, float frequency, string sign, string[] possibleClefs = null)
    {
        this.name = Name;
        this.sign = sign;
        this.possibleClefs = possibleClefs;
        this.midiIdx = midiIdx;
        this.frequency = frequency;
        this.baseIdx = midiIdx % 12;
    }

    /// <summary>
    /// external Constructor <c>Note</c> based on midi and sign
    /// </summary>
    public Note(int midiIdx, string sign = "#")
    {
        if (sign == "#")
        {
            this.name = allNotesSharp[midiIdx].name;
            this.sign = allNotesSharp[midiIdx].sign;
        }
        else
        {
            this.name = allNotesB[midiIdx].name;
            this.sign = allNotesB[midiIdx].sign;
        }

        this.possibleClefs = allNotesSharp[midiIdx].possibleClefs;
        this.midiIdx = midiIdx;
        this.frequency = allNotesSharp[midiIdx].frequency;
        this.baseIdx = midiIdx % 12;

        switch (GameSettings.language)
        {
            case "de":
                this.nameLang = this.name;
                this.nameLang = this.nameLang.Replace("Cb", "Ces");
                this.nameLang = this.nameLang.Replace("C#", "Cis");
                this.nameLang = this.nameLang.Replace("Db", "Des");
                this.nameLang = this.nameLang.Replace("D#", "Dis");
                this.nameLang = this.nameLang.Replace("Eb#", "Es");
                this.nameLang = this.nameLang.Replace("E#", "Eis");
                this.nameLang = this.nameLang.Replace("Fb", "Fes");
                this.nameLang = this.nameLang.Replace("F#", "Fis");
                this.nameLang = this.nameLang.Replace("Gb", "Ges");
                this.nameLang = this.nameLang.Replace("G#", "Gis");
                this.nameLang = this.nameLang.Replace("Ab", "As");
                this.nameLang = this.nameLang.Replace("A#", "Ais");
                this.nameLang = this.nameLang.Replace("B", "H");
                this.nameLang = this.nameLang.Replace("Hb", "b");
                this.nameLang = this.nameLang.Replace("H#", "C");
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// external Constructor <c>Note</c> based on name and sign
    /// </summary>
    public Note(string name, string sign, string clef = "violin")
    {
        this.name = name;
        this.sign = sign;

        switch (sign)
        {
            case "#":
                for (int i = 0; i < allNotesSharp.Count(); i++)
                {
                    if (allNotesSharp[i].name == name)
                    {
                        this.midiIdx = allNotesSharp[i].midiIdx;
                        this.clef = allNotesSharp[i].clef;
                        this.frequency = allNotesSharp[i].frequency;
                        this.possibleClefs = allNotesSharp[i].possibleClefs;
                    }
                }
                break;
            case "b":
                for (int i = 0; i < allNotesB.Count(); i++)
                {
                    if (allNotesB[i].name == name)
                    {
                        this.midiIdx = allNotesB[i].midiIdx;
                        this.clef = allNotesB[i].clef;
                        this.frequency = allNotesB[i].frequency;
                        this.possibleClefs = allNotesB[i].possibleClefs;
                    }
                }
                break;
            default:
                UnityEngine.Debug.LogError("This note has no sign");
                return;
        }

    }

    /// <summary>
    /// external Constructor <c>Note</c> based on name
    /// </summary>
    public Note(string name, string clef = "violin")
    {
        this.name = name;
        this.clef = clef;

        if (name.ToLower().Contains("is"))
        {
            this.sign = sign = "#";
        }

        if (name.ToLower().Contains("es") | name.ToLower().Contains("as") | name.ToLower().Contains("b"))
        {
            this.sign = sign = "b";
        }

    }

    /// <summary>
    /// external Constructor <c>Note</c> for RandomNote
    /// </summary>
    public Note(string sign = "#")
    {
        System.Random random = new();
        int idx = random.Next(0, allNotesSharp.Count() - 1);
        UnityEngine.Debug.Log(idx);
        this.midiIdx = idx;
        this.baseIdx = midiIdx % 12;
        if (sign == "#")
        {
            this.name = allNotesSharp[idx].name;
            this.sign = allNotesSharp[idx].sign;
        }
        else
        {
            this.name = allNotesB[idx].name;
            this.sign = allNotesB[idx].sign;
        }

        this.possibleClefs = allNotesSharp[idx].possibleClefs;

        this.frequency = allNotesSharp[idx].frequency;

        switch (GameSettings.language)
        {
            case "de":
                this.nameLang = this.name;
                this.nameLang = this.nameLang.Replace("Cb", "Ces");
                this.nameLang = this.nameLang.Replace("C#", "Cis");
                this.nameLang = this.nameLang.Replace("Db", "Des");
                this.nameLang = this.nameLang.Replace("D#", "Dis");
                this.nameLang = this.nameLang.Replace("Eb#", "Es");
                this.nameLang = this.nameLang.Replace("E#", "Eis");
                this.nameLang = this.nameLang.Replace("Fb", "Fes");
                this.nameLang = this.nameLang.Replace("F#", "Fis");
                this.nameLang = this.nameLang.Replace("Gb", "Ges");
                this.nameLang = this.nameLang.Replace("G#", "Gis");
                this.nameLang = this.nameLang.Replace("Ab", "As");
                this.nameLang = this.nameLang.Replace("A#", "Ais");
                this.nameLang = this.nameLang.Replace("B", "H");
                this.nameLang = this.nameLang.Replace("Hb", "b");
                this.nameLang = this.nameLang.Replace("H#", "C");
                return;
            default:
                return;
        }

    }

    /// <summary>
    /// Methode <c>ToSimple</c> to get simple version of note
    /// </summary>
    public Note ToSimple()
    {
        Note output = this;
        if (output.sign == "b")
        {
            output.name = output.name.Replace("ces", "h");
            output.name = output.name.Replace("des", "cis");

            if (output.name[0] == 'e')
            {
                output.name = output.name.Replace("es", "dis");
            }

            output.name = output.name.Replace("fes", "e");
            output.name = output.name.Replace("ges", "fis");
            output.name = output.name.Replace("as", "gis");
            output.name = output.name.Replace("b", "ais");
            if (output.name.Contains("is"))
            {
                output.sign = "#";
            }
        }
        else
        {
            output.name = output.name.Replace("eis", "f");
            output.name = output.name.Replace("his", "c");
        }

        output.name = Regex.Replace(this.name, @"[\d-]", "");
        return output;
    }

    /// <summary>
    /// Methode <c>NoteDistance</c> to find out the distance between this and other Note
    /// </summary>
    public int NoteDistance(Note b) 
    {
        Note a = this;
        int distance = 0;
        Note lower, upper;
        if (a.midiIdx == b.midiIdx)
        {
            return distance;
        }
        if (a.midiIdx > b.midiIdx)
        {
            upper = a;
            lower = b;
        }
        else
        {
            upper = b;
            lower = a;
        }

        for (int m = lower.midiIdx + 1; m <= upper.midiIdx; m++)
        {
            if (allNotesB[m].sign == "")
            {
                distance++;
            }
        }

        return distance;
    }

    /// <summary>
    /// Methode <c>NoteDistance</c> to find out the distance between this and other midiIdx
    /// </summary>
    public int NoteDistance(int midiIdxB)
    {
        Note a = this;
        int distance = 0;
        Note lower, upper;
        if (a.midiIdx == midiIdxB)
        {
            UnityEngine.Debug.Log("same note");
            return distance;
        }
        if (a.midiIdx > midiIdxB)
        {
            UnityEngine.Debug.Log("Note is upper");
            upper = a;
            lower = new (midiIdxB);
        }
        else
        {
            UnityEngine.Debug.Log("reference is upper");
            upper = new(midiIdxB);
            lower = a;
        }

        if (a.sign == "#" || a.sign == "")
        {
            for (int m = lower.midiIdx; m < upper.midiIdx; m++)
            {
                if (allNotesB[m].sign == "")
                {
                    distance++;
                }
            }
        }
        if(a.sign == "b")
        {
            for (int m = lower.midiIdx; m < upper.midiIdx; m++)
            {
                if (allNotesSharp[m].sign == "")
                {
                    distance++;
                }
            }
        }
        if (a.midiIdx < midiIdxB)
        {
            distance = distance * -1;
        }
        UnityEngine.Debug.Log("distance: " + distance);
        return distance;
    }
}
