using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GUI : MonoBehaviour
{
    [SerializeField] private SphereSpawner _sphereSpawner;
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private TMP_Text _counter;


    public void DisplayCountOfSpheres(int count)
    {
        _counter.text = count.ToString();
    }
    public void Add()
    {
        int count = Convert.ToInt32(_input.text);
        
        _sphereSpawner.MultiSpawn(count);
    }
}
