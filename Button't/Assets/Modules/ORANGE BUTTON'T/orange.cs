using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Rnd = UnityEngine.Random;

public class orange : MonoBehaviour
{
    public KMBombModule Module;
    public KMBombInfo BombInfo;
    public KMAudio Audio;
    public KMSelectable ButtonSelectable;
    public GameObject ButtonCap;

    private static int _moduleIdCounter = 1;
    private int _moduleId;
    private bool _moduleSolved;

    public TextMesh ButtonText;
    public TextMesh DisplayText1;
    public TextMesh DisplayText2;
    public int stage;
    public int N1;
    public int N2;
    public int N3;
    public int N4;
    public int N5;
    public int N6;
    public int N7;
    public int N8;
    public int N9;
    public int N10;
    public int A;
    public string At;
    public string Tablefiller;
    public int LenthofN;
    public int NUMA;
    public int W;
    public int V;
    private static readonly string[,] Table = {
        {"","","","","","","",""},
     };

    public int T;
    public int B;
    public int TAKE;
    public int HOLD;
    public int RELEASE;
    public double snum;
    public string debugt;
    public bool holdnow;

    private void Start()
    {
        _moduleId = _moduleIdCounter++;
        ButtonSelectable.OnInteract += ButtonPress;
        ButtonSelectable.OnInteractEnded += ButtonRelease;
        stage = 1;
        N1 = Rnd.Range(0, 100);
        N2 = Rnd.Range(0, 100);
        N3 = Rnd.Range(0, 100);
        N4 = Rnd.Range(0, 100);
        N5 = Rnd.Range(0, 100);
        N6 = Rnd.Range(0, 100);
        N7 = Rnd.Range(0, 100);
        N8 = Rnd.Range(0, 100);
        N9 = Rnd.Range(0, 100);
        N10 = Rnd.Range(0, 100);
        T = Rnd.Range(10, 100);
        B = Rnd.Range(10, 100);
        DisplayText1.text = string.Concat(N1.ToString(), ",", N2.ToString(), ",", N3.ToString(), ",", N4.ToString(), ",", N5.ToString());
        DisplayText2.text = string.Concat(N6.ToString(), ",", N7.ToString(), ",", N8.ToString(), ",", N9.ToString(), ",", N10.ToString());

        if (N1 < 10)
        {
            TAKE = N2;
        }
        else if (N1 + N10 > 150)
        {
            TAKE = N1;
        }
        else if (N1 > 90 & N2 > 90 & N3 > 90 & N4 > 90 & N5 > 90 & N6 > 90 & N7 > 90 & N8 > 90 & N9 > 90 & N10 > 90)
        {
            TAKE = N3;
        }
        else if (N4 == N5)
        {
            TAKE = N10;
        }
        else if (N7 < 10 & N8 < 10)
        {
            TAKE = N7;
        }
        else if (N5 * N6 > 9000)
        {
            TAKE = N6;
        }
        else if (N5 > 50)
        {
            TAKE = N5;
        }
        else if (N5 == N6)
        {
            TAKE = N8;
        }
        else if (N10 < 25)
        {
            TAKE = N4;
        }
        else if (N9 > 49) 
        {
            TAKE = N9;
        }
        else
        {
            snum = (N1 + N2 + N3 + N4 + N5 + N6 + N7 + N8 + N9 + N10) / 10;
            snum = Math.Floor(snum);
            TAKE = (int)snum;
        }
        HOLD = TAKE % 10;
        debugt = HOLD.ToString();
        print(HOLD.ToString());
        A = (N1 + N2 + N3) * (N4 + N5 + N6) * (N7 + N8 + N9) + N10;
        At = A.ToString();
        LenthofN = At.Length;
        V = At.Length;
        NUMA = 0;
        while (LenthofN > 0)
        {
            Tablefiller = At.Substring(0, 1);
            Table[0, NUMA] = Tablefiller;
            At = At.Remove(0, 1);
            NUMA += 1;
            LenthofN -= 1;
        }

        W = (Math.Abs(T - B) + 1) % V;
        RELEASE = Convert.ToInt32(Table[0, W]);
        Debug.LogFormat("[Orange Button't #{0}] You should tap the button at {1}", _moduleId, string.Concat(debugt, "&", RELEASE.ToString()));
    }

    private bool ButtonPress()
    {
        StartCoroutine(AnimateButton(0f, -0.05f));
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.BigButtonPress, transform);
        if (!_moduleSolved)
        {
            Debug.LogFormat("[Orange Button't #{0}] Held the button", _moduleId);
            holdnow = true;
            if (stage == 1)
            {
                if ((int)BombInfo.GetTime() % 10 == HOLD)
                {
                    DisplayText1.text = T.ToString();
                    DisplayText2.text = B.ToString();
                    stage = 2;
                    Debug.LogFormat("[Orange Button't #{0}] Enter step 2", _moduleId);
                }
                else
                {
                    DisplayText1.text = string.Concat(N1.ToString(), ",", N2.ToString(), ",", N3.ToString(), ",", N4.ToString(), ",", N5.ToString());
                    DisplayText2.text = string.Concat(N6.ToString(), ",", N7.ToString(), ",", N8.ToString(), ",", N9.ToString(), ",", N10.ToString());
                    GetComponent<KMBombModule>().HandleStrike();
                    Debug.LogFormat("[Orange Button't #{0}] Strike!!!", _moduleId);
                }
            }
            else if(stage == 2)
            {
                if ((int)BombInfo.GetTime() % 10 == RELEASE)
                {
                    DisplayText1.text = "G";
                    DisplayText2.text = "G";
                    stage = 3;
                    GetComponent<KMBombModule>().HandlePass();
                    _moduleSolved = true;
                    Debug.LogFormat("[Orange Button't #{0}] Solve!!!", _moduleId);
                }
                else
                {
                    DisplayText1.text = string.Concat(N1.ToString(), ",", N2.ToString(), ",", N3.ToString(), ",", N4.ToString(), ",", N5.ToString());
                    DisplayText2.text = string.Concat(N6.ToString(), ",", N7.ToString(), ",", N8.ToString(), ",", N9.ToString(), ",", N10.ToString());
                    GetComponent<KMBombModule>().HandleStrike();
                    stage = 1;
                    Debug.LogFormat("[Orange Button't #{0}] Strike!!!", _moduleId);
                }
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
   

#pragma warning disable 0414
    public readonly string TwitchHelpMessage = @"!{0} press # # to press the button at step 1 and step 2.";
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
            if (!int.TryParse(parameters[i], out val) || val < 0 || val > 9)
                yield break;
            list.Add(val);
        }
        yield return null;
        for (int i = 0; i < list.Count; i++)
        {
            while ((int)BombInfo.GetTime() % 10 != list[i])
                yield return "trycancel";
            ButtonSelectable.OnInteract();
            yield return new WaitForSeconds(0.1f);
            ButtonSelectable.OnInteractEnded();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator TwitchHandleForcedSolve()
    {
        while ((int)BombInfo.GetTime() % 10 != HOLD)
            yield return true;
        ButtonSelectable.OnInteract();
        yield return new WaitForSeconds(0.1f);
        ButtonSelectable.OnInteractEnded(); ;
        yield return new WaitForSeconds(0.1f);
        while ((int)BombInfo.GetTime() % 10 != RELEASE)
            yield return true;
        ButtonSelectable.OnInteract();
        yield return new WaitForSeconds(0.1f);
        ButtonSelectable.OnInteractEnded(); ;
    }
}
