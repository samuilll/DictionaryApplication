using System;
using System.Collections.Generic;
using System.Linq;
using Dictionary.Models;
using Dictionary.Repository;
using Microsoft.EntityFrameworkCore;
using TestPro.Models;

namespace TestPro
{
   public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello!!!");
            var db = new DictionaryDbContext();

            var oldContext = new BlogOfSamContext();


            var user = db.Users
                .Include(u=>u.UserWords)
                .ThenInclude(uw=>uw.Word)
                .FirstOrDefault();

            var userId = user.Id;

            Console.WriteLine(db.Users.Count());
            Console.WriteLine(user.Email);

            var words = db.Words.ToList();

            var usersWords = new List<UserWord>();

            //foreach (var word in words)
            //{
            //    usersWords.Add(new UserWord()
            //        {
            //            UserId = userId,
            //            WordId = word.Id
            //        }
            //    );
            //}

            //newContext.UsersWords.AddRange(usersWords);
            //newContext.SaveChanges();
            //var newWords = new List<Word>();

            //foreach (var oldWord in oldWords)
            //{
            //    newWords.Add(new Word()
            //        {
            //            Title = oldWord.Text,
            //            Meaning = oldWord.Meaning,
            //        }
            //    );
            //}

            //newContext.Words.AddRange(newWords);

            //newContext.SaveChanges();

            foreach (var word in user.UserWords.Select(uw=>uw.Word))
            {
                Console.WriteLine(word.Title);
            }
        }
    }
}
