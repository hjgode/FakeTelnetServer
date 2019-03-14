using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelnetFake
{
    public class ControlCodes
    {
        public static List<VTControlCodes> MyControlCodes
        {
            get
            {
                List<VTControlCodes> myList = new List<VTControlCodes>();
                Type type = typeof(VTControlCodes); // MyClass is static class with static properties
                foreach (var p in type.GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
                {
                    var v = p.GetValue(null); // static classes cannot be instanced, so use null...
                    myList.Add((VTControlCodes)v);                          //do something with v
                    Console.WriteLine(v.ToString());
                }
                return myList;
            }
        }
        public class VTControlCodes
        {
            private VTControlCodes(string name, byte[] codes) {
                Name = name;
                code = codes;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="name"></param>
            /// <param name="codes"></param>
            /// <param name="arguments">are inserted by replacing {} in code (normally between 'ESC[' and last char)</param>
            private VTControlCodes(string name, byte[] codes, string arguments)
            {
                Name = name;
                _code = codes;
                args = arguments;
            }
            public override string ToString()
            {
               return Name;
            }

            public string Name { get; set; }
            byte[] _code = null;
            public byte[] code {
                get
                {
                    if(args==null)
                        return _code;
                    else
                    {
                        //insert args in between ESC[ and final char
                        string s = Encoding.ASCII.GetString(_code);
                        s = s.Replace("{}", args);
                        return Encoding.ASCII.GetBytes(s);
                    }
                }
                set
                {
                    _code = value;
                }
            }
            string args = null;
            

            public static VTControlCodes Query_Device_Code { get { return new VTControlCodes("Query_Device_Code", getBytes("<ESC>[c")); } }
            public static VTControlCodes Query_Device_Status { get { return new VTControlCodes("Query_Device_Status", getBytes("<ESC>[5n")); } }
            public static VTControlCodes Query_Cursor_Position { get { return new VTControlCodes("Query_Cursor_Position ", getBytes("<ESC>[6n")); } }
            public static VTControlCodes Reset_Device { get { return new VTControlCodes("Reset_Device", getBytes("<ESC>c")); } }
            public static VTControlCodes Enable_Line_Wrap { get { return new VTControlCodes("Enable_Line_Wrap", getBytes("<ESC>[7h")); } }
            public static VTControlCodes Disable_Line_Wrap { get { return new VTControlCodes("Disable_Line_Wrap", getBytes("<ESC>[7l")); } }

            public static VTControlCodes Font_Set_G0 { get { return new VTControlCodes("Font_Set_G0", getBytes("<ESC>(")); } }
            //Font Set G0     <ESC>(
            public static VTControlCodes Font_Set_G1 { get { return new VTControlCodes("Font_Set_G1", getBytes("<ESC>)")); } }
            //Font Set G0     <ESC>)

            public static VTControlCodes Home_Cursor { get { return new VTControlCodes("Home_Cursor", getBytes("<ESC>[;H")); } }
            // <ESC>[{ROW};{COLUMN}H
            public static VTControlCodes Save_Cursor { get { return new VTControlCodes("Save_Cursor", getBytes("<ESC>[s")); } }
            //<ESC>[{COUNT}A
            public static VTControlCodes Restore_Cursor { get { return new VTControlCodes("Restore_Cursor", getBytes("<ESC>[u")); } }

            public static VTControlCodes Up_Cursor { get { return new VTControlCodes("Up_Cursor", getBytes("<ESC>[1A")); } }
            // <ESC>[{COUNT}A
            public static VTControlCodes Down_Cursor { get { return new VTControlCodes("Down_Cursor", getBytes("<ESC>[1B")); } }
            // <ESC>[{COUNT}B
            public static VTControlCodes Fwd_Cursor { get { return new VTControlCodes("Fwd_Cursor", getBytes("<ESC>[1C")); } }
            // <ESC>[{COUNT}C
            public static VTControlCodes Back_Cursor { get { return new VTControlCodes("Back_Cursor", getBytes("<ESC>[1D")); } }
            // <ESC>[{COUNT}D
            public static VTControlCodes Cursor_NextLine { get { return new VTControlCodes("Cursor_NextLine", getBytes("<ESC>[1E")); } }
            public static VTControlCodes Cursor_PrevLine { get { return new VTControlCodes("Cursor_PrevLine", getBytes("<ESC>[1F")); } }
            public static VTControlCodes Cursor_Horizontal_Absolute { get { return new VTControlCodes("Cursor_Horizontal_Absolute", getBytes("<ESC>[1G")); } }
            public static VTControlCodes Cursor_Vertical_Absolute { get { return new VTControlCodes("Cursor_Vertical_Absolute", getBytes("<ESC>[1d")); } }

            public static VTControlCodes Save_CursorAttrs { get { return new VTControlCodes("Save_CursorAttrs", getBytes("<ESC>7")); } }
            public static VTControlCodes Restore_CursorAttrs { get { return new VTControlCodes("Restore_CursorAttrs", getBytes("<ESC>8")); } }


            //Cursor Visibility
            public static VTControlCodes Cursor_Enable_Blinking { get { return new VTControlCodes("Cursor_Enable_Blinking", getBytes("<ESC>[?12h")); } }
            //ATT160  Text Cursor Enable Blinking Start the cursor blinking
            public static VTControlCodes Cursor_Disable_Blinking { get { return new VTControlCodes("Cursor_Disable_Blinking", getBytes("<ESC>[?12l")); } }
            //ATT160  Text Cursor Enable Blinking Stop blinking the cursor
            public static VTControlCodes Cursor_Show { get { return new VTControlCodes("Cursor_Show", getBytes("<ESC>[?25h")); } }
            //DECTCEM Text Cursor Enable Mode Show    Show the cursor
            public static VTControlCodes Cursor_Hide { get { return new VTControlCodes("Cursor_Hide", getBytes("<ESC>[?25l")); } }
            //DECTCEM Text Cursor Enable Mode Hide    Hide the cursor

            public static VTControlCodes Enable_Scroll { get { return new VTControlCodes("Enable_Scroll", getBytes("<ESC>[r")); } }
            public static VTControlCodes ScrollFromTo { get { return new VTControlCodes("ScrollFromTo", getBytes("<ESC>[{start};{end}r")); } }
            public static VTControlCodes Scroll_Down { get { return new VTControlCodes("Scroll_Down", getBytes("<ESC>D")); } }
            public static VTControlCodes Scroll_Up { get { return new VTControlCodes("Scroll_Up", getBytes("<ESC>M")); } }

            public static VTControlCodes Set_Tab { get { return new VTControlCodes("Set_Tab", getBytes("<ESC>H")); } }
            public static VTControlCodes Clear_Tab { get { return new VTControlCodes("Clear_Tab", getBytes("<ESC>[g")); } }
            public static VTControlCodes Clear_All_Tabs { get { return new VTControlCodes("Clear_All_Tabs", getBytes("<ESC>[3g")); } }

            public static VTControlCodes Erase_End_of_Line { get { return new VTControlCodes("Erase_End_of_Line", getBytes("<ESC>[K")); } }
            public static VTControlCodes Erase_Start_of_Line { get { return new VTControlCodes("Erase_Start_of_Line", getBytes("<ESC>[1K")); } }
            public static VTControlCodes Erase_Line { get { return new VTControlCodes("Erase_Line", getBytes("<ESC>[2K")); } }
            public static VTControlCodes Erase_Down { get { return new VTControlCodes("Erase_Down", getBytes("<ESC>[J")); } }
            public static VTControlCodes Erase_Up { get { return new VTControlCodes("Erase_Up", getBytes("<ESC>[1J")); } }
            public static VTControlCodes Erase_Screen { get { return new VTControlCodes("Erase_Screen", getBytes("<ESC>[2J")); } }

            public static VTControlCodes Print_Screen { get { return new VTControlCodes("Print_Screen", getBytes("<ESC>[i")); } }
            public static VTControlCodes Print_Line { get { return new VTControlCodes("Print_Line ", getBytes("<ESC>[1i")); } }
            public static VTControlCodes Stop_Print_Log { get { return new VTControlCodes("Stop_Print_Log ", getBytes("<ESC>[4i")); } }
            public static VTControlCodes Start_Print_Log { get { return new VTControlCodes("Start_Print_Log", getBytes("<ESC>[5i")); } }


            //VT100
            public static VTControlCodes Insert_char { get { return new VTControlCodes("Insert_char", getBytes("<ESC>[1@")); } }
            public static VTControlCodes Insert_chars(string arg)
            {
                return new VTControlCodes("Insert_chars", getBytes("<ESC>[{}@"), arg);
            }

            // ESC [ <n> @	ICH	Insert Character	Insert <n> spaces at the current cursor position, shifting all existing text to the right. Text exiting the screen to the right is removed. 
            public static VTControlCodes Delete_char { get { return new VTControlCodes("Delete_char", getBytes("<ESC>[1P")); } }
            public static VTControlCodes Delete_chars(string arg)
            {
                return new VTControlCodes("Delete_chars", getBytes("<ESC>[{}P"), arg);
            } 
            // ESC [ <n> P	DCH	Delete Character	Delete <n> characters at the current cursor position, shifting in space characters from the right edge of the screen.
            public static VTControlCodes Erase_char { get { return new VTControlCodes("Erase_char", getBytes("<ESC>[1X")); } }
            public static VTControlCodes Erase_chars(string arg) {return new VTControlCodes("Erase_char", getBytes("<ESC>[{}X"),arg); } 
            // ESC [ <n> X	ECH	Erase Character	Erase <n> characters from the current cursor position by overwriting them with a space character.
            public static VTControlCodes Insert_Line { get { return new VTControlCodes("Insert_Line", getBytes("<ESC>[1L")); } }
            // ESC [ <n> L	IL	Insert Line	Inserts <n> lines into the buffer at the cursor position. The line the cursor is on, and lines below it, will be shifted downwards.
            public static VTControlCodes Delete_Line { get { return new VTControlCodes("Delete_Line", getBytes("<ESC>[1M")); } }
            // ESC [ <n> M	DL	Delete Line	Deletes <n> lines from the buffer, starting with the row the cursor is on.

            public static VTControlCodes VP_Scroll_Up { get { return new VTControlCodes("VP_Scroll_Up", getBytes("<ESC>[1S")); } }
            //ESC [ <n> S SU  Scroll Up   Scroll text up by <n>. Also known as pan down, new lines fill in from the bottom of the screen
            public static VTControlCodes VP_Scroll_Dn { get { return new VTControlCodes("VP_Scroll_Dn", getBytes("<ESC>[1T")); } }
            //ESC [ <n> T	SD	Scroll Down	Scroll down by <n>. Also known as pan up, new lines fill in from the top of the screen

            public static VTControlCodes Report_Cursor { get { return new VTControlCodes("Report_Cursor", getBytes("<ESC>[6n")); } }
            //ESC [ 6 n   DECXCPR Report Cursor Position  Emit the cursor position as: ESC [ <r> ; <c> R Where<r> = cursor row and<c> = cursor column
            public static VTControlCodes Report_Identity { get { return new VTControlCodes("Report_Identity", getBytes("<ESC>[0c")); } }
            //ESC [ 0 c   DA  Device Attributes   Report the terminal identity.Will emit “\x1b[?1;0c”, indicating "VT101 with No Options".

            public static VTControlCodes Charset_DEC { get { return new VTControlCodes("Charset_DEC", getBytes("<ESC>(0")); } }
            // ESC ( 0 Designate Character Set – DEC Line Drawing  Enables DEC Line Drawing Mode
            public static VTControlCodes Charset_ASCII { get { return new VTControlCodes("Charset_ASCII", getBytes("<ESC>(B")); } }
            // ESC ( B Designate Character Set – US ASCII  Enables ASCII Mode (Default)


            // ESC [ <t> ; <b> r	DECSTBM	Set Scrolling Region	Sets the VT scrolling margins of the viewport.

            // ESC [ ? 1 0 4 9 h	Use Alternate Screen Buffer	Switches to a new alternate screen buffer.

            // ESC [ ? 1 0 4 9 l   Use Main Screen Buffer  Switches to the main buffer.
            public static VTControlCodes DEC_SoftReset { get { return new VTControlCodes("DEC_SoftReset", getBytes("<ESC>[!p")); } }
            // ESC [ ! p	DECSTR	Soft Reset	Reset certain terminal settings to their defaults.
            /*
            Cursor visibility: visible (DECTEM)
            Numeric Keypad: Numeric Mode (DECNKM)
            Cursor Keys Mode: Normal Mode (DECCKM)
            Top and Bottom Margins: Top=1, Bottom=Console height (DECSTBM)
            Character Set: US ASCII
            Graphics Rendition: Default/Off (SGR)
            Save cursor state: Home position (0,0) (DECSC)
            */

            //see also https://docs.microsoft.com/en-us/windows/console/console-virtual-terminal-sequences

            /*
            Sequence	Code	Description	Behavior
            ESC H	HTS	Horizontal Tab Set	Sets a tab stop in the current column the cursor is in.
            ESC [ <n> I	CHT	Cursor Horizontal (Forward) Tab	Advance the cursor to the next column (in the same row) with a tab stop. If there are no more tab stops, move to the last column in the row. If the cursor is in the last column, move to the first column of the next row.
            ESC [ <n> Z	CBT	Cursor Backwards Tab	Move the cursor to the previous column (in the same row) with a tab stop. If there are no more tab stops, moves the cursor to the first column. If the cursor is in the first column, doesn’t move the cursor.
            ESC [ 0 g	TBC	Tab Clear (current column)	Clears the tab stop in the current column, if there is one. Otherwise does nothing.
            ESC [ 3 g	TBC	Tab Clear (all columns)	Clears all currently set tab stops.
            For both CHT and CBT, <n> is an optional parameter that (default=1) indicating how many times to advance the cursor in the specified direction.
            If there are no tab stops set via HTS, CHT and CBT will treat the first and last columns of the window as the only two tab stops.
            Using HTS to set a tab stop will also cause the console to navigate to the next tab stop on the output of a TAB (0x09, ‘\t’) character, in the same manner as CHT.
            */
            public static VTControlCodes Horizontal_Tab_Set { get { return new VTControlCodes("Horizontal_Tab_Set", getBytes("<ESC>H")); } }
            public static VTControlCodes Tab_forward { get { return new VTControlCodes("Tab_forward", getBytes("<ESC>[1I")); } }
            public static VTControlCodes Tab_backward { get { return new VTControlCodes("Tab_backward", getBytes("<ESC>[1Z")); } }
            public static VTControlCodes Clear_Tab_at_Cursor { get { return new VTControlCodes("Clear_Tab_at_Cursor", getBytes("<ESC>[0g")); } }
            public static VTControlCodes Clear_Tab_all { get { return new VTControlCodes("Clear_Tab_all", getBytes("<ESC>[3g")); } }

        }

        static string _EnableScrollFromTo = "<ESC>[{start};{end}r";

        string Set_Key_Definition = "<ESC>[{key};\"{string}\"p";    // Associates a string of text to a keyboard key. {key} indicates the key by its ASCII value in decimal.

        string Set_Attribute_Mode = "<ESC>[{attr1};...;{attrn}m"; //"<ESC>[{attr1};...;{attrn}m";

        [Flags]
        public enum Attr
        {
            Reset_all_attributes = 0,
            Bright = 1,
            Dim = 2,
            Underscore = 4,
            Blink = 5,
            Reverse = 7,
            Hidden = 8,
            //Foreground Colours
            FG_Black = 30,
            FG_Red = 31,
            FG_Green = 32,
            FG_Yellow = 33,
            FG_Blue = 34,
            FG_Magenta = 35,
            FG_Cyan = 36,
            FG_White = 37,
            //Background Colours
            Black = 40,
            Red = 41,
            Green = 42,
            Yellow = 43,
            Blue = 44,
            Magenta = 45,
            Cyan = 46,
            White = 47
        };

        public class TestScreen
        {
            public string name;
            public byte[] code;
            public TestScreen(string s, byte[] b)
            {
                name = s;
                code = b;
            }
            public override string ToString()
            {
                return name;
            }
        }

        public static List<TestScreen> MyTestScreens = new List<TestScreen>
        {
            new TestScreen( "testScreen", testScreen() ),
            new TestScreen( "vertical border", PrintVerticalBorder() ),
            new TestScreen( "horizontal border", PrintHorizontalBorder(new System.Drawing.Size(8,8), true) ),
            new TestScreen( "Print Box", PrintBox()),

        };
        public static byte[] testScreen()
        {
            List<byte> bytes = new List<byte>();
            int line = 1;
            bytes.AddRange(VTControlCodes.Erase_Screen.code);
            bytes.AddRange(moveCursor(line++, 1));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Reset_all_attributes }));
            bytes.AddRange(Encoding.ASCII.GetBytes("normal Text"));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Reset_all_attributes })); bytes.AddRange(moveCursor(line++, 1));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Dim }));
            bytes.AddRange(Encoding.ASCII.GetBytes("dimmed Text"));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Reset_all_attributes })); bytes.AddRange(moveCursor(line++, 1));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Bright }));
            bytes.AddRange(Encoding.ASCII.GetBytes("bright Text"));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Reset_all_attributes })); bytes.AddRange(moveCursor(line++, 1));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.FG_Green, Attr.Blue }));
            bytes.AddRange(Encoding.ASCII.GetBytes("green on blue Text"));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Reset_all_attributes })); bytes.AddRange(moveCursor(line++, 1));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Blink }));
            bytes.AddRange(Encoding.ASCII.GetBytes("blink Text"));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Reset_all_attributes })); bytes.AddRange(moveCursor(line++, 1));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Reverse }));
            bytes.AddRange(Encoding.ASCII.GetBytes("reverse Text "));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Blink })); bytes.AddRange(Encoding.ASCII.GetBytes("blink"));

            bytes.AddRange(setAttr(new List<Attr>() { Attr.Reset_all_attributes })); bytes.AddRange(moveCursor(line++, 1));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Underscore }));
            bytes.AddRange(Encoding.ASCII.GetBytes("underscore Text"));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Reset_all_attributes })); bytes.AddRange(moveCursor(line++, 1));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Hidden }));
            bytes.AddRange(Encoding.ASCII.GetBytes("hidden Text"));

            bytes.AddRange(moveCursor(line++, 1));
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Reset_all_attributes }));
            bytes.AddRange(Encoding.ASCII.GetBytes("normal Text"));

            return bytes.ToArray();
        }

        static string ESC = "\x1b";
        static string CSI = "\x1b[";
        public static byte[] PrintVerticalBorder()
        {
            List<byte> bytes = new List<byte>();
            int line = 1;
            bytes.AddRange(VTControlCodes.Erase_Screen.code);
            bytes.AddRange(VTControlCodes.Charset_DEC.code);// Enter Line drawing mode
            bytes.AddRange(Encoding.ASCII.GetBytes("\x1b[ 104;93m"));   // bright yellow on bright blue
            bytes.AddRange(Encoding.ASCII.GetBytes("x"));            // in line drawing mode, \x78 -> \u2502 "Vertical Bar"
            bytes.AddRange(Encoding.ASCII.GetBytes("\x1b[ 0m"));       // restore color
            bytes.AddRange(Encoding.ASCII.GetBytes("\x1b (B"));       // exit line drawing mode
            bytes.AddRange(VTControlCodes.Charset_ASCII.code);
            return bytes.ToArray();
        }

        public static byte[] PrintHorizontalBorder(System.Drawing.Size size, bool fIsTop)
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(VTControlCodes.Erase_Screen.code);
            bytes.AddRange(VTControlCodes.Charset_DEC.code);
            bytes.AddRange(Encoding.ASCII.GetBytes("\x1b (0"));       // Enter Line drawing mode
            bytes.AddRange(Encoding.ASCII.GetBytes("\x1b[ 104;93m"));  // Make the border bright yellow on bright blue

            bytes.AddRange(Encoding.ASCII.GetBytes(fIsTop ? "l" : "m")); // print left corner 

            for (int i = 1; i<size.Width - 1; i++)
                bytes.AddRange(Encoding.ASCII.GetBytes("q")); // in line drawing mode, \x71 -> \u2500 "HORIZONTAL SCAN LINE-5"

            bytes.AddRange(Encoding.ASCII.GetBytes(fIsTop ? "k" : "j")); // print right corner
            bytes.AddRange(Encoding.ASCII.GetBytes("\x1b[ 0m"));
            bytes.AddRange(Encoding.ASCII.GetBytes("\x1b (B"));       // exit line drawing mode
            bytes.AddRange(VTControlCodes.Charset_ASCII.code);
            return bytes.ToArray();
        }

        /*
        Notably, the DEC Line Drawing mode is used for drawing borders in console applications. The following table shows what ASCII character maps to which line drawing character.

            Hex	ASCII	DEC Line Drawing
            0x6a	j	┘
            0x6b	k	┐
            0x6c	l	┌
            0x6d	m	└
            0x6e	n	┼
            0x71	q	─
            0x74	t	├
            0x75	u	┤
            0x76	v	┴
            0x77	w	┬
            0x78	x	│
        */
        public static byte[] PrintBox()
        {
            List<byte> bytes = new List<byte>();
            string[] s = new string[] {
                "  Box Test ",
                "  lqqqwqqqk ",
                "  x   x   x ",
                "  tqqqnqqqu ",
                "  x   x   x ",
                "  mqqqvqqqj ",
                "    ENDE   ",
            };
            int line = 1;            
            bytes.AddRange(VTControlCodes.Erase_Screen.code);
            bytes.AddRange(moveCursor(line++, 1));
            bytes.AddRange(Encoding.ASCII.GetBytes(s[0]));
            bytes.AddRange(moveCursor(line++, 1));
            bytes.AddRange(VTControlCodes.Charset_DEC.code);
            bytes.AddRange(setAttr(new List<Attr>() { Attr.FG_Red }));
            for (int x=1; x<s.Length-1; x++)
            {
                bytes.AddRange(Encoding.ASCII.GetBytes(s[x]));
                bytes.AddRange(moveCursor(line++, 1));
            }
            bytes.AddRange(VTControlCodes.Charset_ASCII.code);
            bytes.AddRange(setAttr(new List<Attr>() { Attr.Reset_all_attributes }));
            bytes.AddRange(Encoding.ASCII.GetBytes(s[s.Length-1]));
            bytes.AddRange(VTControlCodes.Home_Cursor.code);
            return bytes.ToArray();

        }
        public static byte[] setAttr(List<Attr> attributes)
        {
            byte[] b = new byte[] { };
            string sAttr = "";
            foreach (Attr a in attributes)
                sAttr += ((int)a).ToString() + ";";
            if (sAttr.EndsWith(";"))
                sAttr = sAttr.Substring(0, sAttr.Length - 1);
            sAttr = "<ESC>[" + sAttr + "m";
            System.Diagnostics.Debug.WriteLine("SetAttr=" + sAttr);
            b = getBytes(sAttr);
            return b;
        }
        public static byte[] EnableScrollFromTo(int from, int to)
        {
            string s = _EnableScrollFromTo.Replace("{start}", from.ToString());
            s = _EnableScrollFromTo.Replace("{end}", to.ToString());
            return getBytes(s);
        }
        public static byte[] moveCursor(int row, int col)
        {
            byte[] moveCursor = Encoding.ASCII.GetBytes("\x1B[" + row.ToString() + ";" + col.ToString() + "H");
            return moveCursor;
        }
        public static byte[] moveCursor(int col)
        {
            byte[] moveCursor = Encoding.ASCII.GetBytes("\x1B[;" + col.ToString() + "H");
            return moveCursor;
        }

        static byte[] getBytes(String escString)
        {
            string s = escString.Replace("<ESC>", "\x1B");
            return Encoding.ASCII.GetBytes(s);
        }
    }
}
