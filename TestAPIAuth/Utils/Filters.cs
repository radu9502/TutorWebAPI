using TestAPIAuth.Models;

namespace TestAPIAuth.Utils
{
    public static class Filters
    {
        public static List<Request> RequestsFilter(ref List<Request>? requestList, Filter? filter)
        {
            List<Request> tempList = requestList;
            if (filter.category != null)
            {
                for (int i = 0; i < filter.category.Length; i++)
                {
                    requestList = (i == 0) ?
                          tempList.Where(x => x.CategoryId == filter.category[i]).ToList() :
                          requestList.Concat(tempList.Where(x => x.CategoryId == filter.category[i]).ToList()).ToList();

                }

                tempList = requestList;
            }

            if (filter.dificulty != null)
            {

                for (int i = 0; i < filter.dificulty.Length; i++)
                {
                    requestList = (i == 0) ?
                          tempList.Where(x => x.Dificulty == (Enums.Dificulty)filter.dificulty[i]).ToList() :
                          requestList.Concat(tempList.Where(x => x.Dificulty == (Enums.Dificulty)filter.dificulty[i]).ToList()).ToList();

                }


            }

           
            if (filter.orderBy != null)
            {
                switch (filter.orderBy.ToLower())
                {
                    case "price":
                        requestList = (filter.orderType != null) ? requestList.OrderByDescending(x => x.Price).ToList() :
                            requestList.OrderBy(x => x.Price).ToList();

                        break;
                    case "title":
                        requestList = (filter.orderType != null) ? requestList.OrderByDescending(x => x.Title).ToList() :
                            requestList.OrderBy(x => x.Title).ToList();

                        break;
                    case "date":
                        requestList = (filter.orderType != null) ? requestList.OrderByDescending(x => x.PublishDate).ToList() :
                            requestList.OrderBy(x => x.PublishDate).ToList();

                        break;
                }
            }

            else
            {
                requestList = (filter.orderType != null) ? requestList.OrderByDescending(x => x.Id).ToList() :
                  requestList.OrderBy(x => x.Id).ToList();


            }
            if (filter.page == null) filter.page = 1;
            if (filter.pageSize == null) filter.pageSize = 20;

            int pageIndex = (int)(filter.page - 1) * (int)filter.pageSize;
            Range range = new Range((Index)pageIndex, (Index)(pageIndex + filter.pageSize));
            requestList = requestList.Take(range).ToList();

            return requestList;
        }
    }
}
