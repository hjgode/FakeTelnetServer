using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using libVT100;

namespace TelnetFake
{
    class renderScreen
    {
        int width = 80;
        int height = 25;
        string fontName = "Courier New";
        int fontSize = 6;
        string encoding = "ibm437";

        public static Bitmap getScreen(int width, int height, string codepage, System.IO.Stream stream)
        {
            IVT100Decoder vt100 = new VT100Decoder();
            Screen screen = new Screen(width, height);
            vt100.Encoding = Encoding.GetEncoding(codepage);
            vt100.Subscribe(screen);

            //using (Stream stream = File.Open(inputFilename, FileMode.Open))
            //{
                int read = 0;
                while ((read = stream.ReadByte()) != -1)
                {
                    vt100.Input(new byte[] { (byte)read });
                }
            //}

            string fontName = "Courier New";
            //string fontName = "System";
            int fontSize = 16;

            System.Diagnostics.Debug.WriteLine(new string('=', width));
            System.Diagnostics.Debug.WriteLine(screen.toText());
            System.Diagnostics.Debug.WriteLine(new string('=', width));

            Bitmap bitmap = screen.ToBitmap(new Font(fontName, fontSize, FontStyle.Regular,GraphicsUnit.Pixel)); //emSize
            return bitmap;
        }
    }
}
