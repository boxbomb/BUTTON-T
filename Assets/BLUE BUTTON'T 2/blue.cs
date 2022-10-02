using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Rnd = UnityEngine.Random;

public class blue : MonoBehaviour
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

    public int select;

    public string A;
    public string B;
    public string C;
    public string D;
    public string E;
    public string F;
    public string G;
    public string H;
    public string I;
    public string J;
    public string K;
    public string L;
    public string M;
    public string N;
    public string O;
    public string P;
    public string Q;
    public string R;
    public string S;
    public string T;
    public string U;
    public string V;
    public string W;
    public string X;
    public string Y;
    public string Z;
    public int num;
    public string change;
    public string answer;
    public string input;
    public string lll;
    public int auto;
    public int lenth;
    public string autotext;
    private static readonly string[] alphabet = {"","A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z","" };
    private static readonly string[] alpha = { "APP", "BOB", "CAT", "DAD", "EAR", "FAT", "GET", "HOP", "ICE", "JET", "KEY", "LOT", "MET", "NOT", "OFF", "POT", "QIT", "RAT", "SON", "TOP", "UNO", "VET", "WET", "XIN", "YET", "ZIP" };
    private void Start()
    {
        _moduleId = _moduleIdCounter++;
        ButtonSelectable.OnInteract += ButtonPress;
        ButtonSelectable.OnInteractEnded += ButtonRelease;

        A = "AND";
        B = "BAT";
        C = "CUT";
        D = "DOT";
        E = "EGG";
        F = "FUN";
        G = "GEM";
        H = "HAT";
        I = "INK";
        J = "JAM";
        K = "KID";
        L = "LED";
        M = "MAT";
        N = "NOD";
        O = "OOF";
        P = "POP";
        Q = "QIY";
        R = "RAY";
        S = "SUR";
        T = "TAN";
        U = "UPS";
        V = "VEE";
        W = "WUT";
        X = "XYO";
        Y = "YOU";
        Z = "ZAP";
        select = Rnd.Range(1, 26);
        if(select == 1)
        {
            A = alpha[0];
            answer = "SDAPP";
        }
        else if(select == 2)
        {
            B = alpha[1];
            answer = "OTBOB";
        }
        else if (select == 3)
        {
            C = alpha[2];
            answer = "AMTAC";
        }
        else if (select == 4)
        {
            D = alpha[3];
            answer = "VQDAD";
        }
        else if (select == 5)
        {
            E = alpha[4];
            answer = "RCEAR";
        }
        else if (select == 6)
        {
            F = alpha[5];
            answer = "UHFAT";
        }
        else if (select == 7)
        {
            G = alpha[6];
            answer = "YQTEG";
        }
        else if (select == 8)
        {
            H = alpha[7];
            answer = "LDHOP";
        }
        else if (select == 9)
        {
            I = alpha[8];
            answer = "CPECI";
        }
        else if (select == 10)
        {
            J = alpha[9];
            answer = "TBTEJ";
        }
        else if (select == 11)
        {
            K = alpha[10];
            answer = "JGKEY";
        }
        else if (select == 12)
        {
            L = alpha[11];
            answer = "MNTOL";
        }
        else if (select == 13)
        {
            M = alpha[12];
            answer = "ABTEM";
        }
        else if (select == 14)
        {
            N = alpha[13];
            answer = "VSTON";
        }
        else if (select == 15)
        {
            O = alpha[14];
            answer = "TROFF";
        }
        else if (select == 16)
        {
            P = alpha[15];
            answer = "IFPOT";
        }
        else if (select == 17)
        {
            Q = alpha[16];
            answer = "HSQIT";
        }
        else if (select == 18)
        {
            R = alpha[17];
            answer = "NDRAT";
        }
        else if (select == 19)
        {
            S = alpha[18];
            answer = "DFNOS";
        }
        else if (select == 20)
        {
            T = alpha[19];
            answer = "NWTOP";
        }
        else if (select == 21)
        {
            U = alpha[20];
            answer = "ZXONU";
        }
        else if (select == 22)
        {
            V = alpha[21];
            answer = "NOVET";
        }
        else if (select == 23)
        {
            W = alpha[22];
            answer = "RXTEW";
        }
        else if (select == 24)
        {
            X = alpha[23];
            answer = "ZCXIN";
        }
        else if (select == 25)
        {
            Y = alpha[24];
            answer = "EVTEY";
        }
        else if (select == 26)
        {
            Z = alpha[25];
            answer = "SBPIZ";
        }
        Debug.LogFormat("[Blue Button't #{0}] Answer:{1}", _moduleId,answer);
        StartCoroutine(TextFlash());
    }
    private bool ButtonPress()
    {
        StartCoroutine(AnimateButton(0f, -0.05f));
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.BigButtonPress, transform);
        if (!_moduleSolved)
        {
            Debug.LogFormat("[Blue Button't #{0}] Held the button", _moduleId);
            if (num == 27)
            {
                if(input == answer)
                {
                    GetComponent<KMBombModule>().HandlePass();
                    _moduleSolved = true;
                    Debug.LogFormat("[Blue Button't #{0}] You did it!!!", _moduleId);
                }
                else
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    Debug.LogFormat("[Blue Button't #{0}] You didn't it!!!", _moduleId);
                    input = "";
                }
            }
            else
            {
                input = string.Concat(input, alphabet[num]);
                print(input);
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
            print("RELEASE");
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

    private IEnumerator TextFlash()
    {
        while (!_moduleSolved)
        {
            DisplayText.text = A;
            num = 1;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = B;
            num = 2;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = C;
            num = 3;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = D;
            num = 4;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = E;
            num = 5;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = F;
            num = 6;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = G;
            num = 7;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = H;
            num = 8;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = I;
            num = 9;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = J;
            num = 10;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = K;
            num = 11;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = L;
            num = 12;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = M;
            num = 13;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = N;
            num = 14;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = O;
            num = 15;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = P;
            num = 16;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = Q;
            num = 17;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = R;
            num = 18;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = S;
            num = 19;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = T;
            num = 20;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = U;
            num = 21;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = V;
            num = 22;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = W;
            num = 23;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = X;
            num = 24;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = Y;
            num = 25;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = Z;
            num = 26;
            ButtonText.text = num.ToString();
            yield return new WaitForSeconds(.5f);
            DisplayText.text = "";
            num = 27;
            ButtonText.text = "NO";
            yield return new WaitForSeconds(1f);
        }
    }
#pragma warning disable 0414
    public readonly string TwitchHelpMessage = @"!{0} 1 to press the button at XX:01.!{0} 27 submit to submit your answer.";
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
            if (!int.TryParse(parameters[i], out val) || val < 1 || val > 27)
                yield break;
            list.Add(val);
        }
        yield return null;
        for (int i = 0; i < list.Count; i++)
        {
            while (num != list[i])
                yield return "trycancel";
            ButtonSelectable.OnInteract();
            yield return new WaitForSeconds(0.1f);
            ButtonSelectable.OnInteractEnded();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator TwitchHandleForcedSolve()
    {
        yield break;
    }
}
