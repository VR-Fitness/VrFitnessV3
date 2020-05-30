﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System;
using System.Threading;
using System.IO.Ports;
// must be .net 4 runtime

public class SerialConnection : MonoBehaviour
{
    private Thread connectionThread;
    private SerialPort serialPort;
    // check port name in bluetooth settings
    public String port = "COM9";


    public String lastReadMessage = "";

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("connectiong to comport...");
        serialPort = new SerialPort(port, 9600, Parity.None, 8, StopBits.One);
        if (!serialPort.IsOpen)
        {
            serialPort.Open();
        }

        connectionThread = new Thread(readFromComPort);


        connectionThread.Start();

        // make it a background threads that stops when main thread stops
        connectionThread.IsBackground = true;

    }

    // read from serial in seperate thread
    void readFromComPort()
    {
        
        serialPort.WriteLine("ready");
        while (true)
        {
            lastReadMessage = serialPort.ReadLine();
            //UnityEngine.Debug.Log("Puls: " + lastReadMessage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 2)
        {
            CatchIntArduinoCom();
            time = 0;
        }
       
    }

    void listPorts()
    {
        foreach (string s in getComPorts())
        {
            UnityEngine.Debug.Log(s);
        }
    }

    String[] getComPorts()
    {
        // Get a list of serial port names.
        string[] ports = SerialPort.GetPortNames();
        return ports;
    }

    private void OnDestroy()
    {
        connectionThread.Abort();
    }

    private void OnApplicationQuit()
    {
        connectionThread.Abort();
    }


    private void CatchIntArduinoCom()
    {
        try
        {
            int PulsCatch = int.Parse(lastReadMessage);
           PlayerStats.playerBPM = PulsCatch;
            UnityEngine.Debug.Log(PlayerStats.playerBPM);
        }

        catch (System.Exception ex)
        {
            UnityEngine.Debug.Log("err" + ex);
        }
    }
}
