using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Dz5zad1.Models;

namespace Dz5zad1.Helpers
{
    public static class Helper_Table
    {
        public static MvcHtmlString Show_Table<T>(this HtmlHelper helper, IEnumerable<T> collection,Func<T,string> Silki)
        {
            int count = 1;
            TagBuilder table = new TagBuilder("table");
            //table.MergeAttribute("border", "1");
            table.AddCssClass("div_table");
            TagBuilder trHead = new TagBuilder("tr");
            foreach (PropertyInfo propInfo in typeof(T).GetProperties())
            {
                if (count<3)
                {
                    trHead.InnerHtml += new TagBuilder("th") { InnerHtml = propInfo.Name }.ToString();
                    count++;
                }
            }

            if (Silki != null)
            {
                trHead.InnerHtml += new TagBuilder("th") { InnerHtml = "Подробнее" };
                trHead.InnerHtml += new TagBuilder("th") {InnerHtml = "Редактировать"};
                trHead.InnerHtml += new TagBuilder("th") { InnerHtml = "Удалить" };
            }
            table.InnerHtml += trHead.ToString();
            if (collection!=null)
            {
                foreach (var item in collection)
                {
                    count = 1;
                    TagBuilder trTableBody = new TagBuilder("tr");
                    foreach (var propInfo in typeof(T).GetProperties())
                    {
                        if (count<3)
                        {
                            trTableBody.InnerHtml += new TagBuilder("td") { InnerHtml = propInfo.GetValue(item).ToString() }.ToString();
                            count++;
                        }
                    }

                    if (Silki != null)
                        trTableBody.InnerHtml += Silki(item).ToString();

                    table.InnerHtml += trTableBody.ToString();
                }
            }
            return new MvcHtmlString(table.ToString());
        }
    }
}