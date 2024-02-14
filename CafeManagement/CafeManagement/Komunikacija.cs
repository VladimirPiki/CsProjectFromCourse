using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagement
{
    internal class Komunikacija
    {
        public void Najava(string ime, string lozinka)
        {
            try
            {
                // Set the server IP address and port number
                string serverIp = "localhost";
                int serverPort = 8080;

                // Create a TcpClient to connect to the server
                TcpClient client = new TcpClient(serverIp, serverPort);

                // Get the network stream for reading and writing
                NetworkStream stream = client.GetStream();

                string message = "najava#" + ime + "#" + lozinka;
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                client.Close();
            }
            catch (Exception expt)
            {
               // MessageBox.Show("Неуспешно се испрати пораката до сервер !!!");
            }
        }

        public void Odjava(string vremeOdjava, string zabeleshka,string korisnikNajava,string korisnikIme)
        {
            try
            {
                // Set the server IP address and port number
                string serverIp = "localhost";
                int serverPort = 8080;

                // Create a TcpClient to connect to the server
                TcpClient client = new TcpClient(serverIp, serverPort);

                // Get the network stream for reading and writing
                NetworkStream stream = client.GetStream();

                string message = "odjava#" + vremeOdjava + "#" + zabeleshka+"#"+korisnikNajava+"#"+korisnikIme;
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                client.Close();
            }
            catch (Exception expt)
            {
            //    MessageBox.Show("Неуспешно се испрати пораката до сервер !!!");
            }
        }

        public void PorakaZaServer(string poraka)
        {
            try
            {
                // Set the server IP address and port number
                string serverIp = "localhost";
                int serverPort = 8080;

                // Create a TcpClient to connect to the server
                TcpClient client = new TcpClient(serverIp, serverPort);

                // Get the network stream for reading and writing
                NetworkStream stream = client.GetStream();

                string message = poraka;
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                client.Close();
            }
            catch (Exception expt)
            {
             //   MessageBox.Show("Неуспешно се испрати пораката до сервер !!!");
            }
        }

        public void IspratiExcel(string exportPath)
        {
            string serverIp = "127.0.0.1";
            int serverPort = 1027;
            System.Threading.Thread.Sleep(1000);
            //  System.Threading.Thread.Sleep(1000);

            // Create a TcpClient to connect to the server
            TcpClient client = new TcpClient(serverIp, serverPort);
            // MessageBox.Show("Connected to server.");

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
            //MessageBox.Show($"Excel file '{filePath}' sent successfully.");

            // Close the client connection
            client.Close();

        }
    }
}
