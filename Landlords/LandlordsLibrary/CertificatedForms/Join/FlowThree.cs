﻿using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class FlowThree : ICertification
    {
        public Formation.IFormation Issue(List<DataContext.Poker> cards)
        {
            var threes = new Formation.FormationThree[cards.Count / 3];
            for (int i = 0; i < threes.Length; i++)
            {
                threes[i] = new Formation.FormationThree(cards[3 * i], cards[3 * i + 1], cards[3 * i + 2]);
            }
            return new Formation.FormationSequenceofThree(threes);
        }

        public bool ICertificate(List<DataContext.Poker> cards)
        {
            int i = 0;
            var cards1 = cards.TakeWhile(p => { return i++ % 2 == 0; }).ToList();
            i = 0;
            var cards2 = cards.TakeWhile(p => { return i++ % 2 == 1; }).ToList();
            i = 0;
            var cards3 = cards.TakeWhile(p => { return i++ % 2 == 2; }).ToList();

            var isFlow = Identifier.Increase(cards1, 1, p => p.WeightValue);
            if (!isFlow)
            {
                return false;
            }
            var isSame = Identifier.BeSame<Poker, int>(cards1, cards2, p => p.WeightValue);
            if (!isSame)
            {
                return false;
            }
            return Identifier.BeSame<Poker, int>(cards1, cards3, p => p.WeightValue);
        }
    }
}