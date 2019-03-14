using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelnetFake
{
    [Obsolete]
    class Class1
    {
        #region oldCode1
        public class controlCodes
        {
            public string name;
            public byte[] code;
            public controlCodes(string n, byte[] b)
            {
                name = n;
                code = b;
            }
            public override string ToString()
            {
                return name;
            }
        }

        public static List<controlCodes> MyControlCodes = new List<controlCodes>{
            new controlCodes("Query_Device_Code", getBytes("<ESC>[c")),
            new controlCodes("Query_Device_Status", getBytes("<ESC>[5n")),
            new controlCodes("Query_Cursor_Position ", getBytes("<ESC>[6n")),
            new controlCodes("Reset_Device", getBytes("<ESC>c")),
            new controlCodes("Enable_Line_Wrap", getBytes("<ESC>[7h")),
            new controlCodes("Disable_Line_Wrap", getBytes("<ESC>[7l")),

            new controlCodes("Font_Set_G0",  getBytes("<ESC>(")), //Font Set G0     <ESC>(
            new controlCodes("Font_Set_G1",  getBytes("<ESC>)")), //Font Set G0     <ESC>)

            new controlCodes("Home_Cursor",  getBytes("<ESC>[;H")), // <ESC>[{ROW};{COLUMN}H
            new controlCodes("Save_Cursor",  getBytes("<ESC>[s")), //<ESC>[{COUNT}A
            new controlCodes("Restore_Cursor", getBytes("<ESC>[u")),

            new controlCodes("Up_Cursor",  getBytes("<ESC>[1A")),        // <ESC>[{COUNT}A
            new controlCodes("Down_Cursor",  getBytes("<ESC>[1B")),        // <ESC>[{COUNT}B
            new controlCodes("Fwd_Cursor",  getBytes("<ESC>[1C")),        // <ESC>[{COUNT}C
            new controlCodes("Back_Cursor",  getBytes("<ESC>[1D")),        // <ESC>[{COUNT}D
            new controlCodes("Cursor_NextLine",  getBytes("<ESC>[1E")),
            new controlCodes("Cursor_PrevLine",  getBytes("<ESC>[1F")),
            new controlCodes("Cursor_Horizontal_Absolute",  getBytes("<ESC>[1G")),
            new controlCodes("Cursor_Vertical_Absolute",  getBytes("<ESC>[1d")),

            new controlCodes("Save_CursorAttrs", getBytes("<ESC>7")),
            new controlCodes("Restore_CursorAttrs", getBytes("<ESC>8")),

            //Cursor Visibility
            new controlCodes("Cursor Enable Blinking", getBytes("<ESC>[?12h")), //ATT160  Text Cursor Enable Blinking Start the cursor blinking
            new controlCodes("Cursor Disable Blinking", getBytes("<ESC>[?12l")), //ATT160  Text Cursor Enable Blinking Stop blinking the cursor
            new controlCodes("Cursor_Show", getBytes("<ESC>[?25h")), //DECTCEM Text Cursor Enable Mode Show    Show the cursor
            new controlCodes("Cursor_Hide", getBytes("<ESC>[?25l")), //DECTCEM Text Cursor Enable Mode Hide    Hide the cursor

            new controlCodes("Enable_Scroll", getBytes("<ESC>[r")),
            new controlCodes("ScrollFromTo", getBytes("<ESC>[{start};{end}r")),
            new controlCodes("Scroll_Down", getBytes("<ESC>D")),
            new controlCodes("Scroll_Up", getBytes("<ESC>M")),

            new controlCodes("Set_Tab", getBytes("<ESC>H")),
            new controlCodes("Clear_Tab", getBytes("<ESC>[g")),
            new controlCodes("Clear_All_Tabs", getBytes("<ESC>[3g")),

            new controlCodes("Erase_End_of_Line", getBytes("<ESC>[K")),
            new controlCodes("Erase_Start_of_Line", getBytes("<ESC>[1K")),
            new controlCodes("Erase_Line", getBytes("<ESC>[2K")),
            new controlCodes("Erase_Down", getBytes("<ESC>[J")),
            new controlCodes("Erase_Up", getBytes("<ESC>[1J")),
            new controlCodes("Erase_Screen", getBytes("<ESC>[2J")),

            new controlCodes("Print_Screen", getBytes("<ESC>[i")),
            new controlCodes("Print_Line ", getBytes("<ESC>[1i")),
            new controlCodes("Stop_Print_Log ", getBytes("<ESC>[4i")),
            new controlCodes("Start_Print_Log", getBytes("<ESC>[5i")),

            //VT100
            new controlCodes("Insert_char", getBytes("<ESC>[1@")),  // ESC [ <n> @	ICH	Insert Character	Insert <n> spaces at the current cursor position, shifting all existing text to the right. Text exiting the screen to the right is removed. 
            new controlCodes("Delete_char", getBytes("<ESC>[1P")),  // ESC [ <n> P	DCH	Delete Character	Delete <n> characters at the current cursor position, shifting in space characters from the right edge of the screen.
            new controlCodes("Erase_char", getBytes("<ESC>[1X")),   // ESC [ <n> X	ECH	Erase Character	Erase <n> characters from the current cursor position by overwriting them with a space character.
            new controlCodes("Insert_Line", getBytes("<ESC>[1L")),  // ESC [ <n> L	IL	Insert Line	Inserts <n> lines into the buffer at the cursor position. The line the cursor is on, and lines below it, will be shifted downwards.
            new controlCodes("Delete_Line", getBytes("<ESC>[1M")),  // ESC [ <n> M	DL	Delete Line	Deletes <n> lines from the buffer, starting with the row the cursor is on.

            new controlCodes("VP_Scroll_Up", getBytes("<ESC>[1S")), //ESC [ <n> S SU  Scroll Up   Scroll text up by <n>. Also known as pan down, new lines fill in from the bottom of the screen
            new controlCodes("VP_Scroll_Dn", getBytes("<ESC>[1T")),  //ESC [ <n> T	SD	Scroll Down	Scroll down by <n>. Also known as pan up, new lines fill in from the top of the screen

            new controlCodes("Report_Cursor", getBytes("<ESC>[6n")), //ESC [ 6 n   DECXCPR Report Cursor Position  Emit the cursor position as: ESC [ <r> ; <c> R Where<r> = cursor row and<c> = cursor column
            new controlCodes("Report_Identity", getBytes("<ESC>[0c")), //ESC [ 0 c   DA  Device Attributes   Report the terminal identity.Will emit “\x1b[?1;0c”, indicating "VT101 with No Options".

            new controlCodes("Charset_DEC", getBytes("<ESC>(0")),  // ESC ( 0 Designate Character Set – DEC Line Drawing  Enables DEC Line Drawing Mode
            new controlCodes("Charset_ASCII", getBytes("<ESC>(B")),  // ESC ( B Designate Character Set – US ASCII  Enables ASCII Mode (Default)

            // ESC [ <t> ; <b> r	DECSTBM	Set Scrolling Region	Sets the VT scrolling margins of the viewport.
            // ESC [ ? 1 0 4 9 h	Use Alternate Screen Buffer	Switches to a new alternate screen buffer.
            // ESC [ ? 1 0 4 9 l   Use Main Screen Buffer  Switches to the main buffer.
            new controlCodes("DEC_SoftReset", getBytes("<ESC>[!p")),    // ESC [ ! p	DECSTR	Soft Reset	Reset certain terminal settings to their defaults.
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
            new controlCodes("Horizontal Tab Set", getBytes("<ESC>H")),
            new controlCodes("Tab forward", getBytes("<ESC>[1I")),
            new controlCodes("Tab backward", getBytes("<ESC>[1Z")),
            new controlCodes("Clear Tab at Cursor", getBytes("<ESC>[0g")),
            new controlCodes("Clear Tab all", getBytes("<ESC>[3g")),
        };
        /*
        ESC [ <n> A	CUU	Cursor Up	Cursor up by <n>
        ESC [ <n> B	CUD	Cursor Down	Cursor down by <n>
        ESC [ <n> C	CUF	Cursor Forward	Cursor forward (Right) by <n>
        ESC [ <n> D	CUB	Cursor Backward	Cursor backward (Left) by <n>
        ESC [ <n> E	CNL	Cursor Next Line	Cursor down to beginning of <n>th line in the viewport
        ESC [ <n> F	CPL	Cursor Previous Line	Cursor up to beginning of <n>th line in the viewport
        ESC [ <n> G	CHA	Cursor Horizontal Absolute	Cursor moves to <n>th position horizontally in the current line
        ESC [ <n> d	VPA	Vertical Line Position Absolute	Cursor moves to the <n>th position vertically in the current column
        ESC [ <y> ; <x> H	CUP	Cursor Position	*Cursor moves to <x>; <y> coordinate within the viewport, where <x> is the column of the <y> line
        ESC [ <y> ; <x> f	HVP	Horizontal Vertical Position	*Cursor moves to <x>; <y> coordinate within the viewport, where <x> is the column of the <y> line
        ESC [ s	ANSISYSSC	Save Cursor – Ansi.sys emulation	**With no parameters, performs a save cursor operation like DECSC
        ESC [ u	ANSISYSSC	Restore Cursor – Ansi.sys emulation	**With no parameters, performs a restore cursor operation like DECRC
        */
        #endregion
        public static byte[] getCode(string name)
        {
            byte[] b = null;
            foreach (controlCodes codes in MyControlCodes)
            {
                if (codes.name.Equals(name))
                {
                    b = codes.code;
                    continue;
                }
            }
            return b;
        }
        static byte[] getBytes(String escString)
        {
            string s = escString.Replace("<ESC>", "\x1B");
            return Encoding.ASCII.GetBytes(s);
        }
    }

}
