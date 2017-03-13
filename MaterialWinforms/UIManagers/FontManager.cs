﻿
using MaterialWinforms.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class FontManager
{

    public Font Roboto_Medium15;
    public Font Roboto_Medium10;
    public Font Roboto_Regular10;

   
    public Font Roboto_Medium9;
    public Font Roboto_Regular9;


    public FontManager()
    {
        Roboto_Medium15 = new Font(LoadFont(Resources.Roboto_Medium), 15f);
        Roboto_Medium10 = new Font(LoadFont(Resources.Roboto_Medium), 10f);
        Roboto_Regular10 = new Font(LoadFont(Resources.Roboto_Regular), 10f);

        Roboto_Medium9 = new Font(LoadFont(Resources.Roboto_Medium), 9f);
        Roboto_Regular9 = new Font(LoadFont(Resources.Roboto_Regular), 9f);      
    }

    public  Font ScaleTextToRectangle(Graphics g,String Text, Rectangle R, Boolean UseRegular = true)
    {
        float fontSize =  1f;
        FontFamily FontToUse = LoadFont(UseRegular?Resources.Roboto_Regular:Resources.Roboto_Medium);
        
        Font returnFont = new Font(FontToUse, fontSize);
        SizeF CurrentTextSize = g.MeasureString(Text, returnFont);

        while (CurrentTextSize.Width < R.Width && CurrentTextSize.Height < R.Height)
        {
            fontSize += 0.5f;
            returnFont.Dispose();
            returnFont = new Font(FontToUse, fontSize);
            CurrentTextSize = g.MeasureString(Text, returnFont);
        }


        return returnFont;
    }

    private PrivateFontCollection privateFontCollection = new PrivateFontCollection();
    
    [DllImport("gdi32.dll")]
    private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pvd, [In] ref uint pcFonts);

    private FontFamily LoadFont(byte[] fontResource)
    {
        int dataLength = fontResource.Length;
        IntPtr fontPtr = Marshal.AllocCoTaskMem(dataLength);
        Marshal.Copy(fontResource, 0, fontPtr, dataLength);

        uint cFonts = 0;
        AddFontMemResourceEx(fontPtr, (uint)fontResource.Length, IntPtr.Zero, ref cFonts);
        privateFontCollection.AddMemoryFont(fontPtr, dataLength);

        return privateFontCollection.Families.Last();
    }
}
