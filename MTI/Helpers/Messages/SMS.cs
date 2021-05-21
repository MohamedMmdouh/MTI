using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Web;

namespace MTI.Helpers.Messages
{
    public class SMS
    {
        public  bool SendSMS(string phoneNo, string message)
        {
            SerialPort sp = new SerialPort();
            sp.PortName=("COM5");
            sp.Open();
             sp.WriteLine("AT/r");
            sp.WriteLine("At+GMGF=1\r");
            Thread.Sleep(1500);
            //sp.WriteLine("At+CSCS=\"GSM\"" + Environment.NewLine);
            //Thread.Sleep(1000);
            sp.WriteLine("At+GMGS=\""+phoneNo +"\"\r\n" );
            Thread.Sleep(1500);

            sp.WriteLine(message + Environment.NewLine);
            Thread.Sleep(1500);
            var response = sp.ReadExisting();
            sp.Close();
            if (response.Contains("ERROR"))
            {
                return false;
            }
            return true;
        }

    }
}
/*
  System.IO.Ports.SerialPort port = new System.IO.Ports.SerialPort("COM13", 115200, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);

            SerialPort serial = new SerialPort();
            serial.PortName = "";



                port.Open();
                port.Write("AT\r\n");
                System.Threading.Thread.Sleep(1000);
                port.WriteLine("AT+CMGF=1\r\n");
                System.Threading.Thread.Sleep(1000);
                //port.WriteLine("AT+CMGS=\"+60121212121\"\r\n");
                port.WriteLine("AT+CMGS=\"" + phoneNo + "\"\r\n");
                System.Threading.Thread.Sleep(1000);
                //port.WriteLine("Testing SMS\r\n" + '\x001a');
                port.WriteLine(message + "\r\n" + '\x001a');
                port.Close();

     
     */
