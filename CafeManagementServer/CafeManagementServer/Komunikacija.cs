using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CafeManagementServer
{
    internal class Komunikacija
    {
      
        public void IspratiExcel(string exportPath,int serverPort)
        {
            string serverIp = "127.0.0.1";
            //int serverPort = 1234;
            System.Threading.Thread.Sleep(1000);
            //  System.Threading.Thread.Sleep(1000);

            // Create a TcpClient to connect to the server
            TcpClient client = new TcpClient(serverIp, serverPort);

            // Get the network stream for reading and writing
            NetworkStream stream = client.GetStream();

            // Specify the Excel file to send
            string imeNaDadoteka = Path.GetFileName(exportPath);
            string filePath = imeNaDadoteka;

            // Send the file name to the server
            byte[] fileNameData = Encoding.ASCII.GetBytes(Path.GetFileName(filePath));
            stream.Write(fileNameData, 0, fileNameData.Length);

            // Send the Excel file data to the server
            byte[] buffer = new byte[1024];
            int bytesRead;
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, bytesRead);
                }
            }
            System.Threading.Thread.Sleep(1000);

            // Close the client connection
            client.Close();

        }
        
        public void IspratiMessage(string porakaNazad)
        {
            try
            {
                // Set the server IP address and port number
                string serverIp = "localhost";
                int serverPort = 8085;

                // Create a TcpClient to connect to the server
                TcpClient client = new TcpClient(serverIp, serverPort);

                // Get the network stream for reading and writing
                NetworkStream stream = client.GetStream();

                // Send a message to the server
                string message = porakaNazad;
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);


                // Close the client connection
                client.Close();

            }
            catch
            {

            }
        }

        public void IspratiMessageSoPort(int port,string porakaNazad)
        {
            try
            {
                // Set the server IP address and port number
                string serverIp = "localhost";
                int serverPort = port;

                // Create a TcpClient to connect to the server
                TcpClient client = new TcpClient(serverIp, serverPort);

                // Get the network stream for reading and writing
                NetworkStream stream = client.GetStream();

                // Send a message to the server
                string message = porakaNazad;
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);


                // Close the client connection
                client.Close();

            }
            catch
            {

            }
        }
    }
}
