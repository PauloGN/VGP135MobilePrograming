using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] private TMP_Text _helloWord = null;

    // Start is called before the first frame update
    void Start()
    {
        _helloWord.text = "Hello World";
    }
}
