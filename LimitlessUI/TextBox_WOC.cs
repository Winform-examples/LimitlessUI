﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


/*
End-User Licence Agreement (EULA) for WithoutCaps Software 

This version is current as of May 27, 2017. Please consult withoutcapsdev@gmail.com for new versions of this EULA.

You can only use software made by the WithoutCaps Team after you agree to this licence. By using this software, you agree to 
all of the clauses in the WithoutCaps Software EULA.

PLEASE READ CAREFULLY BEFORE USING THIS PRODUCT: This End-User Licence Agreement(EULA) is a legal agreement between you 
(either an individual or as a single entity) and the entity is known as the WithoutCaps Team.

(a) Introduction. This is the End-User Licence Agreement (EULA) for this software which is produced by the WithoutCaps Team. 
This EULA outlines the clauses of the licence that the WithoutCapsTeam is willing to grant you (the user) to use this software. 

(b) Licence. The entity known as the WithoutCaps Team will grant a free of charge, fully-revocable, non-exclusive, non-transferable 
licence to any person obtaining a copy of this software as well as the associated documentation. The aforementioned documentation 
consists of the End-User Licence Agreement (EULA) for products made by the WithoutCaps Team. This licence permits you to use, modify 
and re-distribute this software non-commercially so long as you (either an individual or as a single entity) has permission from the 
WithoutCaps Team to do so. If the user wants to re-distribute software made by the WithoutCaps Team this EULA must be included in the 
software package.

(c) Ownership. Software produced by the WithoutCaps Team is licenced, not sold, to you (either an individual or as a single entity) 
and as such the WithoutCaps Software Team reserves any rights not expressly granted to you (either an individual or as a single entity).

The WithoutCaps Team reserves the right to revoke any persons (either an individual or as a single entity) licence without previous notification or agreements.

Notwithstanding the terms and conditions of this EULA, any part of the software contained with product by the WithoutCaps Team which 
constitutes Third Party Software and as such now owned is licenced to you subject to the terms and conditions of the software licence 
agreement accompanying such Third Party Software. Whatever the form of the licence, whether it be in the form of a discrete agreement, 
shrink wrap licence or electronic licence terms are accepted at the time of download or purchase of any software made by the WithoutCaps Team.

(d) Limitation of Liability. THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS 
BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION 
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Copyright (c) 2017 WithoutCaps
*/


namespace LimitlessUI
{
    public partial class TextBox_WOC : UserControl
    {
        private Color _borderColor = Color.Black;
        private int _borderThikness = 5;
        private bool _multiLine = true;
        private bool _drawBorder = false;


        public TextBox_WOC()
        {
            InitializeComponent();
            textBox.ContentsResized += richTextBox_ContentsResized;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            textBox.Width = Width - Padding.Left - Padding.Right;
            textBox.Left = Padding.Left;
            textBox.Top = (this.Height - textBox.Height) / 2;
            centerVertical(_multiLine);
        }

        private void richTextBox_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            var richTextBox = (RichTextBox)sender;
            textBox.Height = e.NewRectangle.Height;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_drawBorder)
            {
                Pen pen = new Pen(Color.Black, _borderThikness);
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, ClientRectangle);
            }
        }

        private void centerVertical(bool center)
        {
            if (center)
            {
                textBox.Dock = DockStyle.None;
                textBox.Location = new Point(Padding.Left, (Height - textBox.Height) / 2);
            }
            else textBox.Dock = DockStyle.Fill;
        }

        public bool Multiline
        {
            get { return _multiLine; }
            set
            {
                _multiLine = value;
                centerVertical(_multiLine);
                textBox.Multiline = !_multiLine;
            }
        }


        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value;  Invalidate(); }
        }


        public bool DrawBorder
        {
            get { return _drawBorder; }
            set { _drawBorder = value; Invalidate(); }
        }


        public int BorderThikness
        {
            get { return _borderThikness; }
            set
            {
                _borderThikness = value;
                Invalidate();
            }
        }

    }
}