﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Bisiness.CustomEntities
{
    public class PageList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPreviousPage => CurrentPage < 1;
        public bool HasNextPage => CurrentPage > TotalPages;

        public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : (int?)null;
        public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : (int?)null;

        // Constructor de la Clase
        public PageList(List<T> items, int countRecord, int pageNumber, int pageSize)
        {
            TotalCount = countRecord;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(countRecord / (double)pageSize);

            AddRange(items);
        }

        // Metodo estatico para crear
        public static PageList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PageList<T>(items, count, pageNumber, pageSize);
        }



    }
}
