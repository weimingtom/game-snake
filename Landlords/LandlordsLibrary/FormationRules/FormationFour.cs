﻿using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public class FormationFour : IFormation, IComparable<FormationThree>, IExpandable
    {
        private Card[] _cards;
        private IAppendix _appendix1;
        private IAppendix _appendix2;
        public FormationFour(Card[] pokers, IAppendix appendix1, IAppendix appendix2)
        {
            Guard.ArrayLengthEqual(pokers, 4);
            Guard.IsEqual(pokers[0].WeightValue, pokers[1].WeightValue, pokers[2].WeightValue, pokers[3].WeightValue);

            Guard.IsNotNull(appendix1);
            Guard.IsNotNull(appendix2);
            Guard.IsNotEqual(appendix1.Weight, appendix2.Weight);
            _appendix1 = appendix1;
            _appendix2 = appendix2;

            _cards = pokers;
        }


        public Card[] Cards
        {
            get
            {
                if (_appendix1 == null)
                {
                    return _cards;
                }

                return _cards.Concat(_appendix1.Cards).Concat(_appendix2.Cards).ToArray();
            }
        }

        public int Weight
        {
            get { return _cards[0].WeightValue; }
        }

        public string Signature
        {
            get
            {
                if (_cards.Length / 4 == 2)
                {
                    return "四带二";
                }
                else
                {
                    return "四带两对";
                }
            }
        }

        public int CompareTo(FormationThree other)
        {
            return this.Weight - other.Weight;
        }

    }
}
