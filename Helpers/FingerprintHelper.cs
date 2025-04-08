using System;
using System.IO.Ports;
using System.Threading.Tasks;

namespace proyectoIntegrador.Helpers
{
    public static class FingerprintHelper
    {
        private static SerialPort _serialPort = new SerialPort("COM3", 9600);

        //static FingerprintHelper()
        //{
        //    _serialPort = new SerialPort("COM3", 115200); // Ensure baud rate matches Arduino
        //    _serialPort.Open();
        //    _serialPort.DiscardInBuffer(); // Clear any old data
        //}
        static FingerprintHelper()
        {
            try
            {
                //_serialPort = new SerialPort("COM3", 115200);
                _serialPort.Open();
                _serialPort.DiscardInBuffer();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FingerprintHelper initialization failed: {ex.Message}");
            }
        }

        public static void RegisterFP(int user_id)
        {
            if (_serialPort == null || !_serialPort.IsOpen)
            {
                Console.WriteLine("Error: Serial port is not available.");
                return;
            }

            try
            {
                Console.WriteLine($"Registering fingerprint for user ID: {user_id}...");
                 // Convert int to string before sending. Not sure but I think Serial works with Strings.
                _serialPort.WriteLine(user_id.ToString());
                Console.WriteLine("Successfully registered!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while registering fingerprint: {ex.Message}");
            }
        }

        public static int UserIDForAttendance()
        {

            if (_serialPort.IsOpen)
            {
                _serialPort.WriteLine("-1"); // Tell Arduino to run the Attendance sequence.

                // Let's assume that user will take this much time atleast to give us fingerprint to match.
                //Task.Delay(30000);

                Console.WriteLine("Fetching UserID from Arduino to put attendance after fingerprint match...");
                string user_id = _serialPort.ReadLine();

                Console.WriteLine($"Received ID: {user_id}. Trying converting it to integer before returning...");
                if (int.TryParse(user_id, out int userID))
                {
                    return userID;
                }
                else
                {
                    Console.WriteLine("Invalid data received: " + user_id);
                    return -1; // Return -1 to indicate an error
                }
            }
            return -1; // Return -1 if the serial port is closed
        }
    }
}
