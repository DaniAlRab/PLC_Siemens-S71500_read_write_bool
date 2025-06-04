using System;
using S7.Net;

class Program
{
    static void Main()
    {
       // Change this to your PLC's IP
        string plcIp = "192.168.1.10";

		// Change this to your PLC's CPU type
        CpuType cpu = CpuType.S71200;

		// Change this to your rack number
        short rack = 0;

		// Change this to your slot number
        short slot = 1;
		
        int dbNumber = 3;

        using (Plc plc = new Plc(cpu, plcIp, rack, slot))
        {
            try
            {
                Console.WriteLine("Connecting to PLC...");
                plc.Open();

                if (plc.IsConnected)
                {
                    Console.WriteLine("Connected to PLC!");

                    // Read boolean value from DBX0.0 to DBX0.3
					
                    bool readBool0 = (bool)plc.Read($"DB{dbNumber}.DBX0.0"); //DB32.DBX0.0
                    Console.WriteLine("Read Bool0: " + readBool0);					
			
                    bool readBool1 = (bool)plc.Read($"DB{dbNumber}.DBX0.1");
                    Console.WriteLine("Read Bool1: " + readBool1);

                    bool readBool2 = (bool)plc.Read($"DB{dbNumber}.DBX0.2");
                    Console.WriteLine("Read Bool2: " + readBool2);

                    bool readBool3 = (bool)plc.Read($"DB{dbNumber}.DBX0.0");
                    Console.WriteLine("Read Bool3: " + readBool3);



                    bool valueToWrite0 = true; // or false
                    plc.Write($"DB{dbNumber}.DBX0.0", valueToWrite0);

                    bool valueToWrite1 = true; // or false
                    plc.Write($"DB{dbNumber}.DBX0.1", valueToWrite1);

                    bool valueToWrite2 = true; // or false
                    plc.Write($"DB{dbNumber}.DBX0.2", valueToWrite2);

                    bool valueToWrite3 = true; // or false
                    plc.Write($"DB{dbNumber}.DBX0.3", valueToWrite3);

                }
                else
                {
                    Console.WriteLine("Failed to connect to PLC.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                plc.Close();
                Console.WriteLine("Disconnected from PLC.");
            }
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    public static byte[] ReadBytes(Plc plc, int dbNumber, int startByte, int length)
    {
        byte[] buffer = new byte[length];
        for (int i = 0; i < length; i++)
        {
            buffer[i] = (byte)plc.Read(DataType.DataBlock, dbNumber, startByte + i, VarType.Byte, 1);
        }
        return buffer;
    }
}

public static class S7NetExtensions
{
    public static float ConvertToFloat(this uint value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        return BitConverter.ToSingle(bytes, 0);
    }
}
