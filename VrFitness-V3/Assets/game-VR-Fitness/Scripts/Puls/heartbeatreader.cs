using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;

namespace Communicate_With_ESP32_via_Bluetooth_Serial
{
    class heartbeatreader : MonoBehaviour
    {
        SerialPort sp = new SerialPort("COM4", 2000000);
        void Start()
        {
            try
            {
                SerialPort port = new SerialPort();
                port.BaudRate = 9600;
                port.PortName = "COM10";
                port.Open();

                try
                {
                    port.Write("Hi, I am trying to talk to you.");
                    Debug.Log(port.ReadLine());

                    port.Write("Why do you have to repeat what I say?");
                    Debug.Log(port.ReadLine());
                    Debug.Log("888");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Encountered error while writing to / or reading from serial port");
                    Console.WriteLine(ex.ToString());
                    Debug.Log("err" + ex);
                }
            }
            finally
            { }
        }
   
        }
      
    }
    
     
   

