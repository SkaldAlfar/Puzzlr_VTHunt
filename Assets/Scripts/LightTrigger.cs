using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    private SerialPort serialPort = new SerialPort("COM4", 9600);  // Adjust COM port and baud rate

    void Start()
    {
        // Open the serial port connection
        serialPort.Open();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object has a trigger
        if (other.CompareTag("Player"))  // Assuming you tag the player as "Player"
        {
            // Send '1' to Arduino to turn on the LED
            serialPort.Write("1");
            Debug.Log("LED ON");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Send '0' to Arduino to turn off the LED when leaving the trigger
        if (other.CompareTag("Player"))
        {
            serialPort.Write("0");
            Debug.Log("LED OFF");
        }
    }

    private void OnApplicationQuit()
    {
        // Ensure the serial port is closed when the application quits
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
