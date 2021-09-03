using AnimalShelter_WebAPI.DTOs.Animal.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs
{
    public class PageResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int totalPages { get; set; }
        public int ItemsFrom { get; set; }
        public int ItemsTo { get; set;}
        public int TotalItemsCount { get; set; }

       public PageResponse(IEnumerable<T> items, int totalCount, int PageSize, int pageNumber)
        {
            Items = items;
            TotalItemsCount = totalCount;
            ItemsFrom = PageSize * (pageNumber - 1) + 1;
            ItemsTo = ItemsFrom + PageSize - 1;
            totalPages = (int)Math.Ceiling(totalCount / (double)PageSize);
        }


    }
}
