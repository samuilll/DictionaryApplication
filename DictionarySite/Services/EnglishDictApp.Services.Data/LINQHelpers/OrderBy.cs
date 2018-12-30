   namespace EnglishDictApp.Services.LINQHelpers
    {
        using System;
        using System.Linq;

        public static class OrderBy
        {
            public static IQueryable<T> Randomize<T>(this IQueryable<T> list)
            {
                Random rnd = new Random();
                var randomizedList = from item in list
                                     orderby rnd.Next()
                                     select item;

                return randomizedList;
            }
        }
    }

