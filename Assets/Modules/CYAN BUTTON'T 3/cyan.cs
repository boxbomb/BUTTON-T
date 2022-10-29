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

    public int N1;
    public int N2;
    public int N3;
    public int N4;
    public int N5;
    public int N6;
    public int rule;
    public int stop;
    public int cycles;
    public string stringa;

    public int answer;
    public int answerloop;

    private void Start()
    {
        _moduleId = _moduleIdCounter++;
        ButtonSelectable.OnInteract += ButtonPress;
        ButtonSelectable.OnInteractEnded += ButtonRelease;
        N1 = Rnd.Range(0, 10);
        N2 = Rnd.Range(0, 10);
        N3 = Rnd.Range(0, 10);
        N4 = Rnd.Range(0, 10);
        N5 = Rnd.Range(0, 10);
        N6 = Rnd.Range(0, 10);

        stringa = string.Concat(N1.ToString(), N2.ToString(), N3.ToString(), N4.ToString(), N5.ToString(), N6.ToString());
        rule = Rnd.Range(1, 7);
        ButtonText.text = rule.ToString();
        DisplayText.text = string.Concat(N1.ToString(), N2.ToString(), N3.ToString(), N4.ToString(), N5.ToString(), N6.ToString());
        Debug.LogFormat("[Cyan Button't #{0}] The starting number:{1}", _moduleId, string.Concat(N1.ToString(), N2.ToString(), N3.ToString(), N4.ToString(), N5.ToString(), N6.ToString()));
        StartCoroutine(calculat());
    }
    private bool ButtonPress()
    {
        StartCoroutine(AnimateButton(0f, -0.05f));
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.BigButtonPress, transform);
        if (!_moduleSolved)
        {   
            Debug.LogFormat("[Cyan Button't #{0}] Held the button", _moduleId);
            if(answerloop == 0)
            {
                answer += ((int)BombInfo.GetTime() % 10) * 100000;
                answerloop += 1;
                DisplayText.text = answer.ToString();
            }
            else if (answerloop == 1)
            {
                answer += ((int)BombInfo.GetTime() % 10) * 10000;
                answerloop += 1;
                DisplayText.text = answer.ToString();
            }
            else if (answerloop == 2)
            {
                answer += ((int)BombInfo.GetTime() % 10) * 1000;
                answerloop += 1;
                DisplayText.text = answer.ToString();
            }
            else if (answerloop == 3)
            {
                answer += ((int)BombInfo.GetTime() % 10) * 100;
                answerloop += 1;
                DisplayText.text = answer.ToString();
            }
            else if (answerloop == 4)
            {
                answer += ((int)BombInfo.GetTime() % 10) * 10;
                answerloop += 1;
                DisplayText.text = answer.ToString();
            }
            else if (answerloop == 5)
            {
                answer += ((int)BombInfo.GetTime() % 10) * 1;
                answerloop += 1;
                DisplayText.text = answer.ToString();
            }
            else if (answerloop == 6)
            {
                if(answer == N1*100000+ N2 * 10000 + N3 * 1000 + N4 * 100 + N5 * 10 + N6)
                {
                    print("nice");
                    GetComponent<KMBombModule>().HandlePass();
                    _moduleSolved = true;
                }
                else
                {
                    answer = 0;
                    answerloop = 0;
                    DisplayText.text = stringa;
                    GetComponent<KMBombModule>().HandleStrike();
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

    private IEnumerator calculat()
    {
        print("P");
        if(rule == 1)
        {
            if (N1 < 7)
            {
                N1 += 2;
                rule = 2;
            }
            else if (N3 < 4)
            {
                N1 += 1;
                rule = 4;
            }
            else if (N1 % 2 == 1)
            {
                N1 -= 1;
                rule = 6;
            }
            else if (N6 % 2 == 0)
            {
                N1 /= 2;
                rule = 5;
            }
            else
            {
                print("end");
                stop = 1;
            }
        }
        else if (rule == 2)
        {
            if (N2 < 8)
            {
                N2 += 3;
                rule = 4;
            }
            else if (N6 % 2 == 1)
            {
                N2 += 1;
                rule = 2;
            }
            else if (N5 % 2 == 0)
            {
                N2 -= 2;
                rule = 3;
            }
            else if (N3 % 2 == 0)
            {
                N2 /= 2;
                rule = 6;
            }
            else
            {
                print("end");
                stop = 1;
            }
        }
        else if (rule == 3)
        {
            if (N3 > 2)
            {
                N3 += 1;
                rule = 1;
            }
            else if (N1 % 2 == 0)
            {
                N3 /= 2;
                rule = 6;
            }
            else if (N6 == 0)
            {
                N3 += 9;
                rule = 1;
            }
            else if (N6 % 2 == 1)
            {
                N3 += 2;
                rule = 3;
            }
            else
            {
                print("end");
                stop = 1;
            }
        }
        else if (rule == 4)
        {
            if (N4 < 4)
            {
                N4 += 4;
                rule = 1;
            }
            else if (N3 % 2 == 1)
            {
                N4 += 2;
                rule = 6;
            }
            else if (N1 == 3)
            {
                N4 -= 3;
                rule = 1;
            }
            else if (N1 % 2 == 0)
            {
                N4 /= 2;
                rule = 2;
            }
            else
            {
                print("end");
                stop = 1;
            }
        }
        else if (rule == 5)
        {
            if (N6 > 8)
            {
                N5 -= 9;
                rule = 3;
            }
            else if (N3 < 5)
            {
                N5 += 2;
                rule = 5;
            }
            else if (N6 % 2 == 1)
            {
                N5 -= 2;
                rule = 1;
            }
            else if (N1 % 2 == 0)
            {
                N5 /= 2;
                rule = 6;
            }
            else
            {
                print("end");
                stop = 1;
            }
        }
        else if (rule == 6)
        {
            if (N1 % 2 == 0)
            {
                N6 += 2;
                rule = 1;
            }
            else if (N6 < 6)
            {
                N6 += 6;
                rule = 6;
            }
            else if (N1 % 2 == 1)
            {
                N6 -= 2;
                rule = 1;
            }
            else if (N5 % 2 == 1)
            {
                N6 += 1;
                rule = 4;
            }
            else
            {
                print("end");
                stop = 1;
            }
        }
        N1 = Math.Abs(N1 % 10);
        N2 = Math.Abs(N2 % 10);
        N3 = Math.Abs(N3 % 10);
        N4 = Math.Abs(N4 % 10);
        N5 = Math.Abs(N5 % 10);
        N6 = Math.Abs(N6 % 10);
        cycles += 1;
        Debug.LogFormat("[Cyan Button't #{0}] The number after operation:{1}", _moduleId,string.Concat(N1.ToString(), N2.ToString(), N3.ToString(), N4.ToString(), N5.ToString(), N6.ToString()));
        if(stop == 1 | cycles == 10)
        {
            print("REALLY?");
        }
        else
        {
            StartCoroutine(calculat());
        }
        yield return new WaitForSeconds(1f);
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
        answer = N1 * 100000 + N2 * 10000 + N3 * 1000 + N4 * 100 + N5 * 10 + N6;
        answerloop = 6;
        
        ButtonSelectable.OnInteract();
        yield return new WaitForSeconds(0.1f);
        ButtonSelectable.OnInteractEnded();
        yield return new WaitForSeconds(0.1f);
    }
}
