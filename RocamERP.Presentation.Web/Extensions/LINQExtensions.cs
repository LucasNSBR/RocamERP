using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Extensions
{
    public static class LINQExtensions
    {
        public static ICollection<SelectListItem> ToSelectItemList<T>(this IEnumerable<T> list, Func<T, string> text, Func<T, string> value)
        {
            var items = new List<SelectListItem>();
            foreach (var item in list)
            {
                items.Add(new SelectListItem()
                {
                    Text = text(item),
                    Value = value(item),
                });
            }

            return items;
        }
    }
}