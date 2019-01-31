using System;
using System.Net;

namespace TelnetFake
{
    class consoleProgram
    {
        private static Server s;

        public static void MainCmd(string[] args)
        {
            s = new Server(IPAddress.Any, 1024);
            s.ClientConnected += clientConnected;
            s.ClientDisconnected += clientDisconnected;
            s.ConnectionBlocked += connectionBlocked;
            s.MessageReceived += messageReceived;
            s.start();

            Console.WriteLine("SERVER STARTED: " + DateTime.Now);

            char read = Console.ReadKey(true).KeyChar;

            do
            {
                if (read == 'b')
                {
                    s.sendMessageToAll(Console.ReadLine());
                }
            } while ((read = Console.ReadKey(true).KeyChar) != 'q');

            s.stop();
        }

        private static void clientConnected(Client c)
        {
            Console.WriteLine("CONNECTED: " + c);

            s.sendMessageToClient(c, "Telnet Server" + Server.END_LINE + "Login: ");
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

        private static void clientDisconnected(Client c)
        {
            Console.WriteLine("DISCONNECTED: " + c);
        }

        private static void connectionBlocked(IPEndPoint ep)
        {
            Console.WriteLine(string.Format("BLOCKED: {0}:{1} at {2}", ep.Address, ep.Port, DateTime.Now));
        }

        static string removeCRLF(string msg)
        {
            while (msg.EndsWith("\n") || msg.EndsWith("\r"))
            {
                msg.Remove(msg.Length - 1);
            }
            return msg;
        }
        private static void messageReceived(Client c, string message)
        {
            //c.setStatus(EClientStatus.LoggedIn);
            log("messageReceived: " +message);
            if (c.getCurrentStatus() != EClientStatus.LoggedIn)
            {
                string m = removeCRLF(message);
                handleLogin(c, message);
                return;
            }

            Console.WriteLine("MESSAGE: " + message);

            if (message == "quit" || message == "logout" ||
                message == "exit")
            {
                s.kickClient(c);
                s.sendMessageToClient(c, Server.END_LINE + Server.CURSOR);
            }

            else if (message == "clear" || message == "c" || message == "\x1b")
            {
                s.clearClientScreen(c);
                s.sendMessageToClient(c, Server.CURSOR);
            }
            else if (message == "test" || message == "t") 
            {
                s.clearClientScreen(c);
                byte[] b;
                try
                {
                    b = System.IO.File.ReadAllBytes("telnet.txt");
                    s.sendMessageToClient(c, b);
                }catch(Exception ex)
                {
                    log("Exception: " + ex.Message);
                }

            }

            else
                s.sendMessageToClient(c, Server.END_LINE + Server.CURSOR);
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
                if (message == "r")
                {
                    s.sendMessageToClient(c, Server.END_LINE + "Password: ");
                    c.setStatus(EClientStatus.Authenticating);
                }

                else
                    s.kickClient(c);
            }

            else if (status == EClientStatus.Authenticating)
            {
                if (message == "r")
                {
                    s.clearClientScreen(c);
                    s.sendMessageToClient(c, "Successfully authenticated." + Server.END_LINE + Server.CURSOR);
                    c.setStatus(EClientStatus.LoggedIn);
                }

                else
                    s.kickClient(c);
            }
        }
    }
}