using System;
using System.IO.Ports;

public static class FingerprintHelper
{
    private static SerialPort _serialPort;

    static FingerprintHelper()
    {
        _serialPort = new SerialPort("COM3", 115200); // Ensure baud rate matches Arduino
        _serialPort.Open();
        _serialPort.DiscardInBuffer(); // Clear any old data
    }

    public static void RequestFingerprint()
    {
        if (_serialPort.IsOpen)
        {
            Console.WriteLine("Requesting fingerprint...");
            _serialPort.WriteLine("GET_TEMPLATE"); // Send command to Arduino
        }
    }

    public static void ReceiveFingerprint()
    {
        if (_serialPort.IsOpen)
        {
            Console.WriteLine("Waiting for fingerprint data...");

            string header = _serialPort.ReadLine(); // Read first line
            if (header == "FINGERPRINT_TEMPLATE")
            {
                byte[] fingerprintData = new byte[512]; // Fingerprint template size
                _serialPort.Read(fingerprintData, 0, fingerprintData.Length);

                Console.WriteLine("✅ Fingerprint received! Data:");
                Console.WriteLine(BitConverter.ToString(fingerprintData)); // Print in hex format

                // Now tell Arduino that we're sending a response
                PrepareArduinoForResponse();

                // Send the match result
                SendMatchResult(true); // Simulating a match for testing
            }
            else
            {
                Console.WriteLine("❌ Unexpected response: " + header);
            }
        }
    }

    public static void PrepareArduinoForResponse()
    {
        if (_serialPort.IsOpen)
        {
            Console.WriteLine("Notifying Arduino to prepare for response...");
            _serialPort.WriteLine("RESPONSE"); // Notify Arduino to get ready
            System.Threading.Thread.Sleep(500); // Small delay to ensure Arduino processes it
        }
    }

    public static void SendMatchResult(bool isMatch)
    {
        if (_serialPort.IsOpen)
        {
            string matchString = isMatch ? "1" : "0";
            _serialPort.WriteLine(matchString); // 1 = match, 0 = no match
            Console.WriteLine($"✅ Match result '{matchString}' sent to Arduino");
        }
    }

    public static void Main()
    {
        RequestFingerprint();
        System.Threading.Thread.Sleep(2000); // Wait for Arduino to process
        ReceiveFingerprint();
    }
}
