using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Rnd = UnityEngine.Random;

public class cyan : MonoBehaviour
{
    public KMBombModule Module;
    public KMBombInfo BombInfo;
    public KMAudio Audio;
    public KMSelectable ButtonSelectable;
    public GameObject ButtonCap;

    private static int _moduleIdCounter = 1;
    private int _moduleId;
    private bool _moduleSolved;
    public GameObject MO;
    public TextMesh DisplayText;
    public TextMesh ButtonText;
    private static readonly int[] N = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    public int num;
    public int answer;
    public bool boooled;
    public bool boo10;
    private char[,] REALtable = new char[6, 6];
    private string[,] displaytable = new string[6, 6];
    private int[,] binarytable = new int[6, 6];
    char[,] tableA = new char[6, 6]
        {
            {'A', 'L', 'M', 'X', 'Y', '0'},
            {'B', 'K', 'N', 'W', 'Z', '9'},
            {'C', 'J', 'O', 'V', '1', '8'},
            {'D', 'I', 'P', 'U', '2', '7'},
            {'E', 'H', 'Q', 'T', '3', '6'},
            {'F', 'G', 'R', 'S', '4', '5'}
        };
    char[,] tableB = new char[6, 6]
        {
            { 'A', 'B', 'C', 'D', 'E', 'F' },
            { 'G', 'H', 'I', 'J', 'K', 'L' },
            { 'M', 'N', 'O', 'P', 'Q', 'R' },
            { 'S', 'T', 'U', 'V', 'W', 'X' },
            { 'Y', 'Z', '0', '1', '2', '3' },
            { '4', '5', '6', '7', '8', '9' }
        };

