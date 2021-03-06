﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormControls
{
    public class CardBox : PictureBox
    {
        public bool IsSelected { get; set; }
        public int CardCode { get; set; }
        public bool IsEventRegisted { get; set; }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }

    public class CardBoxContainer : Panel
    {
        private List<CardBox> _cardBoxes = new List<CardBox>();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<CardBox> CardBoxes
        {
            get { return _cardBoxes; }
            set
            {
                _cardBoxes = value;
                if (_leftToRight)
                {
                    RepresentCardBoxesHorizontal();
                }
                else
                {
                    RepresentCardBoxesVertical();
                }
            }
        }

        private bool _leftToRight = true;
        public bool CardBoxLeftToRight
        {
            set { _leftToRight = value; }
        }

        public List<CardBox> SelectedCardBoxes
        {
            get
            {
                return this._cardBoxes.Where(b => b.IsSelected).ToList();
            }
        }

        public void RemoveSelectedCardBoxes()
        {
            _cardBoxes.RemoveAll(b => b.IsSelected);

            if (_leftToRight)
            {
                RepresentCardBoxesHorizontal();
            }
            else
            {
                RepresentCardBoxesVertical();
            }
        }

        public void RemoveCardBoxes(Predicate<CardBox> pre)
        {
            _cardBoxes.RemoveAll(pre);

            if (_leftToRight)
            {
                RepresentCardBoxesHorizontal();
            }
            else
            {
                RepresentCardBoxesVertical();
            }
        }

        private void RepresentCardBoxesVertical()
        {
            this.Controls.Clear();
            var left = 20;
            var top = 20;
            foreach (var box in _cardBoxes)
            {

                RepresentCard(box, left, top);
                top += 15;
            }
        }

        private void RepresentCardBoxesHorizontal()
        {
            this.Controls.Clear();

            var left = 20;
            var top = 20;
            foreach (var box in _cardBoxes)
            {
                RepresentCard(box, left, top);
                left += 15;
            }
        }

        private void RepresentCard(CardBox cardBox, int left, int top)
        {
            cardBox.Top = top;
            cardBox.Left = left;
            cardBox.Width = 60;
            cardBox.Height = 80;
            cardBox.SizeMode = PictureBoxSizeMode.StretchImage;
            if (!cardBox.IsEventRegisted)
            {
                cardBox.Click += CardBoxClick;
                cardBox.IsEventRegisted = true;
            }
            this.Controls.Add(cardBox);

            cardBox.BringToFront();
        }

        private void CardBoxClick(object sender, EventArgs e)
        {
            var pic = sender as CardBox;
            pic.IsSelected = !pic.IsSelected;
            if (pic.IsSelected)
            {
                pic.Top -= 20;
            }
            else
            {
                pic.Top += 20;
            }
        }
    }
}
