using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ticket_purchase_system.Captcha
{
    public class Captcha
    {
        private int length = 4; //default 4
        /// <summary>
        /// Length of the check code
        /// </summary>
        public int Length
        {
            get { return length; }//read
            set { length = value; }//write
        }

        private int fontSize = 20;
        public int FontSize
        {
            get { return fontSize; }//read
            set { fontSize = value; }//write
        }

        private Color backgroundColor = Color.White;
        public Color BackgroundColor
        {
            get { return backgroundColor; }//read
            set { backgroundColor = value; }//write
        }


        private string allCode = @"2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z,
                                    a,b,c,d,e,f,g,h,j,k,l,m,n,p,q,r,s,t,u,v,w,x,y,z";
        public string AllCode
        {
            get { return allCode; }//read
            set { allCode = value; }//write
        }

        private Color[] colors = { Color.Red, Color.Black, Color.Blue, Color.Green, Color.Chocolate, Color.Orange, Color.Purple };
        public Color[] Colors
        {
            get { return colors; }//read
            set { colors = value; }//write
        }

        private string[] fonts = { "Calibri", "Arial", "Century", };
        public string[] Fonts
        {
            get { return fonts; }//read
            set { fonts = value; }//write
        }

        private bool chaos = true;
        public bool Chaos
        {
            get { return chaos; }//read
            set { chaos = value; }//write
        }

        private Color chaosColor = Color.Brown;
        public Color ChaosColor
        {
            get { return chaosColor; }//read
            set { chaosColor = value; }//write
        }
        //8 properties

        /// <summary>
        /// Get the 
        /// </summary>
        /// <param name="codeLength"></param>
        /// <returns></returns>
        public string CreateCode(int codeLength)
        {
            string code = "";
            if (codeLength == 0)
            {
                codeLength = Length;

            }

            string[] arr = allCode.Split(',');
            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
            int index = -1;
            for (int i = 0; i < codeLength; i++)
            {
                index = rand.Next(0, arr.Length - 1);
                code += arr[index];
            }
            return code;

        }


        public void CreateImageOnPage(string code, HttpContext con)
        {
            MemoryStream ms = new MemoryStream();
            Bitmap image = this.CreateImageCode(code);
            image.Save(ms, ImageFormat.Jpeg);

            con.Response.ContentType = "image/jpeg";
            con.Response.BinaryWrite(ms.GetBuffer());
            ms.Close();
            image.Dispose();
        }

        private const double PI = 3.14159265358979323846264338327950288419716939937510582097494459230781640628620899862803482534211706798;
        private const double PI2 = 2 * PI;
        /// <summary>
        /// Sine wave twist image
        /// </summary>
        /// <param name="srcBmp"></param>
        /// <param name="bxDir"></param>
        /// <param name="dMulValue"></param>
        /// <param name="dPhase"></param>
        /// <returns></returns>
        public Bitmap TwistImage(Bitmap srcBmp, bool bxDir, double dMulValue, double dPhase)
        {
            Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);

            Graphics graph = Graphics.FromImage(destBmp);
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, destBmp.Width, destBmp.Height);
            graph.Dispose();

            double dBaseAxisLen = bxDir ? (double)destBmp.Height : (double)destBmp.Width;

            for (int i = 0; i < destBmp.Width; i++)
            {
                for (int j = 0; j < destBmp.Height; j++)
                {
                    double dx = 0;

                    dx = bxDir ? (PI2 * (double)j) / dBaseAxisLen : (PI2 * (double)i) / dBaseAxisLen;
                    dx += dPhase;
                    double dy = Math.Sin(dx);

                    int nOldX = 0, nOldY = 0;

                    nOldX = bxDir ? i + (int)(dy * dMulValue) : i;
                    nOldY = bxDir ? j : j + (int)(dy * dMulValue);

                    Color color = srcBmp.GetPixel(i, j);
                    if (nOldX >= 0 && nOldX < destBmp.Width &&
                       nOldY >= 0 && nOldY < destBmp.Height)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }

                }
            }
            return destBmp;
        }


        public Bitmap CreateImageCode(string code)
        {
            int fontWidth = fontSize;
            int imageWidth = (int)(code.Length * fontWidth) + 10;
            int imageHeight = fontWidth * 2;

            Bitmap image = new Bitmap(imageWidth, imageHeight);
            Graphics g = Graphics.FromImage(image);
            g.Clear(backgroundColor);
            Random rand = new Random();

            if (this.chaos)
            {
                Pen p = new Pen(ChaosColor, 1);
                int f = Length * 10;
                for (int i = 0; i < f; i++)
                {
                    int x = rand.Next(image.Width);
                    int y = rand.Next(image.Height);
                    g.DrawRectangle(p, x, y, 1, 1);
                }
            }

            int top = 0, left = 0, top1 = 1, top2 = 1;
            int n1 = (image.Width - fontWidth);
            int n2 = n1 / Length;

            Brush b;
            Font fnt;
            int fontIndex, colorIndex;

            for (int i = 0; i < code.Length; i++)
            {
                fontIndex = rand.Next(Fonts.Length - 1);
                colorIndex = rand.Next(Colors.Length - 1);
                fnt = new Font(Fonts[fontIndex], fontWidth);
                b = new SolidBrush(Colors[colorIndex]);

                if (i % 2 == 1)
                {
                    top = top2;
                }
                else
                {
                    top = top1;
                }

                left = i * fontWidth;
                g.DrawString(code.Substring(i, 1), fnt, b, left, top);

            }

            //    //cosin and sin   
            image = TwistImage(image, true, 10, 4);
            g.Dispose();

            return image;
        }

        public Captcha() { }

        public Captcha(int len, int fntSize)
        {
            Length = len;
            FontSize = fntSize;
        }

        public Captcha(int len)
        {
            Length = len;
        }

    }
}
