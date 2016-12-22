using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace MVC_EF.PageHelper
{
    public class PageList<T>:List<T>
    {
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int SouseCount { get; set; }
        public PageList(List<T> sourse,int pageIndex,int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            SouseCount = sourse.Count;
            PageCount = (int)Math.Ceiling(SouseCount / PageSize*1.0);
            AddRange(sourse.Skip((PageIndex-1)*PageSize).Take(PageSize));
        }
    }
}