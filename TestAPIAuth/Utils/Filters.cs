using TestAPIAuth.Models;

namespace TestAPIAuth.Utils
{
    public static class Filters
    {
        public static List<Request> RequestsFilter(ref List<Request>? requestList, int? page,int? pageSize, int? category, string? orderType, string? orderBy)
        {
           
            if (category != null)
            {
                requestList = requestList.Where(x => x.CategoryId == category).ToList();
            }
            if (page == null) page = 1;
            if (pageSize == null) pageSize = 20;
                
                int pageIndex = (int)(page - 1) * (int)pageSize;
                Range range = new Range((Index)pageIndex, (Index)(pageIndex + pageSize));
                requestList = requestList.Take(range).ToList();

            
            if (orderBy != null)
            {
                switch (orderBy.ToLower())
                {
                    case "price":
                        requestList = (orderType != null) ? requestList.OrderByDescending(x => x.Price).ToList() :
                            requestList.OrderBy(x => x.Price).ToList();

                        break;
                    case "title":
                        requestList = (orderType != null) ? requestList.OrderByDescending(x => x.Title).ToList() :
                            requestList.OrderBy(x => x.Title).ToList();

                        break;
                    case "date":
                        requestList = (orderType != null) ? requestList.OrderByDescending(x => x.PublishDate).ToList() :
                            requestList.OrderBy(x => x.PublishDate).ToList();

                        break;
                }
            }

            else
            {
                requestList = (orderType != null) ? requestList.OrderByDescending(x => x.Id).ToList() :
                  requestList.OrderBy(x => x.Id).ToList();


            }
            return requestList;
        }
    }
}
