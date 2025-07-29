using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Rnd = UnityEngine.Random;

public class pink : MonoBehaviour
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
    public TextMesh ExtraText;
    public string wordcode;
    public string colorcode;
    string[] WORDS = { "BUD", "COW", "PAC", "JUG", "LOG", "VOW","ZIP","BOW","LAX","BIB","ZAP" };
    public string wordcodeword;
    public string colorcodeword;
    public int wordcodewordnum;
    public int colorcodewordnum;
    public string mainletter;
    public string otherword;
    public string secondaryletter;
    public int NUM;
    public int RandomShuffle;
    public int RandomShuffle1;
    public string wordcodemorse;
    public string colorcodemorse;
    public string wordcodebinary;
    public string colorcodebinary;
    string[] wordColor = { "", "", "", "", "" };
    string[] colorColor = { "", "", "", "", "" };
    string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    List<string> alphabetList;
    string[] letterF = { "", "", "", "", "", "", "", "" };
    int[] indexF = {0,0,0,0,0,0,0,0 };
    public string answer;
    public int index;
    public int sum;
    public string answermorsecode;
    public string answerbinary;
    public string realanswer;
    private int _mashCount = 0;
    private int _lastPressTime = 0;
    private int _currentSequenceStart = 0;
    private bool _isActiveSequence = false;
    private Coroutine _mashSequenceCoroutine;
    private const int MASH_TIMEOUT = 2;
    public string input;
    private bool _isLongPressing = false;
    private const int LONG_PRESS_THRESHOLD = 1;
    private Coroutine _longPressCoroutine;
    private bool _wasLongPress = false;
    private bool isConfirming = false;
    private float _longPressStartTimeFloat;
    private int extrawordsum;
    string[,] letterTable = new string[11, 11]
    {
    { "X", "Q", "M", "P", "Z", "L", "D", "R", "F", "B", "B" },  
    { "R", "K", "Y", "F", "P", "J", "V", "B", "Z", "Q", "Y" }, 
    { "L", "D", "G", "H", "J", "K", "V", "C", "S", "T", "A" }, 
    { "M", "P", "Z", "L", "D", "R", "F", "B", "N", "G", "Z" },  
    { "F", "B", "N", "G", "H", "J", "K", "V", "C", "S", "D" },  
    { "Q", "X", "W", "M", "D", "G", "L", "S", "N", "H", "P" },  
    { "V", "C", "S", "T", "W", "Y", "A", "E", "I", "O", "O" },  
    { "E", "I", "O", "U", "X", "Q", "M", "P", "Z", "L", "O" }, 
    { "B", "Z", "Q", "X", "W", "M", "D", "G", "L", "S", "N" }, 
    { "G", "L", "S", "N", "H", "T", "C", "O", "I", "E", "M" },  
    { "Q", "X", "W", "M", "D", "G", "L", "S", "N", "H", "P" } 
    };
    string[] wordslist = { "ARID", "AURA", "BEAD", "BEAR", "BEEF", "BELT", "BEND", "DAFT", "DAWN", "DICE", "DIVE", "FEAR", "FEEL", "FELT", "GANG", "GAVE", "GAZE", "GIFT", "GILT", "GIVE", "HEAD", "HEAR", "HEEL", "HEIR", "IDLE", "IRON", "KIND", "KING", "KIWI", "LEAD", "LEAK", "LEFT", "LEND", "LENS", "MOLE", "MONK", "MOON", "MOTH", "MOVE", "MULE", "NOON", "NORM", "NOUN", "OATH", "OINK", "ONCE", "PEAK", "PEAR", "PEEL", "RACE", "RAFT", "RAID", "RANK", "RICE", "RIFT", "RING", "RIPE", "SAFE", "SAGA", "SAID", "SALE", "SALT", "SAND", "SANG", "SANK", "SAVE", "SIGN", "SING", "SINK", "SIZE", "THAW", "THEY", "THIS", "TYPE", "WAND", "WARM", "WARN", "WAVE", "WIFE", "WIND", "WING", "WIPE", "WITH", "YEAR" };
    string[] posList = { "A", "N", "N", "N", "N", "N", "N", "A", "N", "N", "V", "N", "V", "N", "N", "V", "N", "N", "N", "V", "N", "V", "N", "N", "A", "N", "N", "N", "N", "N", "N", "N", "V", "N", "N", "N", "N", "N", "N", "N", "N", "N", "N", "N", "O", "D", "N", "N", "N", "N", "N", "N", "N", "N", "N", "N", "A", "N", "N", "V", "N", "N", "N", "V", "V", "V", "N", "V", "N", "N", "V", "O", "O", "N", "N", "A", "V", "N", "N", "N", "N", "V", "O", "N" };
    private static readonly Dictionary<char, string> MorseCodeDictionary = new Dictionary<char, string>()
    {
        {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
        {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
        {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
        {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
        {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
        {'Z', "--.."}, {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
        {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."},
        {'9', "----."}, {' ', "/"}  
    };

    private void Start()
    {
        _moduleId = _moduleIdCounter++;
        ButtonSelectable.OnInteract += ButtonPress;
        ButtonSelectable.OnInteractEnded += ButtonRelease;
        wordcodewordnum = Rnd.Range(0,10);
        colorcodewordnum = Rnd.Range(0, 10);
        wordcodeword = WORDS[wordcodewordnum];
        colorcodeword = WORDS[colorcodewordnum];
        mainletter = letterTable[wordcodewordnum, colorcodewordnum];
        NUM = Rnd.Range(0, 82);
        otherword = wordslist[NUM];
        secondaryletter = posList[NUM];
        RandomShuffle = Rnd.Range(0, 3);
        if (RandomShuffle == 0)
        {
            wordcode = string.Concat(wordcodeword, otherword.Substring(0, 2));
        }
        if (RandomShuffle == 1)
        {
            wordcode = string.Concat(otherword.Substring(0, 2), wordcodeword);
        }
        if (RandomShuffle == 2)
        {
            wordcode = string.Concat(otherword.Substring(0, 1), wordcodeword, otherword.Substring(1, 1));
        }
        RandomShuffle1 = Rnd.Range(0, 3);
        if (RandomShuffle1 == 0)
        {
            colorcode = string.Concat(colorcodeword, otherword.Substring(2, 2));
        }
        if (RandomShuffle1 == 1)
        {
            colorcode = string.Concat(otherword.Substring(2, 2), colorcodeword);
        }
        if (RandomShuffle1 == 2)
        {
            colorcode = string.Concat(otherword.Substring(2, 1), colorcodeword, otherword.Substring(3, 1));
        }
        wordcodemorse = ConvertToMorseCode(wordcode);
        colorcodemorse = ConvertToMorseCode(colorcode);
        wordcodebinary = wordcodemorse.Replace("-", "1").Replace(".","0");
        colorcodebinary = colorcodemorse.Replace("-", "1").Replace(".", "0");
        RGBword(wordcodebinary,0,wordColor);
        RGBword(colorcodebinary, 1, colorColor);
        print(wordcode);
        print(wordcodebinary);
        print(string.Concat(wordColor[0], wordColor[1], wordColor[2], wordColor[3], wordColor[4]));
        print(colorcode);
        print(colorcodebinary);
        print(string.Concat(colorColor[0], colorColor[1], colorColor[2], colorColor[3], colorColor[4]));
        letterF[0] = mainletter;
        letterF[1] = wordcodeword.Substring(0, 1);
        letterF[2] = wordcodeword.Substring(1, 1);
        letterF[3] = wordcodeword.Substring(2, 1);
        letterF[4] = colorcodeword.Substring(0, 1);
        letterF[5] = colorcodeword.Substring(1, 1);
        letterF[6] = colorcodeword.Substring(2, 1);
        letterF[7] = secondaryletter;
        print(string.Concat(letterF[0], letterF[1], letterF[2], letterF[3], letterF[4], letterF[5], letterF[6], letterF[7]));
        List<string> alphabetList = alphabet.ToList();
        for (int i = 0; i < 8; i++)
        {
            index = alphabetList.IndexOf(letterF[i]);
            indexF[i] = index;
            sum = sum + index + 1;
        }
        string IK = otherword;
        int IDK123 = 0;
        for (int i = 0; i < 4; i++)
        {
            IDK123 = IDK123 + alphabetList.IndexOf(IK.Substring(0,1)) + 1;
            IK = IK.Remove(0,1);
        }
        extrawordsum = IDK123;
        ExtraText.text = extrawordsum.ToString();
        sum = sum % 26;
        answer = string.Concat(alphabet[(sum + indexF[0])%26], alphabet[(sum + indexF[1])% 26], alphabet[(sum + indexF[2])% 26], alphabet[(sum + indexF[3])% 26], alphabet[(sum + indexF[4])% 26], alphabet[(sum + indexF[5])% 26], alphabet[(sum + indexF[6])% 26], alphabet[(sum + indexF[7])% 26]);
        print(answer);
        answermorsecode = ConvertToMorseCode(answer);
        answerbinary = answermorsecode.Replace("-", "1").Replace(".", "0");
        realanswer = TransformA(answerbinary);
        Debug.LogFormat("[Pink Button't #{0}] Flashing sequence:", _moduleId);
        Debug.LogFormat("[Pink Button't #{0}] Text:{1}", _moduleId,string.Concat(wordColor[0],",", wordColor[1], ",", wordColor[2], ",", wordColor[3], ",", wordColor[4]));
        Debug.LogFormat("[Pink Button't #{0}] Color:{1}", _moduleId, string.Concat(colorColor[0], ",", colorColor[1], ",", colorColor[2], ",", colorColor[3], ",", colorColor[4]));
        Debug.LogFormat("[Pink Button't #{0}] Word code binary:{1}", _moduleId,wordcodebinary);
        Debug.LogFormat("[Pink Button't #{0}] Word code morse code:{1}", _moduleId, wordcodemorse);
        Debug.LogFormat("[Pink Button't #{0}] Word code:{1}", _moduleId, wordcode);
        Debug.LogFormat("[Pink Button't #{0}] Color code binary:{1}", _moduleId, colorcodebinary);
        Debug.LogFormat("[Pink Button't #{0}] Color code morse code:{1}", _moduleId, colorcodemorse);
        Debug.LogFormat("[Pink Button't #{0}] Color code:{1}", _moduleId, colorcode);
        Debug.LogFormat("[Pink Button't #{0}] Word code word and color code word:{1}", _moduleId, string.Concat(wordcodeword, ",", colorcodeword));
        Debug.LogFormat("[Pink Button't #{0}] Main letter:{1}", _moduleId, mainletter);
        Debug.LogFormat("[Pink Button't #{0}] Another word:{1}", _moduleId, otherword);
        Debug.LogFormat("[Pink Button't #{0}] Secondary letter:{1}", _moduleId, secondaryletter);
        Debug.LogFormat("[Pink Button't #{0}] Answer row:{1}", _moduleId, answer);
        Debug.LogFormat("[Pink Button't #{0}] Answer morse code:{1}", _moduleId, answermorsecode);
        Debug.LogFormat("[Pink Button't #{0}] Answer binary:{1}", _moduleId, answerbinary);
        Debug.LogFormat("[Pink Button't #{0}] Answer:{1}", _moduleId, realanswer);
        StartCoroutine(TextFlash());
    }


    private bool ButtonPress()
    {
        StartCoroutine(AnimateButton(0f, -0.05f));
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.BigButtonPress, transform);
        if (!_moduleSolved)
        {
            if (DisplayText.text == "YES")
            {
                input = "";
                print(input);
                isConfirming = true;
                _isLongPressing = false;
            }
            else if (DisplayText.text == "NO")
            {
                if (input == realanswer)
                {
                    Debug.LogFormat("[Pink Button't #{0}] SOLVE!!!", _moduleId);
                    GetComponent<KMBombModule>().HandlePass();
                    _moduleSolved = true;
                    ButtonText.text = "YES";
                }
                else
                {
                    Debug.LogFormat("[Pink Button't #{0}] STRIKE!!!", _moduleId);
                    GetComponent<KMBombModule>().HandleStrike();
                    input = "";
                }
                isConfirming = true;
                _isLongPressing = false;
            }
            else
            {
                isConfirming = false;
                _longPressStartTimeFloat = Time.time;
                _isLongPressing = true;
                _wasLongPress = false;
                _longPressCoroutine = StartCoroutine(LongPressHandler());
            }
        }
        return false;
    }

    private void ButtonRelease()
    {
        StartCoroutine(AnimateButton(-0.05f, 0f));
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.BigButtonRelease, transform);
        if (!_moduleSolved)
        {
            if (isConfirming)
                return;
            _isLongPressing = false;
            if (_wasLongPress && !isConfirming)
                return;
            int currentTime = (int)BombInfo.GetTime();
            if (!_isActiveSequence || currentTime - _lastPressTime > MASH_TIMEOUT)
            {
                StartNewMashSequence(currentTime);
            }
            _mashCount++;
            _lastPressTime = currentTime;
            ButtonText.text = "T" + _mashCount.ToString();
            if (_mashSequenceCoroutine != null)
                StopCoroutine(_mashSequenceCoroutine);
            _mashSequenceCoroutine = StartCoroutine(CheckMashCompletion());
        }
    }

    private IEnumerator LongPressHandler()
    {
        yield return new WaitForSeconds(LONG_PRESS_THRESHOLD);
        if (_isLongPressing && !isConfirming)
        {
            _isActiveSequence = false;
            _wasLongPress = true;
            while (_isLongPressing)
            {
                float holdTime = Time.time - _longPressStartTimeFloat;
                int holdSeconds = Mathf.FloorToInt(holdTime);
                ButtonText.text = "H" + holdSeconds.ToString();
                yield return new WaitForSeconds(0.1f);
            }
            int finalHold = Mathf.FloorToInt(Time.time - _longPressStartTimeFloat);
            input = string.Concat(input, "H", finalHold.ToString());
            print(input);
            ButtonText.text = ":)";
        }
    }

    private void StartNewMashSequence(int startTime)
    {
        _mashCount = 0;
        _currentSequenceStart = startTime;
        _isActiveSequence = true;
    }
    private IEnumerator CheckMashCompletion()
    {
        int initialTime = _lastPressTime;
        yield return new WaitForSeconds(MASH_TIMEOUT);

        if (_lastPressTime == initialTime && _isActiveSequence)
        {
            CompleteMashSequence();
        }
    }
    private void CompleteMashSequence()
    {
        _isActiveSequence = false;
        int duration = (int)BombInfo.GetTime() - _currentSequenceStart;
        ProcessMashResult(_mashCount, duration);
    }
    private void ProcessMashResult(int count, int duration)
    {
        input = string.Concat(input, "T", _mashCount.ToString());
        print(input);
        ButtonText.text = ":)";
    }
    private IEnumerator TextFlash()
    {
        while (!_moduleSolved)
        {
            for (int i = 0; i < wordColor.Length; i++)
            {
                DisplayText.text = wordColor[i];
                DisplayText.color = GetColor(colorColor[i]);
                float duration = 0.4f;
                float elapsed = 0f;
                Color startColor = DisplayText.color;
                Color endColor = Color.black;
                while (elapsed < duration)
                {
                    DisplayText.color = Color.Lerp(startColor, endColor, elapsed / duration);
                    elapsed += Time.deltaTime;
                    yield return null;
                }
                DisplayText.color = endColor;
                yield return new WaitForSeconds(0.1f); 
            }
            DisplayText.text = "NO";
            DisplayText.color = Color.white;
            float noDuration = 0.4f;
            float noElapsed = 0f;
            while (noElapsed < noDuration)
            {
                DisplayText.color = Color.Lerp(Color.white, Color.black, noElapsed / noDuration);
                noElapsed += Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);   
            DisplayText.text = "YES";
            DisplayText.color = Color.white;
            float yesDuration = 0.4f;
            float yesElapsed = 0f;
            while (yesElapsed < yesDuration)
            {
                DisplayText.color = Color.Lerp(Color.white, Color.black, yesElapsed / yesDuration);
                yesElapsed += Time.deltaTime;
                yield return null;
            }
            if (_moduleSolved)
            {
                DisplayText.color = Color.white;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    public static string TransformA(string input)
    {
        string result = "";
        int i = 0;
        int n = input.Length;
        while (i < n)
        {
            if (input[i] == '1')
            {
                int count = 1;
                while (i + count < n && input[i + count] == '1')
                {
                    count++;
                }
                if (count == 1)
                    result += "T"; 
                else
                    result += "H";
                i += count;
            }
            else if (input[i] == '0')
            {
                int count = 1;
                while (i + count < n && input[i + count] == '0')
                {
                    count++;
                }
                result += count.ToString(); 
                i += count;
            }
            else
            {
                result += input[i];
                i++;
            }
        }
        string finalResult = "";
        for (i = 0; i < result.Length; i++)
        {
            char current = result[i];
            if (char.IsDigit(current))
            {
                if (i == 0 || (!IsTH(result[i - 1]) && !char.IsDigit(result[i - 1])))
                {
                    finalResult += 'T';
                }
            }
            finalResult += current;
            if (IsTH(current))
            {
                if (i == result.Length - 1 || !char.IsDigit(result[i + 1]))
                {
                    finalResult += '1';
                }
            }
        }

        return finalResult;
    }

    private static bool IsTH(char c)
    {
        return c == 'T' || c == 'H';
    }

    public static string ConvertToMorseCode(string input)
    {
        input = input.ToUpper();
        var morseCode = new List<string>();

        foreach (char c in input)
        {
            string code;
            if (MorseCodeDictionary.TryGetValue(c, out code))
            {
                morseCode.Add(code);
            }
            else
            {
                morseCode.Add("?");
            }
        }

        return string.Join("", morseCode.ToArray());
    }

    public static Color GetColor(string colorName)
    {
        switch (colorName.ToUpper())
        {
            case "RED": return Color.red;
            case "GREEN": return Color.green;
            case "BLUE": return Color.blue;
            case "CYAN": return Color.cyan;
            case "MAGENTA": return Color.magenta;
            case "BLACK": return Color.gray;
            case "WHITE": return Color.white;
            case "YELLOW": return Color.yellow;
        }
        return Color.white;
    }

    public static string RGBword(string input,int determine,string[] list)
    {
        if (determine == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                string RGB = input.Substring(0, 3);
                if (RGB == "000")
                {
                    list[i] = "BLK";
                }
                if (RGB == "100")
                {
                    list[i] = "RED";
                }
                if (RGB == "010")
                {
                    list[i] = "GRN";
                }
                if (RGB == "001")
                {
                    list[i] = "BLU";
                }
                if (RGB == "110")
                {
                    list[i] = "YLW";
                }
                if (RGB == "101")
                {
                    list[i] = "MGT";
                }
                if (RGB == "011")
                {
                    list[i] = "CYN";
                }
                if (RGB == "111")
                {
                    list[i] = "WHT";
                }
                input = input.Remove(0, 3);
            }
        }
        if (determine == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                string RGB = input.Substring(0, 3);
                if (RGB == "000")
                {
                    list[i] = "black";
                }
                if (RGB == "100")
                {
                    list[i] = "red";
                }
                if (RGB == "010")
                {
                    list[i] = "green";
                }
                if (RGB == "001")
                {
                    list[i] = "blue";
                }
                if (RGB == "110")
                {
                    list[i] = "yellow";
                }
                if (RGB == "101")
                {
                    list[i] = "magenta";
                }
                if (RGB == "011")
                {
                    list[i] = "cyan";
                }
                if (RGB == "111")
                {
                    list[i] = "white";
                }
                input = input.Remove(0, 3);
            }
        }
        return string.Empty;
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

#pragma warning disable 0414
    public readonly string TwitchHelpMessage = @"!{0} press T1 H2 to tap the button once and hold the button for 2 seconds. !{0} submit to submit. !{0} erase to erase the input.";
#pragma warning restore 0414

    private IEnumerator ProcessTwitchCommand(string command)
    {
        print(command);
        string[] parameters = command.ToUpperInvariant().Split(new char[] { ' ' });
        if (parameters.Length < 1)
            yield break;
        string action = parameters[0];
        if (action == "SUBMIT")
        {
            while (DisplayText.text != "NO")
            {
                yield return null;
            }
            if (DisplayText.text == "NO")
            {
                ButtonSelectable.OnInteract();
                yield return new WaitForSeconds(0.1f);
                ButtonSelectable.OnInteractEnded();
            }
            yield break;
        }
        if (action == "ERASE")
        {
            while (DisplayText.text != "YES")
            {
                yield return null;
            }
            if (DisplayText.text == "YES")
            {
                ButtonSelectable.OnInteract();
                yield return new WaitForSeconds(0.1f);
                ButtonSelectable.OnInteractEnded(); 
            }
            yield break;
        }
        if (action != "PRESS" || parameters.Length < 2)
            yield break;
        List<string> list = new List<string>();
        for (int i = 1; i < parameters.Length; i++)
            list.Add(parameters[i]);
        foreach (string k in list)
        {
            if (k.Length < 2) yield break;
            string prefix = k.Substring(0, 1);
            if (prefix != "T" && prefix != "H")
                yield break;
        }
        foreach (string item in list)
        {
            if (item.Length < 2)
                continue;
            string prefix = item.Substring(0, 1);
            int count;
            if (!int.TryParse(item.Substring(1), out count))
                continue;
            if (prefix == "T")
            {
                for (int j = 0; j < count; j++)
                {
                    while (DisplayText.text == "YES" || DisplayText.text == "NO")
                        yield return null;
                    ButtonSelectable.OnInteract();
                    yield return new WaitForSeconds(0.1f);
                    ButtonSelectable.OnInteractEnded();
                    yield return new WaitForSeconds(0.5f);
                }
                while (ButtonText.text != ":)")
                    yield return null;
            }
            else if (prefix == "H")
            {
                while (DisplayText.text == "YES" || DisplayText.text == "NO" || ButtonText.text != ":)")
                    yield return null;
                ButtonSelectable.OnInteract();
                yield return new WaitForSeconds(0.2f);
                string af = "H" + count.ToString();
                yield return new WaitUntil(() => ButtonText.text == af);
                ButtonSelectable.OnInteractEnded();
                yield return new WaitUntil(() => ButtonText.text == ":)");
            }
        }
    }
    public IEnumerator TwitchHandleForcedSolve()
    {
        input = "";
        realanswer = "";
        while (DisplayText.text != "NO")
        {
            yield return null;
        }
        if (DisplayText.text == "NO")
        {
            ButtonSelectable.OnInteract();
            yield return new WaitForSeconds(0.1f);
            ButtonSelectable.OnInteractEnded();
        }
        yield return new WaitForSeconds(0.1f);
    }
}
