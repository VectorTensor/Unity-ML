using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Utils;
using Utils.Services;

public class TextCSVTest
{
    private GameObject _gm;
    private TextAssetParser<float> _textAssetParser;
    private TextAssetParser<string> _textAssetParserStr;
    private IGetCSVService _csv;
    [UnitySetUp]
    public IEnumerator SettingUp()
    {

        SceneManager.LoadScene(0);
        yield return new EnterPlayMode();
        _gm = GameObject.FindWithTag("test");
        _csv = _gm.GetComponent<GetCSVService>();
        _textAssetParser = new TextAssetParser<float>();
        
        _textAssetParserStr = new TextAssetParser<string>();


    }
    [UnityTest]
    public IEnumerator TextCSVTestWithEnumeratorPasses()
    {
        yield return null;
        _textAssetParser.GetCSV(_csv);
        string[] x = _textAssetParser.TextString.Split("\n");
        Assert.AreEqual("6,148,72,35,0,33.6,0.627,50,1\r",x[0]);
    }

    [UnityTest] public IEnumerator TextCSVParserBasicTest()
    {
        yield return null;
        _textAssetParserStr.GetCSV(_csv);
        _textAssetParserStr.Parse(false,new string[]{"r","a","p","z","x","m","l","i","d",}); 
        Assert.AreEqual("6",_textAssetParserStr.Frame[0]["r"]);
        
    }
    
    
    
    [UnityTest]
    public IEnumerator TextCSVParserBasicIntTest()
    {
        yield return null;
        _textAssetParser.GetCSV(_csv);
        _textAssetParser.Parse(false,new string[]{"r","a","p","z","x","m","l","i","d",}); 
        Assert.AreEqual(6,_textAssetParser.Frame[0]["r"]);
        
    }
}
