﻿using ModulusCheckerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModulusCheckerCore.Business
{
    public class ModulusWeightTable 
    {
        public IList<ModulusWeightItem> ModulusWeightItems { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModulusWeightTable"/> class.
        /// </summary>
        /// <param name="modulusWeightTableFile">The modulus weight table file.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public ModulusWeightTable(string modulusWeightTableFile)
        {
            if (string.IsNullOrEmpty(modulusWeightTableFile))
                throw new ArgumentNullException();

            var weightItems = modulusWeightTableFile.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            if (weightItems == null || !weightItems.Any())
                throw new NullReferenceException("No valid weight items were found");
            
            ModulusWeightItems = new List<ModulusWeightItem>();

            foreach(var weightItem in weightItems)
            {
                var items = weightItem.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var item = new ModulusWeightItem
                {
                    SortCodeStart = double.Parse(items.ElementAt(0)),
                    SortCodeEnd = double.Parse(items.ElementAt(1)),
                    ModulusCheck = (Entities.ModulusCheck)Enum.Parse(typeof(Entities.ModulusCheck), items.ElementAt(2), true),
                    Exception = items.Count() == 18 ? int.Parse(items.ElementAt(17)) : (int?)null,
                    Weight = new int[14]
                };

                // Todo: Optimise
                for(int i = 0; i < 14; i++)
                {
                    item.Weight[i] = int.Parse(items.ElementAt(i + 3));
                }
              
                ModulusWeightItems.Add(item);
            }
        }

        /// <summary>
        /// Gets the modulus weight item based on the sort code
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        /// <returns></returns>
        public ModulusWeightItem GetModulusWeight(BankAccount bankAccount)
        {
            return ModulusWeightItems
                .Where(x => x.SortCodeStart <= bankAccount.SortCode && x.SortCodeEnd <= bankAccount.SortCode)
                .FirstOrDefault();
        }
    }
}