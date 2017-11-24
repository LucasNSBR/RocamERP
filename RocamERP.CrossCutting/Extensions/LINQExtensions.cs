using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RocamERP.CrossCutting.Extensions
{
    public static class LINQExtensions
    {
        public static ICollection<SelectListItem> ToSelectItemList<T>(this IEnumerable<T> list, Func<T, string> text, Func<T, int> value)
        {
            var items = new List<SelectListItem>();
            foreach (var item in list)
            {
                items.Add(new SelectListItem()
                {
                    Text = text(item),
                    Value = value(item).ToString(),
                });
            }
            return items;
        }
    }
}