    private void Start()
    {
        _moduleId = _moduleIdCounter++;
        ButtonSelectable.OnInteract += ButtonPress;
        ButtonSelectable.OnInteractEnded += ButtonRelease;
        FillTableWithRandomCharacters();
        boo10 = false;
        boooled = false;
        num = 0;
        for (int i = 0; i < 36; i++)
        {
            int randomNumber = Rnd.Range(0, 9);
            N[i] = randomNumber;
        }

        if (REALtable[0, 0].ToString() == "A" || REALtable[0, 0].ToString() == "C" || REALtable[0, 0].ToString() == "M" || REALtable[0, 0].ToString() == "N" || REALtable[0, 0].ToString() == "Q" || REALtable[0, 0].ToString() == "U")
        {
            answer += 32;
            binarytable[0, 0] = 1;
        }
        else 
        {
            binarytable[0, 0] = 0;
        }
        if (REALtable[0,1].ToString() == "Z" || REALtable[0,1].ToString() == "1" || REALtable[0,1].ToString() == "H" || REALtable[0,1].ToString() == "D" || REALtable[0,1].ToString() == "F" || REALtable[0,1].ToString() == "6")
        {
            answer += 16;
            binarytable[0, 1] = 1;
        }
        else
        {
            binarytable[0, 1] = 0;
        }
        if (REALtable[0,2].ToString() == "O" || REALtable[0,2].ToString() == "9" || REALtable[0,2].ToString() == "R" || REALtable[0,2].ToString() == "B" || REALtable[0,2].ToString() == "T" || REALtable[0,2].ToString() == "K")
        {
            answer += 8;
            binarytable[0, 2] = 1;
        }
        else
        {
            binarytable[0, 2] = 0;
        }
        if (REALtable[0,3].ToString() == "J" || REALtable[0,3].ToString() == "L" || REALtable[0,3].ToString() == "V" || REALtable[0,3].ToString() == "Y" || REALtable[0,3].ToString() == "E" || REALtable[0,3].ToString() == "G")
        {
            answer += 4;
            binarytable[0, 3] = 1;
        }
        else
        {
            binarytable[0, 3] = 0;
        }
        if (REALtable[0,4].ToString() == "8" || REALtable[0,4].ToString() == "I" || REALtable[0,4].ToString() == "7" || REALtable[0,4].ToString() == "X" || REALtable[0,4].ToString() == "5" || REALtable[0,4].ToString() == "P")
        {
            answer += 2;
            binarytable[0, 4] = 1;
        }
        else
        {
            binarytable[0, 4] = 0;
        }
        if (REALtable[0,5].ToString() == "4" || REALtable[0,5].ToString() == "S" || REALtable[0,5].ToString() == "W" || REALtable[0,5].ToString() == "0" || REALtable[0,5].ToString() == "3" || REALtable[0,5].ToString() == "2")
        {
            answer += 1;
            binarytable[0, 5] = 1;
        }
        else
        {
            binarytable[0, 5] = 0;
        }
        if (REALtable[1, 0].ToString() == "P" || REALtable[1, 0].ToString() == "K" || REALtable[1, 0].ToString() == "H" || REALtable[1, 0].ToString() == "L" || REALtable[1, 0].ToString() == "T" || REALtable[1, 0].ToString() == "3")
        {
            answer += 32;
            binarytable[1, 0] = 1;
        }
        else
        {
            binarytable[1, 0] = 0;
        }
        if (REALtable[1, 1].ToString() == "Q" || REALtable[1, 1].ToString() == "M" || REALtable[1, 1].ToString() == "1" || REALtable[1, 1].ToString() == "S" || REALtable[1, 1].ToString() == "B" || REALtable[1, 1].ToString() == "J")
        {
            answer += 16;
            binarytable[1, 1] = 1;
        }
        else
        {
            binarytable[1, 1] = 0;
        }
        if (REALtable[1, 2].ToString() == "U" || REALtable[1, 2].ToString() == "7" || REALtable[1, 2].ToString() == "V" || REALtable[1, 2].ToString() == "O" || REALtable[1, 2].ToString() == "4" || REALtable[1, 2].ToString() == "E")
        {
            answer += 8;
            binarytable[1, 2] = 1;
        }
        else
        {
            binarytable[1, 2] = 0;
        }
        if (REALtable[1, 3].ToString() == "Y" || REALtable[1, 3].ToString() == "C" || REALtable[1, 3].ToString() == "W" || REALtable[1, 3].ToString() == "G" || REALtable[1, 3].ToString() == "N" || REALtable[1, 3].ToString() == "0")
        {
            answer += 4;
            binarytable[1, 3] = 1;
        }
        else
        {
            binarytable[1, 3] = 0;
        }
        if (REALtable[1, 4].ToString() == "8" || REALtable[1, 4].ToString() == "D" || REALtable[1, 4].ToString() == "9" || REALtable[1, 4].ToString() == "5" || REALtable[1, 4].ToString() == "X" || REALtable[1, 4].ToString() == "F")
        {
            answer += 2;
            binarytable[1, 4] = 1;
        }
        else
        {
            binarytable[1, 4] = 0;
        }
        if (REALtable[1, 5].ToString() == "R" || REALtable[1, 5].ToString() == "Z" || REALtable[1, 5].ToString() == "I" || REALtable[1, 5].ToString() == "6" || REALtable[1, 5].ToString() == "A" || REALtable[1, 5].ToString() == "2")
        {
            answer += 1;
            binarytable[1, 5] = 1;
        }
        else
        {
            binarytable[1, 5] = 0;
        }
        if (REALtable[2, 0].ToString() == "D" || REALtable[2, 0].ToString() == "T" || REALtable[2, 0].ToString() == "X" || REALtable[2, 0].ToString() == "V" || REALtable[2, 0].ToString() == "Y" || REALtable[2, 0].ToString() == "L")
        {
            answer += 32;
            binarytable[2, 0] = 1;
        }
        else
        {
            binarytable[2, 0] = 0;
        }
        if (REALtable[2, 1].ToString() == "2" || REALtable[2, 1].ToString() == "U" || REALtable[2, 1].ToString() == "N" || REALtable[2, 1].ToString() == "F" || REALtable[2, 1].ToString() == "C" || REALtable[2, 1].ToString() == "M")
        {
            answer += 16;
            binarytable[2, 1] = 1;
        }
        else
        {
            binarytable[2, 1] = 0;
        }
        if (REALtable[2, 2].ToString() == "3" || REALtable[2, 2].ToString() == "K" || REALtable[2, 2].ToString() == "8" || REALtable[2, 2].ToString() == "O" || REALtable[2, 2].ToString() == "Q" || REALtable[2, 2].ToString() == "4")
        {
            answer += 8;
            binarytable[2, 2] = 1;
        }
        else
        {
            binarytable[2, 2] = 0;
        }
        if (REALtable[2, 3].ToString() == "E" || REALtable[2, 3].ToString() == "B" || REALtable[2, 3].ToString() == "H" || REALtable[2, 3].ToString() == "P" || REALtable[2, 3].ToString() == "J" || REALtable[2, 3].ToString() == "5")
        {
            answer += 4;
            binarytable[2, 3] = 1;
        }
        else
        {
            binarytable[2, 3] = 0;
        }
        if (REALtable[2, 4].ToString() == "R" || REALtable[2, 4].ToString() == "G" || REALtable[2, 4].ToString() == "W" || REALtable[2, 4].ToString() == "Z" || REALtable[2, 4].ToString() == "7" || REALtable[2, 4].ToString() == "1")
        {
            answer += 2;
            binarytable[2, 4] = 1;
        }
        else
        {
            binarytable[2, 4] = 0;
        }
        if (REALtable[2, 5].ToString() == "A" || REALtable[2, 5].ToString() == "S" || REALtable[2, 5].ToString() == "I" || REALtable[2, 5].ToString() == "6" || REALtable[2, 5].ToString() == "9" || REALtable[2, 5].ToString() == "0")
        {
            answer += 1;
            binarytable[2, 5] = 1;
        }
        else
        {
            binarytable[2, 5] = 0;
        }
        if (REALtable[3, 0].ToString() == "0" || REALtable[3, 0].ToString() == "5" || REALtable[3, 0].ToString() == "Q" || REALtable[3, 0].ToString() == "S" || REALtable[3, 0].ToString() == "E" || REALtable[3, 0].ToString() == "Z")
        {
            answer += 32;
            binarytable[3, 0] = 1;
        }
        else
        {
            binarytable[3, 0] = 0;
        }
        if (REALtable[3, 1].ToString() == "D" || REALtable[3, 1].ToString() == "R" || REALtable[3, 1].ToString() == "3" || REALtable[3, 1].ToString() == "A" || REALtable[3, 1].ToString() == "B" || REALtable[3, 1].ToString() == "T")
        {
            answer += 16;
            binarytable[3, 1] = 1;
        }
        else
        {
            binarytable[3, 1] = 0;
        }
        if (REALtable[3, 2].ToString() == "X" || REALtable[3, 2].ToString() == "J" || REALtable[3, 2].ToString() == "L" || REALtable[3, 2].ToString() == "1" || REALtable[3, 2].ToString() == "2" || REALtable[3, 2].ToString() == "F")
        {
            answer += 8;
            binarytable[3, 2] = 1;
        }
        else
        {
            binarytable[3, 2] = 0;
        }
        if (REALtable[3, 3].ToString() == "U" || REALtable[3, 3].ToString() == "7" || REALtable[3, 3].ToString() == "8" || REALtable[3, 3].ToString() == "M" || REALtable[3, 3].ToString() == "G" || REALtable[3, 3].ToString() == "9")
        {
            answer += 4;
            binarytable[3, 3] = 1;
        }
        else
        {
            binarytable[3, 3] = 0;
        }
        if (REALtable[3, 4].ToString() == "4" || REALtable[3, 4].ToString() == "V" || REALtable[3, 4].ToString() == "I" || REALtable[3, 4].ToString() == "H" || REALtable[3, 4].ToString() == "P" || REALtable[3, 4].ToString() == "W")
        {
            answer += 2;
            binarytable[3, 4] = 1;
        }
        else
        {
            binarytable[3, 4] = 0;
        }
        if (REALtable[3, 5].ToString() == "O" || REALtable[3, 5].ToString() == "Y" || REALtable[3, 5].ToString() == "C" || REALtable[3, 5].ToString() == "K" || REALtable[3, 5].ToString() == "6" || REALtable[3, 5].ToString() == "N")
        {
            answer += 1;
            binarytable[3, 5] = 1;
        }
        else
        {
            binarytable[3, 5] = 0;
        }
        if (REALtable[4, 0].ToString() == "4" || REALtable[4, 0].ToString() == "B" || REALtable[4, 0].ToString() == "6" || REALtable[4, 0].ToString() == "C" || REALtable[4, 0].ToString() == "G" || REALtable[4, 0].ToString() == "K")
        {
            answer += 32;
            binarytable[4, 0] = 1;
        }
        else
        {
            binarytable[4, 0] = 0;
        }
        if (REALtable[4, 1].ToString() == "Q" || REALtable[4, 1].ToString() == "3" || REALtable[4, 1].ToString() == "H" || REALtable[4, 1].ToString() == "X" || REALtable[4, 1].ToString() == "F" || REALtable[4, 1].ToString() == "E")
        {
            answer += 16;
            binarytable[4, 1] = 1;
        }
        else
        {
            binarytable[4, 1] = 0;
        }
        if (REALtable[4, 2].ToString() == "8" || REALtable[4, 2].ToString() == "T" || REALtable[4, 2].ToString() == "7" || REALtable[4, 2].ToString() == "Z" || REALtable[4, 2].ToString() == "V" || REALtable[4, 2].ToString() == "J")
        {
            answer += 8;
            binarytable[4, 2] = 1;
        }
        else
        {
            binarytable[4, 2] = 0;
        }
        if (REALtable[4, 3].ToString() == "Y" || REALtable[4, 3].ToString() == "O" || REALtable[4, 3].ToString() == "P" || REALtable[4, 3].ToString() == "2" || REALtable[4, 3].ToString() == "L" || REALtable[4, 3].ToString() == "0")
        {
            answer += 4;
            binarytable[4, 3] = 1;
        }
        else
        {
            binarytable[4, 3] = 0;
        }
        if (REALtable[4, 4].ToString() == "9" || REALtable[4, 4].ToString() == "A" || REALtable[4, 4].ToString() == "I" || REALtable[4, 4].ToString() == "M" || REALtable[4, 4].ToString() == "D" || REALtable[4, 4].ToString() == "1")
        {
            answer += 2;
            binarytable[4, 4] = 1;
        }
        else
        {
            binarytable[4, 4] = 0;
        }
        if (REALtable[4, 5].ToString() == "5" || REALtable[4, 5].ToString() == "N" || REALtable[4, 5].ToString() == "S" || REALtable[4, 5].ToString() == "R" || REALtable[4, 5].ToString() == "U" || REALtable[4, 5].ToString() == "W")
        {
            answer += 1;
            binarytable[4, 5] = 1;
        }
        else
        {
            binarytable[4, 5] = 0;
        }
        if (REALtable[5, 0].ToString() == "Y" || REALtable[5, 0].ToString() == "0" || REALtable[5, 0].ToString() == "K" || REALtable[5, 0].ToString() == "1" || REALtable[5, 0].ToString() == "L" || REALtable[5, 0].ToString() == "V")
        {
            answer += 32;
            binarytable[5, 0] = 1;
        }
        else
        {
            binarytable[5, 0] = 0;
        }
        if (REALtable[5, 1].ToString() == "E" || REALtable[5, 1].ToString() == "4" || REALtable[5, 1].ToString() == "D" || REALtable[5, 1].ToString() == "R" || REALtable[5, 1].ToString() == "2" || REALtable[5, 1].ToString() == "T")
        {
            answer += 16;
            binarytable[5, 1] = 1;
        }
        else
        {
            binarytable[5, 1] = 0;
        }
        if (REALtable[5, 2].ToString() == "9" || REALtable[5, 2].ToString() == "M" || REALtable[5, 2].ToString() == "X" || REALtable[5, 2].ToString() == "P" || REALtable[5, 2].ToString() == "S" || REALtable[5, 2].ToString() == "8")
        {
            answer += 8;
            binarytable[5, 2] = 1;
        }
        else
        {
            binarytable[5, 2] = 0;
        }
        if (REALtable[5, 3].ToString() == "3" || REALtable[5, 3].ToString() == "N" || REALtable[5, 3].ToString() == "Z" || REALtable[5, 3].ToString() == "5" || REALtable[5, 3].ToString() == "O" || REALtable[5, 3].ToString() == "G")
        {
            answer += 4;
            binarytable[5, 3] = 1;
        }
        else
        {
            binarytable[5, 3] = 0;
        }
        if (REALtable[5, 4].ToString() == "H" || REALtable[5, 4].ToString() == "6" || REALtable[5, 4].ToString() == "C" || REALtable[5, 4].ToString() == "B" || REALtable[5, 4].ToString() == "Q" || REALtable[5, 4].ToString() == "W")
        {
            answer += 2;
            binarytable[5, 4] = 1;
        }
        else
        {
            binarytable[5, 4] = 0;
        }
        if (REALtable[5, 5].ToString() == "F" || REALtable[5, 5].ToString() == "7" || REALtable[5, 5].ToString() == "U" || REALtable[5, 5].ToString() == "I" || REALtable[5, 5].ToString() == "A" || REALtable[5, 5].ToString() == "J")
        {
            answer += 1;
            binarytable[5, 5] = 1;
        }
        else
        {
            binarytable[5, 5] = 0;
        }
        answer = answer % 60;
        StartCoroutine(Calculate());
    }

