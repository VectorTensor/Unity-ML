using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Utils;
using Utils.Services;

public class IndexerTest
{
    private IIndexerService<float> _indexer;

    private List<Dictionary<string, float>> data = new List<Dictionary<string, float>>()
    {
        new Dictionary<string, float>()
        {
            {"a",1.2f},
            {"b",2.5f}
        },
         new Dictionary<string, float>()
                {
                    {"a",12.2f},
                    {"b",21.5f}
                }
    };

    public TextAssetParser<float> textAsset;

[UnitySetUp]
    public IEnumerator Setup()
    {
        
        SceneManager.LoadScene(0);
        yield return new EnterPlayMode();
        _indexer = new IndexerService<float>(data);
        var x = GameObject.FindWithTag("test").GetComponent<GetCSVService>();
        textAsset = new TextAssetParser<float>(x,false,new string[]{"r","a","p",});

    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator IndexerTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
        var x = _indexer.GetRequiredDataFromColumns(new string[]{"a"});
        Assert.AreEqual(new float[,]{{1.2f},{12.2f}},x);
        var y = _indexer.GetRequiredDataFromColumns(new string[]{"b"});
        Assert.AreEqual(new float[,]{{2.5f},{21.5f}},y);
        
    }
    
    [UnityTest]
    public IEnumerator IndexerTestWithEnumeratorPassesWithCSV()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
        var x = textAsset[new string[] { "r" ,"a"}];
        // Assert.AreEqual(
        //     new float[,]
        //     {
        //         
        //         {1,2,},
        //         {3,4,},
        //         {5,6,}
        //     },x
        //     );

    }
    [UnityTest]
    public IEnumerator IndexerTestWithEnumeratorPassesWithCSVNumber()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
        var x = textAsset[0,3,1];
        Assert.AreEqual(
            new float[,]
            {
                
                {1,2,6},
                {3,4,6},
                {5,6,12}
            },x.GetValues()
            );

        
    }
    [UnityTest]
    public IEnumerator IndexerTestWithEnumeratorPassesWithCSVList()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
        var x = textAsset[new []{1,3,2 }];
        Assert.AreEqual(
            new float[,]
            {
                
                {3,4,6},
                {4,6,12},
                {5,6,12}
            },x.GetValues()
            );

        
    }
}
