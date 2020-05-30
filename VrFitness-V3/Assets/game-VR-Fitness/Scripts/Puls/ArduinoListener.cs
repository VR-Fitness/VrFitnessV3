using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class ArduinoListener : MonoBehaviour
{
    private Thread connectionThread;
    private SerialPort serialPort;
    // check port name in bluetooth settings
    public string port = "COM10";

    public string pulsEsp32Incoming = "";


    [SerializeField]
    private int PulsCatch;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("connectiong to comport...");
        serialPort = new SerialPort(port, 19200, Parity.None, 8, StopBits.One);
        if (!serialPort.IsOpen)
        {
            serialPort.Open();
        }

        connectionThread = new Thread(readFromComPort);


        connectionThread.Start();

        // make it a background threads that stops when main thread stops
        connectionThread.IsBackground = true;
    }

    // Update is called once per frame
    void Update()
    {
        CatchIntArduinoCom();
    }

    private void CatchIntArduinoCom()
    {
        try
        {
            PulsCatch = int.Parse(pulsEsp32Incoming);
            Debug.Log(PulsCatch);
            PlayerStats.playerBPM = PulsCatch;        
        }
      
        catch (System.Exception ex)
        {
            Debug.Log("err" + ex);
        }
    }


    void readFromComPort()
    {
        serialPort.WriteLine("ready");
        while (true)
        {
            pulsEsp32Incoming = serialPort.ReadLine();
            UnityEngine.Debug.Log("Received this: " + pulsEsp32Incoming);
        }
    }

    private void OnDestroy()
    {
        connectionThread.Abort();
    }

    private void OnApplicationQuit()
    {
        connectionThread.Abort();
    }


    void listPorts()
    {
        foreach (string s in getComPorts())
        {
            UnityEngine.Debug.Log(s);
        }
    }

    string[] getComPorts()
    {
        // Get a list of serial port names.
        string[] ports = SerialPort.GetPortNames();
        return ports;
    }


}
 
