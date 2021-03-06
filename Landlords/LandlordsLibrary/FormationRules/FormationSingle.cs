﻿using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public class FormationSingle : IFormation, IComparable<FormationSingle>, IAppendix
    {
        private Card _poker;

        public FormationSingle(Card poker)
        {
            _poker = poker;
        }

        public int Weight
        {
            get { return _poker.WeightValue; }
        }

        public string Signature
        {
            get { return "单张"; }
        }

        public int CompareTo(FormationSingle other)
        {
            return this.Weight - other.Weight;
        }


        public Card[] Cards
        {
            get { return new Card[] { _poker }; }
        }
    }
}