    private bool ButtonPress()
    {
        StartCoroutine(AnimateButton(0f, -0.05f));
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.BigButtonPress, transform);
        if (!_moduleSolved)
        {
            if ((int)BombInfo.GetTime() % 60 == answer)
            {
                GetComponent<KMBombModule>().HandlePass();
                _moduleSolved = true;
                Debug.LogFormat("[Cyan Button't #{0}] Solve!!!", _moduleId);
            }
            else
            {
                GetComponent<KMBombModule>().HandleStrike();
                Debug.LogFormat("[Cyan Button't #{0}] Strike!!!", _moduleId);
            }
            Debug.LogFormat("[Cyan Button't #{0}] Held the button", _moduleId);
        
        }
        return false;
    }

    private void ButtonRelease()
    {
        StartCoroutine(AnimateButton(-0.05f, 0f));
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.BigButtonRelease, transform);
        if (!_moduleSolved)
        {
            print("RELEASE");
        }
    }
    private void FillTableWithRandomCharacters()
    {
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 6; col++)
            {
                int randomNumber = Rnd.Range(0,36);
                REALtable[row, col] = GetCharacter(randomNumber);
            }
        }
    }

    private char GetCharacter(int number)
    {
        if (number < 10)
        {
            return (char)('0' + number);
        }
        else
        {
            return (char)('A' + (number - 10));
        }
    }

    private IEnumerator AnimateButton(float a, float b)
    {
        var duration = 0.1f;
        var elapsed = 0f;
        while (elapsed < duration)
        {
            ButtonCap.transform.localPosition = new Vector3(0f, Easing.InOutQuad(elapsed, a, b, duration), 0f);
            yield return null;
            elapsed += Time.deltaTime;
        }
        ButtonCap.transform.localPosition = new Vector3(0f, b, 0f);
    }

    
    private IEnumerator Calculate()
    {
        while (!_moduleSolved)
        {
            num = Math.Abs(num % 37);
            if (num <36) 
            {
                ButtonText.text = N[num].ToString();
                char targetLetter = REALtable[num / 6, Math.Abs(num % 6)];
                if (N[num] > 5)
                {
                    if (N[num] == 6)
                    {
                        int targetRow = -1;
                        int targetCol = -1;
                        int newRow = -1;
                        int newCol = -1;

                        for (int row = 0; row < 6; row++)
                        {
                            for (int col = 0; col < 6; col++)
                            {
                                if (tableA[row, col] == targetLetter)
                                {
                                    targetRow = row;
                                    targetCol = col;
                                    newRow = Math.Abs((targetRow - 2 + 6) % 6);
                                    newCol = Math.Abs((targetCol - 1 + 6) % 6);
                                    DisplayText.text = tableA[newRow, newCol].ToString();
                                    displaytable[num / 6, Math.Abs(num % 6)] = tableA[newRow, newCol].ToString();
                                }
                            }
                        }
                    }
                    else if (N[num] == 7)
                    {
                        int targetRow = -1;
                        int targetCol = -1;
                        int newRow = -1;
                        int newCol = -1;

                        for (int row = 0; row < 6; row++)
                        {
                            for (int col = 0; col < 6; col++)
                            {
                                if (tableA[row, col] == targetLetter)
                                {
                                    targetRow = row;
                                    targetCol = col;
                                    newRow = Math.Abs((targetRow - 1 + 6) % 6);
                                    newCol = Math.Abs((targetCol - 2 + 6) % 6);
                                    DisplayText.text = tableA[newRow, newCol].ToString();
                                    displaytable[num / 6, Math.Abs(num % 6)] = tableA[newRow, newCol].ToString();
                                }
                            }
                        }
                    }
                    else if (N[num] == 8)
                    {
                        int targetRow = -1;
                        int targetCol = -1;
                        int newRow = -1;
                        int newCol = -1;

                        for (int row = 0; row < 6; row++)
                        {
                            for (int col = 0; col < 6; col++)
                            {
                                if (tableA[row, col] == targetLetter)
                                {
                                    targetRow = row;
                                    targetCol = col;
                                    newRow = Math.Abs((targetRow + 3 + 6) % 6);
                                    newCol = Math.Abs((targetCol - 1 + 6) % 6);
                                    DisplayText.text = tableA[newRow, newCol].ToString();
                                    displaytable[num / 6, Math.Abs(num % 6)] = tableA[newRow, newCol].ToString();
                                }
                            }
                        }
                    }
                    else if (N[num] == 9)
                    {
                        int targetRow = -1;
                        int targetCol = -1;
                        int newRow = -1;
                        int newCol = -1;

                        for (int row = 0; row < 6; row++)
                        {
                            for (int col = 0; col < 6; col++)
                            {
                                if (tableA[row, col] == targetLetter)
                                {
                                    targetRow = row;
                                    targetCol = col;
                                    newRow = Math.Abs((targetRow - 4 + 6) % 6);
                                    newCol = Math.Abs((targetCol + 2 + 6) % 6);
                                    DisplayText.text = tableA[newRow, newCol].ToString();
                                    displaytable[num / 6, Math.Abs(num % 6)] = tableA[newRow, newCol].ToString();
                                }
                            }
                        }
                    }
                }
                else if (N[num] <= 5)
                {
                    if (N[num] == 0)
                    {
                        int targetRow = -1;
                        int targetCol = -1;
                        int newRow = -1;
                        int newCol = -1;

                        for (int row = 0; row < 6; row++)
                        {
                            for (int col = 0; col < 6; col++)
                            {
                                if (tableB[row, col] == targetLetter)
                                {
                                    targetRow = row;
                                    targetCol = col;
                                    newRow = Math.Abs((targetRow + 2 + 6) % 6);
                                    newCol = Math.Abs((targetCol - 1 + 6) % 6);
                                    DisplayText.text = tableB[newRow, newCol].ToString();
                                    displaytable[num / 6, Math.Abs(num % 6)] = tableB[newRow, newCol].ToString();
                                }
                            }
                        }
                    }
                    else if (N[num] == 1)
                    {
                        int targetRow = -1;
                        int targetCol = -1;
                        int newRow = -1;
                        int newCol = -1;

                        for (int row = 0; row < 6; row++)
                        {
                            for (int col = 0; col < 6; col++)
                            {
                                if (tableB[row, col] == targetLetter)
                                {
                                    targetRow = row;
                                    targetCol = col;
                                    newRow = Math.Abs((targetRow - 2 + 6) % 6);
                                    newCol = Math.Abs((targetCol + 4 + 6) % 6);
                                    DisplayText.text = tableB[newRow, newCol].ToString();
                                    displaytable[num / 6, Math.Abs(num % 6)] = tableB[newRow, newCol].ToString();
                                }
                            }
                        }
                    }
                    else if (N[num] == 2)
                    {
                        int targetRow = -1;
                        int targetCol = -1;
                        int newRow = -1;
                        int newCol = -1;

                        for (int row = 0; row < 6; row++)
                        {
                            for (int col = 0; col < 6; col++)
                            {
                                if (tableB[row, col] == targetLetter)
                                {
                                    targetRow = row;
                                    targetCol = col;
                                    newRow = Math.Abs((targetRow - 3 + 6) % 6);
                                    newCol = Math.Abs((targetCol + 1 + 6) % 6);
                                    DisplayText.text = tableB[newRow, newCol].ToString();
                                    displaytable[num / 6, Math.Abs(num % 6)] = tableB[newRow, newCol].ToString();
                                }
                            }
                        }
                    }
                    else if (N[num] == 3)
                    {
                        int targetRow = -1;
                        int targetCol = -1;
                        int newRow = -1;
                        int newCol = -1;

                        for (int row = 0; row < 6; row++)
                        {
                            for (int col = 0; col < 6; col++)
                            {
                                if (tableB[row, col] == targetLetter)
                                {
                                    targetRow = row;
                                    targetCol = col;
                                    newRow = Math.Abs((targetRow + 1 + 6) % 6);
                                    newCol = Math.Abs((targetCol - 1 + 6) % 6);
                                    DisplayText.text = tableB[newRow, newCol].ToString();
                                    displaytable[num / 6, Math.Abs(num % 6)] = tableB[newRow, newCol].ToString();
                                }
                            }
                        }
                    }
                    else if (N[num] == 4)
                    {
                        int targetRow = -1;
                        int targetCol = -1;
                        int newRow = -1;
                        int newCol = -1;

                        for (int row = 0; row < 6; row++)
                        {
                            for (int col = 0; col < 6; col++)
                            {
                                if (tableB[row, col] == targetLetter)
                                {
                                    targetRow = row;
                                    targetCol = col;
                                    newRow = Math.Abs((targetRow - 3 + 6) % 6);
                                    newCol = Math.Abs((targetCol - 4 + 6) % 6);
                                    DisplayText.text = tableB[newRow, newCol].ToString();
                                    displaytable[num / 6, Math.Abs(num % 6)] = tableB[newRow, newCol].ToString();
                                }
                            }
                        }
                    }
                    else if (N[num] == 5)
                    {
                        int targetRow = -1;
                        int targetCol = -1;
                        int newRow = -1;
                        int newCol = -1;

                        for (int row = 0; row < 6; row++)
                        {
                            for (int col = 0; col < 6; col++)
                            {
                                if (tableB[row, col] == targetLetter)
                                {
                                    targetRow = row;
                                    targetCol = col;
                                    newRow = Math.Abs((targetRow - 1 + 6) % 6);
                                    newCol = Math.Abs((targetCol + 3 + 6) % 6);
                                    DisplayText.text = tableB[newRow, newCol].ToString();
                                    displaytable[num / 6, Math.Abs(num % 6)] = tableB[newRow, newCol].ToString();
                                }
                            }
                        }
                    }
                }
                yield return new WaitForSeconds(.5f);
            }
            else if (num==36)
            {
                ButtonText.text = "NO";
                DisplayText.text = "";
                yield return new WaitForSeconds(2f);
             }
            num += 1;
            if (boo10 == true)
            {
                if (boooled == false)
                {
                    Debug.LogFormat("[Cyan Button't #{0}] Table without deviation:", _moduleId);
                    Debug.LogFormat("[Cyan Button't #{0}] Row 1:{1}", _moduleId, string.Concat(REALtable[0, 0].ToString(), REALtable[0, 1].ToString(), REALtable[0, 2].ToString(), REALtable[0, 3].ToString(), REALtable[0, 4].ToString(), REALtable[0, 5].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] Row 2:{1}", _moduleId, string.Concat(REALtable[1, 0].ToString(), REALtable[1, 1].ToString(), REALtable[1, 2].ToString(), REALtable[1, 3].ToString(), REALtable[1, 4].ToString(), REALtable[1, 5].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] Row 3:{1}", _moduleId, string.Concat(REALtable[2, 0].ToString(), REALtable[2, 1].ToString(), REALtable[2, 2].ToString(), REALtable[2, 3].ToString(), REALtable[2, 4].ToString(), REALtable[2, 5].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] Row 4:{1}", _moduleId, string.Concat(REALtable[3, 0].ToString(), REALtable[3, 1].ToString(), REALtable[3, 2].ToString(), REALtable[3, 3].ToString(), REALtable[3, 4].ToString(), REALtable[3, 5].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] Row 5:{1}", _moduleId, string.Concat(REALtable[4, 0].ToString(), REALtable[4, 1].ToString(), REALtable[4, 2].ToString(), REALtable[4, 3].ToString(), REALtable[4, 4].ToString(), REALtable[4, 5].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] Row 6:{1}", _moduleId, string.Concat(REALtable[5, 0].ToString(), REALtable[5, 1].ToString(), REALtable[5, 2].ToString(), REALtable[5, 3].ToString(), REALtable[5, 4].ToString(), REALtable[5, 5].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] N:{1}", _moduleId, string.Concat(N[0].ToString(), N[1].ToString(), N[2].ToString(), N[3].ToString(), N[4].ToString(), N[5].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] N:{1}", _moduleId, string.Concat(N[6].ToString(), N[7].ToString(), N[8].ToString(), N[9].ToString(), N[10].ToString(), N[11].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] N:{1}", _moduleId, string.Concat(N[12].ToString(), N[13].ToString(), N[14].ToString(), N[15].ToString(), N[16].ToString(), N[17].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] N:{1}", _moduleId, string.Concat(N[18].ToString(), N[19].ToString(), N[20].ToString(), N[21].ToString(), N[22].ToString(), N[23].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] N:{1}", _moduleId, string.Concat(N[24].ToString(), N[25].ToString(), N[26].ToString(), N[27].ToString(), N[28].ToString(), N[29].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] N:{1}", _moduleId, string.Concat(N[30].ToString(), N[31].ToString(), N[32].ToString(), N[33].ToString(), N[34].ToString(), N[35].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] binary 1:{1}", _moduleId, string.Concat(binarytable[0,0].ToString(), binarytable[0, 1].ToString(),binarytable[0, 2].ToString(),binarytable[0, 3].ToString(),binarytable[0, 4].ToString(),binarytable[0, 5].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] binary 2:{1}", _moduleId, string.Concat(binarytable[1, 0].ToString(), binarytable[1, 1].ToString(), binarytable[1, 2].ToString(), binarytable[1, 3].ToString(), binarytable[1, 4].ToString(), binarytable[1, 5].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] binary 3:{1}", _moduleId, string.Concat(binarytable[2, 0].ToString(), binarytable[2, 1].ToString(), binarytable[2, 2].ToString(), binarytable[2, 3].ToString(), binarytable[2, 4].ToString(), binarytable[2, 5].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] binary 4:{1}", _moduleId, string.Concat(binarytable[3, 0].ToString(), binarytable[3, 1].ToString(), binarytable[3, 2].ToString(), binarytable[3, 3].ToString(), binarytable[3, 4].ToString(), binarytable[3, 5].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] binary 5:{1}", _moduleId, string.Concat(binarytable[4, 0].ToString(), binarytable[4, 1].ToString(), binarytable[4, 2].ToString(), binarytable[4, 3].ToString(), binarytable[4, 4].ToString(), binarytable[4, 5].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] binary 6:{1}", _moduleId, string.Concat(binarytable[5, 0].ToString(), binarytable[5, 1].ToString(), binarytable[5, 2].ToString(), binarytable[5, 3].ToString(), binarytable[5, 4].ToString(), binarytable[5, 5].ToString()));
                    Debug.LogFormat("[Cyan Button't #{0}] Answer:{1}", _moduleId, answer.ToString());
                    boooled = true;
                }
            }
           boo10 = true;
        }
    }

#pragma warning disable 0414
    public readonly string TwitchHelpMessage = @"!{0} press 23 to press when the last two digits of the timer are 23.";
#pragma warning restore 0414

    private IEnumerator ProcessTwitchCommand(string command)
    {
        print(command);
        var parameters = command.ToUpperInvariant().Split();
        var m = Regex.Match(parameters[0], @"^\s*press\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        if (!m.Success)
            yield break;
        if (parameters.Length < 2)
            yield break;
        var list = new List<int>();
        for (int i = 1; i < parameters.Length; i++)
        {
            int val;
            if (!int.TryParse(parameters[i], out val) || val < 0 || val > 59)
                yield break;
            list.Add(val);
        }
        yield return null;
        for (int i = 0; i < list.Count; i++)
        {
            while ((int)BombInfo.GetTime() % 60 != list[i])
                yield return "trycancel";
            ButtonSelectable.OnInteract();
            yield return new WaitForSeconds(0.1f);
            ButtonSelectable.OnInteractEnded();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator TwitchHandleForcedSolve()
    {
        while ((int)BombInfo.GetTime() % 60 != answer)
            yield return "trycancel";
        ButtonSelectable.OnInteract();
        yield return new WaitForSeconds(0.1f);
    }
}