using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Rnd = UnityEngine.Random;

public class green : MonoBehaviour
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

    private static readonly string[] flash = { "", "", "", "", "", "", "", "", "", "", "", };
    public string color1;
    public string color2;
    public string color3;
    public string color4;
    public string color5;
    public string color6;
    public string color7;
    public string color8;
    public string color9;
    public string color10;

    public int S1;
    public int S2;
    public int S3;
    public int S4;
    public int S5;
    public int S6;
    public int S7;
    public int S8;
    public int S9;
    public int S10;

    public string D1;
    public string D2;
    public string D3;
    public string D4;
    public string D5;
    public string D6;
    public string D7;
    public string D8;
    public string D9;
    public string D10;

    public int stage;

    public int gen;

    public string auto;
    public int autolen;
    public int proceed;
    public string sub;

    string[] colors = { "RED", "WINE", "ROCK RED", "ROSE RED", "LIME", "GREEN", "TEAL", "HARLEQUIN", "BLUE", "NAVY", "DENIM", "BLUEBERRY", "YELLOW", "GOLD", "LEMON", "DOLLY", "CYAN", "TUNA", "AZURE", "AQUA", "MAGENTA", "PINK", "VIOLET", "FUCHSIA", "WHITE", "CERAMIC", "SNOW", "GREY", "BLACK", "NIGHTMARE", "DEEP DARK", "DEEP BLACK" };
    private void Start()
    {
        _moduleId = _moduleIdCounter++;
        ButtonSelectable.OnInteract += ButtonPress;
        ButtonSelectable.OnInteractEnded += ButtonRelease;
        color1 = colors[Rnd.Range(0, colors.Length)];
        color2 = colors[Rnd.Range(0, colors.Length)];
        color3 = colors[Rnd.Range(0, colors.Length)];
        color4 = colors[Rnd.Range(0, colors.Length)];
        color5 = colors[Rnd.Range(0, colors.Length)];
        color6 = colors[Rnd.Range(0, colors.Length)];
        color7 = colors[Rnd.Range(0, colors.Length)];
        color8 = colors[Rnd.Range(0, colors.Length)];
        color9 = colors[Rnd.Range(0, colors.Length)];
        color10 = colors[Rnd.Range(0, colors.Length)];
        flash[1] = color1;
        flash[2] = color2;
        flash[3] = color3;
        flash[4] = color4;
        flash[5] = color5;
        flash[6] = color6;
        flash[7] = color7;
        flash[8] = color8;
        flash[9] = color9;
        flash[10] = color10;
        S1 = 0;
        S2 = 0;
        S3 = 0;
        S4 = 0;
        S5 = 0;
        S6 = 0;
        S7 = 0;
        S8 = 0;
        S9 = 0;
        S10 = 0;

        D1 = "0";
        D2 = "0";
        D3 = "0";
        D4 = "0";
        D5 = "0";
        D6 = "0";
        D7 = "0";
        D8 = "0";
        D9 = "0";
        D10 = "0";

        gen = 10;
        
        while (gen >= 1)
        {
            if (flash[gen] == "RED")
            {
                if (gen % 2 == 0)
                {
                    S7 += 1;
                    S8 += 1;
                    S9 += 1;
                }
                else
                {
                    S2 += 1;
                    S3 += 1;
                    S4 += 1;
                }
            }
            else if (flash[gen] == "WINE") 
            {
                if (gen % 2 == 0)
                {
                    S7 += 1;
                    S8 += 1;
                    S10 += 1;
                }
                else
                {
                    S2 += 1;
                    S3 += 1;
                    S5 += 1;
                }
            }
            else if (flash[gen] == "ROCK RED")
            {
                if (gen % 2 == 0)
                {
                    S7 += 1;
                    S8 += 1;
                }
                else
                {
                    S2 += 1;
                    S3 += 1;
                }
            }
            else if (flash[gen] == "ROSE RED")
            {
                if (gen % 2 == 0)
                {
                    S7 += 1;
                    S8 += 1;
                    S9 += 1;
                    S10 += 1;
                }
                else
                {
                    S2 += 1;
                    S3 += 1;
                    S4 += 1;
                    S5 += 1;
                }
            }
            else if (flash[gen] == "LIME")
            {
                if (gen % 2 == 0)
                {
                    S6 += 1;
                    S8 += 1;
                    S9 += 1;
                }
                else
                {
                    S1 += 1;
                    S3 += 1;
                    S4 += 1;
                }
            }
            else if (flash[gen] == "GREEN")
            {
                if (gen % 2 == 0)
                {
                    S6 += 1;
                    S8 += 1;
                    S10 += 1;
                }
                else
                {
                    S1 += 1;
                    S3 += 1;
                    S5 += 1;
                }
            }
            else if (flash[gen] == "TEAL")
            {
                if (gen % 2 == 0)
                {
                    S6 += 1;
                    S8 += 1;
                }
                else
                {
                    S1 += 1;
                    S3 += 1;
                }
            }
            else if (flash[gen] == "HARLEQUIN")
            {
                if (gen % 2 == 0)
                {
                    S6 += 1;
                    S8 += 1;
                    S9 += 1;
                    S10 += 1;
                }
                else
                {
                    S1 += 1;
                    S3 += 1;
                    S4 += 1;
                    S5 += 1;
                }
            }
            else if (flash[gen] == "BLUE")
            {
                if (gen % 2 == 0)
                {
                    S7 += 1;
                    S6 += 1;
                    S9 += 1;
                }
                else
                {
                    S2 += 1;
                    S1 += 1;
                    S4 += 1;
                }
            }
            else if (flash[gen] == "NAVY")
            {
                if (gen % 2 == 0)
                {
                    S7 += 1;
                    S6 += 1;
                    S10 += 1;
                }
                else
                {
                    S2 += 1;
                    S1 += 1;
                    S5 += 1;
                }
            }
            else if (flash[gen] == "DENIM")
            {
                if (gen % 2 == 0)
                {
                    S7 += 1;
                    S6 += 1;
                }
                else
                {
                    S2 += 1;
                    S1 += 1;
                }
            }
            else if (flash[gen] == "BLUEBERRY")
            {
                if (gen % 2 == 0)
                {
                    S7 += 1;
                    S6 += 1;
                    S9 += 1;
                    S10 += 1;
                }
                else
                {
                    S2 += 1;
                    S1 += 1;
                    S4 += 1;
                    S5 += 1;
                }
            }
            else if (flash[gen] == "YELLOW")
            {
                if (gen % 2 == 0)
                {
                    S8 += 1;
                    S9 += 1;
                }
                else
                {
                    S3 += 1;
                    S4 += 1;
                }
            }
            else if (flash[gen] == "GOLD")
            {
                if (gen % 2 == 0)
                {
                    S8 += 1;
                    S10 += 1;
                }
                else
                {
                    S3 += 1;
                    S5 += 1;
                }
            }
            else if (flash[gen] == "LEMON")
            {
                if (gen % 2 == 0)
                {
                    S8 += 1;
                }
                else
                {
                    S3 += 1;
                }
            }
            else if (flash[gen] == "DOLLY")
            {
                if (gen % 2 == 0)
                {
                    S8 += 1;
                    S9 += 1;
                    S10 += 1;
                }
                else
                {
                    S3 += 1;
                    S4 += 1;
                    S5 += 1;
                }
            }
            else if (flash[gen] == "CYAN")
            {
                if (gen % 2 == 0)
                {
                    S6 += 1;
                    S9 += 1;
                }
                else
                {
                    S1 += 1;
                    S4 += 1;
                }
            }
            else if (flash[gen] == "TUNA")
            {
                if (gen % 2 == 0)
                {
                    S6 += 1;
                    S10 += 1;
                }
                else
                {
                    S1 += 1;
                    S5 += 1;
                }
            }
            else if (flash[gen] == "AZURE")
            {
                if (gen % 2 == 0)
                {
                    S6 += 1;
                }
                else
                {
                    S1 += 1;
                }
            }
            else if (flash[gen] == "AQUA")
            {
                if (gen % 2 == 0)
                {
                    S6 += 1;
                    S9 += 1;
                    S10 += 1;
                }
                else
                {
                    S1 += 1;
                    S4 += 1;
                    S5 += 1;
                }
            }
            else if (flash[gen] == "MAGENTA")
            {
                if (gen % 2 == 0)
                {
                    S7 += 1;
                    S9 += 1;
                }
                else
                {
                    S2 += 1;
                    S4 += 1;
                }
            }
            else if (flash[gen] == "PINK")
            {
                if (gen % 2 == 0)
                {
                    S7 += 1;
                    S10 += 1;
                }
                else
                {
                    S2 += 1;
                    S5 += 1;
                }
            }
            else if (flash[gen] == "VIOLET")
            {
                if (gen % 2 == 0)
                {
                    S7 += 1;
                }
                else
                {
                    S2 += 1;
                }
            }
            else if (flash[gen] == "FUCHSIA")
            {
                if (gen % 2 == 0)
                {
                    S7 += 1;
                    S9 += 1;
                    S10 += 1;
                }
                else
                {
                    S2 += 1;
                    S4 += 1;
                    S5 += 1;
                }
            }
            else if (flash[gen] == "WHITE")
            {
                if (gen % 2 == 0)
                {
                    S9 += 1;
                }
                else
                {
                    S4 += 1;
                }
            }
            else if (flash[gen] == "CERAMIC")
            {
                if (gen % 2 == 0)
                {
                    S10 += 1;
                }
                else
                {
                    S5 += 1;
                }
            }
            else if (flash[gen] == "SNOW")
            {
                if (gen % 2 == 0)
                {
               
                }
                else
                {
                    
                }
            }
            else if (flash[gen] == "GREY")
            {
                if (gen % 2 == 0)
                {
                    S9 += 1;
                    S10 += 1;
                }
                else
                {
                    S4 += 1;
                    S5 += 1;
                }
            }
            else if (flash[gen] == "BLACK")
            {
                if (gen % 2 == 0)
                {
                    S6 += 1;
                    S7 += 1;
                    S8 += 1;
                    S9 += 1;
                }
                else
                {
                    S1 += 1;
                    S2 += 1;
                    S3 += 1;
                    S4 += 1;
                }
            }
            else if (flash[gen] == "NIGHTMARE")
            {
                if (gen % 2 == 0)
                {
                    S6 += 1;
                    S7 += 1;
                    S8 += 1;
                    S10 += 1;
                }
                else
                {
                    S1 += 1;
                    S2 += 1;
                    S3 += 1;
                    S5 += 1;
                }
            }
            else if (flash[gen] == "DEEP DARK")
            {
                if (gen % 2 == 0)
                {
                    S6 += 1;
                    S7 += 1;
                    S8 += 1;
                }
                else
                {
                    S1 += 1;
                    S2 += 1;
                    S3 += 1;
                }
            }
            else if (flash[gen] == "DEEP BLACK")
            {
                if (gen % 2 == 0)
                {
                    S6 += 1;
                    S7 += 1;
                    S8 += 1;
                    S9 += 1;
                    S10 += 1;
                }
                else
                {
                    S1 += 1;
                    S2 += 1;
                    S3 += 1;
                    S4 += 1;
                    S5 += 1;
                }
            }
            else
            {
                print("ERR!!!");
            }
            gen -= 1;
            print("HI");
        }
        S1 = S1 % 2;
        S2 = S2 % 2;
        S3 = S3 % 2;
        S4 = S4 % 2;
        S5 = S5 % 2;
        S6 = S6 % 2;
        S7 = S7 % 2;
        S8 = S8 % 2;
        S9 = S9 % 2;
        S10 = S10 % 2;

        Debug.LogFormat("[Green Button't #{0}] Color Sequence: {1}", _moduleId, string.Concat(color1, ",", color2, ",", color3, ",", color4, ",", color5, ",", color6, ",", color7, ",", color8, ",", color9, ",", color10));
        Debug.LogFormat("[Green Button't #{0}] Correct Answer: {1}", _moduleId, string.Concat(S1.ToString(), S2.ToString(), S3.ToString(), S4.ToString(), S5.ToString(), S6.ToString(), S7.ToString(), S8.ToString(), S9.ToString(), S10.ToString()));
        auto = string.Concat(S1.ToString(), S2.ToString(), S3.ToString(), S4.ToString(), S5.ToString(), S6.ToString(), S7.ToString(), S8.ToString(), S9.ToString(), S10.ToString());
        StartCoroutine(TextFlash());
    }

    private bool ButtonPress()
    {
        StartCoroutine(AnimateButton(0f, -0.05f));
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.BigButtonPress, transform);
        if (!_moduleSolved)
        {
            Debug.LogFormat("[Green Button't #{0}] Held the button", _moduleId);
            if(stage == 1)
            {
                if(D1 == "0")
                {
                    D1 = "1";
                }
                else
                {
                    D1 = "0";
                }
            }
            else if (stage == 2)
            {
                if (D2 == "0")
                {
                    D2 = "1";
                }
                else
                {
                    D2 = "0";
                }
            }
            else if (stage == 3)
            {
                if (D3 == "0")
                {
                    D3 = "1";
                }
                else
                {
                    D3 = "0";
                }
            }
            else if (stage == 4)
            {
                if (D4 == "0")
                {
                    D4 = "1";
                }
                else
                {
                    D4 = "0";
                }
            }
            else if (stage == 5)
            {
                if (D5 == "0")
                {
                    D5 = "1";
                }
                else
                {
                    D5 = "0";
                }
            }
            else if (stage == 6)
            {
                if (D6 == "0")
                {
                    D6 = "1";
                }
                else
                {
                    D6 = "0";
                }
            }
            else if (stage == 7)
            {
                if (D7 == "0")
                {
                    D7 = "1";
                }
                else
                {
                    D7 = "0";
                }
            }
            else if (stage == 8)
            {
                if (D8 == "0")
                {
                    D8 = "1";
                }
                else
                {
                    D8 = "0";
                }
            }
            else if (stage == 9)
            {
                if (D9 == "0")
                {
                    D9 = "1";
                }
                else
                {
                    D9 = "0";
                }
            }
            else if (stage == 10)
            {
                if (D10 == "0")
                {
                    D10 = "1";
                }
                else
                {
                    D10 = "0";
                }
            }
            else if (stage == 11)
            {
                if(D1 == S1.ToString()& D2 == S2.ToString() & D3 == S3.ToString() & D4 == S4.ToString() & D5 == S5.ToString() & D6 == S6.ToString() & D7 == S7.ToString() & D8 == S8.ToString() & D9 == S9.ToString() & D10 == S10.ToString())
                {
                    GetComponent<KMBombModule>().HandlePass();
                    _moduleSolved = true;
                    Debug.LogFormat("[Green Button't #{0}] SOLVE!!!", _moduleId);
                }
                else
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    Debug.LogFormat("[Green Button't #{0}] STRIKE!!!", _moduleId);
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

    private IEnumerator FlyEgg()
    {
        var duration = 2f;
        var elapsed = 0f;
        while (elapsed < duration)
        {
            MO.transform.localEulerAngles = new Vector3(0f, 0f, Easing.OutQuad(elapsed, 0f, 360f, duration));
            yield return null;
            elapsed += Time.deltaTime;
        }
    }
    private IEnumerator TextFlash()
    {
        while (!_moduleSolved)
        {
            for (int i = 0; i < flash.Length; i++)
            {
                DisplayText.text = color1;
                ButtonText.text = D1;
                stage = 1;
                yield return new WaitForSeconds(.5f);
                DisplayText.text = color2;
                ButtonText.text = D2;
                stage = 2;
                yield return new WaitForSeconds(.5f);
                DisplayText.text = color3;
                ButtonText.text = D3;
                stage = 3;
                yield return new WaitForSeconds(.5f);
                DisplayText.text = color4;
                ButtonText.text = D4;
                stage = 4;
                yield return new WaitForSeconds(.5f);
                DisplayText.text = color5;
                ButtonText.text = D5;
                stage = 5;
                yield return new WaitForSeconds(.5f);
                DisplayText.text = color6;
                ButtonText.text = D6;
                stage = 6;
                yield return new WaitForSeconds(.5f);
                DisplayText.text = color7;
                ButtonText.text = D7;
                stage = 7;
                yield return new WaitForSeconds(.5f);
                DisplayText.text = color8;
                ButtonText.text = D8;
                stage = 8;
                yield return new WaitForSeconds(.5f);
                DisplayText.text = color9;
                ButtonText.text = D9;
                stage = 9;
                yield return new WaitForSeconds(.5f);
                DisplayText.text = color10;
                ButtonText.text = D10;
                stage = 10;
                yield return new WaitForSeconds(.5f);
                DisplayText.text = "";
                ButtonText.text = "NO";
                stage = 11;
                yield return new WaitForSeconds(.75f);
            }
        }
    }
#pragma warning disable 0414
    public readonly string TwitchHelpMessage = @"!{0} press 1 to press the button at the first color. !{0} press 11 to submit your answer.";
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
            if (!int.TryParse(parameters[i], out val) || val < 1 || val > 11)
                yield break;
            list.Add(val);
        }
        yield return null;
        for (int i = 0; i < list.Count; i++)
        {
            while (stage != list[i])
                yield return "trycancel";
            ButtonSelectable.OnInteract();
            yield return new WaitForSeconds(0.1f);
            ButtonSelectable.OnInteractEnded();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator TwitchHandleForcedSolve()
    {
        autolen = auto.Length;
        proceed = 1;
        while (proceed < autolen)
        {
            sub = auto.Substring(0, 1);
            if (sub == "1")
            {
                while (stage != proceed)
                    yield return true;
                ButtonSelectable.OnInteract();
                ButtonSelectable.OnInteractEnded();
                yield return new WaitForSeconds(.1f);
            }
            proceed += 1;
            auto = auto.Remove(0, 1);
        }
        
        while (stage != 11)
            yield return true;
        ButtonSelectable.OnInteract();
        ButtonSelectable.OnInteractEnded();
        yield return new WaitForSeconds(.1f);
    }
}
