namespace EnglishDictApp.Web.HtmlHelpers
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.Encodings.Web;
    using EnglishDictApp.Web.ViewModels;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    public static class PagingHelper
    {
        public static HtmlString PageLinks(this IHtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            StringWriter writer = new StringWriter();

            for (int i = Math.Max(1, pagingInfo.CurrentPage - 2);
                     i <= Math.Min(pagingInfo.CurrentPage + 2, pagingInfo.TotalPages);
                     i++)
            {
                TagBuilder tag = new TagBuilder("a");


                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml.SetContent(i.ToString());

                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }

                tag.AddCssClass("btn btn-default");
                tag.WriteTo(writer, HtmlEncoder.Default);
            }

            return new HtmlString(writer.ToString());
        }
    }
}
