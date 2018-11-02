using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dz5zad1.Models
{
    public static class MyEnumerable
    {
        public static IEnumerable<Author> Add(this IEnumerable<Author> e, Author value)
        {
            foreach (var cur in e)
            {
                yield return cur;
            }
            yield return value;
        }

        public static IEnumerable<Author> Delete(this IEnumerable<Author> e, Author author)
        {
            foreach (Author VARIABLE in e)
            {
                if (VARIABLE.Id != author.Id)
                {
                    yield return VARIABLE;
                }
            }
        }
        public static IEnumerable<Author> Clear(this IEnumerable<Author> e)
        {
            int i = 0;
            foreach (var VARIABLE in e)
            {
                if (VARIABLE.Id == i)
                {
                    yield return VARIABLE;
                }
            }
        }

        public static IEnumerable<Author> Rename(this IEnumerable<Author> e, Author author)
        {
            foreach (var VARIABLE in e)
            {
                if (VARIABLE.Id == author.Id)
                {
                    yield return author;
                }
                else
                {
                    yield return VARIABLE;
                }
            }
        }
    }
}