using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
public class tercero : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("/dev/ttyUSB0", 115200);

   byte[] buffer = new byte[12];
   public float intervalo = 0.01f;
   public float qx, qy, qz, qw;
   public float time;
   void Start()
    {
        serialPort.NewLine = "\n";
        serialPort.Open();
    }
    
    void Update()
    {
        time += Time.deltaTime;

        if (time > intervalo)
        {
            time = time - intervalo;
            serialPort.Write("j\n");
            
        }
        if(serialPort.BytesToRead >= 12)
        {

            serialPort.Read(buffer,0,12);
            qx = BitConverter.ToSingle(buffer, 0);
            qy = BitConverter.ToSingle(buffer, 4);
            qz = BitConverter.ToSingle(buffer, 8);
            qz = BitConverter.ToSingle(buffer, 12 );                                          
            transform.rotation = new Quaternion(-qy, qz, qx, qw);
        }
        Debug.Log(qx);
    }
}