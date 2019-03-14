using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace TelnetFake
{
    public partial class Form1 : Form
    {
        private static Server server=null;
        public Form1()
        {
            InitializeComponent();

            listTestCodes.Items.AddRange(ControlCodes.MyControlCodes.ToArray());
            listTestCodes.SelectedIndex = 0;

            listBoxTestScreens.Items.AddRange(ControlCodes.MyTestScreens.ToArray());
            listBoxTestScreens.SelectedIndex = 0;
        }

        void startServer()
        {
            if (server != null)
                return;
            server = new Server(IPAddress.Any, 1024);
            server.ClientConnected += clientConnected;
            server.ClientDisconnected += clientDisconnected;
            server.ConnectionBlocked += connectionBlocked;
            server.MessageReceived += messageReceived;
            server.start();

            addLog("SERVER STARTED: " + DateTime.Now);

            //char read = Console.ReadKey(true).KeyChar;

            //do
            //{
            //    if (read == 'b')
            //    {
            //        server.sendMessageToAll(Console.ReadLine());
            //    }
            //} while ((read = Console.ReadKey(true).KeyChar) != 'q');

            //server.stop();

        }

        void stopServer()
        {
            addLog("Stop Server...");
            if(server!=null)
                server.stop();
        }
        private  void clientConnected(Client c)
        {
            addLog("CONNECTED: " + c);

            server.sendMessageToClient(c, "Telnet Server" + Server.END_LINE + "Login: ");
            /*
            byte[] b;
            try
            {
                b = System.IO.File.ReadAllBytes("telnet.txt");
                s.sendMessageToClient(c, b);
            }catch(Exception ex)
            {
                log("Exception: " + ex.Message);
            }
            */
        }

        private  void clientDisconnected(Client c)
        {
            addLog("DISCONNECTED: " + c);
        }

        private  void connectionBlocked(IPEndPoint ep)
        {
            addLog(string.Format("BLOCKED: {0}:{1} at {2}", ep.Address, ep.Port, DateTime.Now));
        }

        static string removeCRLF(string msg)
        {
            while (msg.EndsWith("\n") || msg.EndsWith("\r"))
            {
                msg.Remove(msg.Length - 1);
            }
            return msg;
        }
        private  void messageReceived(Client c, string message)
        {
            //c.setStatus(EClientStatus.LoggedIn);
            log("messageReceived: " + message);
            //if (c.getCurrentStatus() != EClientStatus.LoggedIn)
            //{
            //    string m = removeCRLF(message);
            //    handleLogin(c, message);
            //    return;
            //}

            addLog("MESSAGE: " + message);

            if (message == "quit" || message == "logout" ||
                message == "exit")
            {
                server.kickClient(c);
                server.sendMessageToClient(c, Server.END_LINE + Server.CURSOR);
            }

            else if (message == "clear" || message == "c" || message == "\x1b")
            {
                server.clearClientScreen(c);
                server.sendMessageToClient(c, Server.CURSOR);
            }
            else if (message == "test" || message == "t")
            {

                server.clearClientScreen(c);
                byte[] b;
                try
                {
                    b = System.IO.File.ReadAllBytes("telnet.txt");
                    server.sendMessageToClient(c, b);

                    //render
                    doRender(b, (int)numericWidth.Value, (int)numericHeight.Value);
                }
                catch (Exception ex)
                {
                    log("Exception: " + ex.Message);
                }

            }

            else
                server.sendMessageToClient(c, Server.END_LINE + Server.CURSOR);
        }

        void doRender(byte[] b, int w, int h)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream(b);
            Bitmap bmp = renderScreen.getScreen(w, h, "ibm437", stream);
            pictureBox1.Image = bmp;
        }
        static void log(string s)
        {
            System.Diagnostics.Debug.WriteLine(s);
        }
        private static void handleLogin(Client c, string message)
        {
            EClientStatus status = c.getCurrentStatus();

            if (status == EClientStatus.Guest)
            {
                if (message == "")
                {
                    server.sendMessageToClient(c, Server.END_LINE + "Password: ");
                    c.setStatus(EClientStatus.Authenticating);
                }

                else
                    server.kickClient(c);
            }

            else if (status == EClientStatus.Authenticating)
            {
                if (message == "")
                {
                    server.clearClientScreen(c);
                    server.sendMessageToClient(c, "Successfully authenticated." + Server.END_LINE + Server.CURSOR);
                    c.setStatus(EClientStatus.LoggedIn);
                }

                else
                    server.kickClient(c);
            }
        }

        delegate void SetTextCallback(string text);
        public void addLog(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(addLog);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (txtLog.Text.Length > 2000)
                    txtLog.Text = "";
                txtLog.Text += text + "\r\n";
                txtLog.SelectionLength = 0;
                txtLog.SelectionStart = txtLog.Text.Length - 1;
                txtLog.ScrollToCaret();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //consoleProgram.MainCmd(new string[] { });
            startServer();
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            stopServer();
        }

        private void btnSendTest_Click(object sender, EventArgs e)
        {
            Dictionary<Socket, Client> clients;
            try
            {
                clients = server.clients;
            }
            catch (Exception)
            {
                return;
            }
            if (clients.Count > 0)
            {
                Client client = getFirstClient();
                server.clearClientScreen(client);

                int cols = (int)numericWidth.Value; int rows = (int)numericHeight.Value;
                String sRow = "";
                for (int x = 0; x < cols; x++)
                {
                    sRow += (x % 10).ToString();
                }
                
                byte[] disableWrap = Encoding.ASCII.GetBytes("\x1B[7l");
                server.sendMessageToClient(client, disableWrap);

                for (int x = 0; x < rows; x++)
                {
                    server.sendMessageToClient(client, ControlCodes.moveCursor(x, 0));
                    server.sendMessageToClient(client, Encoding.ASCII.GetBytes(sRow));
                }
                server.sendMessageToClient(client, ControlCodes.moveCursor(0));
            }
        }

        Client getFirstClient()
        {
            Dictionary<Socket, Client> clients = server.clients;
            if (clients.Count > 0)
            {
                var c = clients.GetEnumerator();
                c.MoveNext();
                return c.Current.Value;
            }
            return null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            var x = (ControlCodes.VTControlCodes) listTestCodes.SelectedItem;
            Client c = getFirstClient();
            server.sendMessageToClient(c, x.code);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var x = (ControlCodes.TestScreen)listBoxTestScreens.SelectedItem;
            Client c = getFirstClient();
            server.sendMessageToClient(c, x.code);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            var x = (ControlCodes.TestScreen)listBoxTestScreens.SelectedItem;
            Client c = getFirstClient();
            string btnText = ((Button)sender).Text;
            byte[] code = null;
            if (btnText == "0")
                code = ControlCodes.VTControlCodes.Home_Cursor.code;
            else if (btnText == "^")
                code = ControlCodes.VTControlCodes.Up_Cursor.code;
            else if (btnText == "v")
                code = ControlCodes.VTControlCodes.Down_Cursor.code;
            else if (btnText == "<")
                code = ControlCodes.VTControlCodes.Back_Cursor.code;
            else if (btnText == ">")
                code = ControlCodes.VTControlCodes.Fwd_Cursor.code;
            else if (btnText == "M")
                code = ControlCodes.VTControlCodes.Save_Cursor.code;
            else if (btnText == "C")
                code = ControlCodes.VTControlCodes.Restore_Cursor.code;

            if(code!=null)
                server.sendMessageToClient(c, code);
        }
    }
}
