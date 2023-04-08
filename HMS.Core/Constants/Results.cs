using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Constants
{
    public class Results
    {
        public static object AddSuccessResult()
        {
            return new { status = 1, msg = "s: تمت اضافة العنصر بنجاح", close = 1 };
        }

        public static object EditSuccessResult()
        {
            return new { status = 1, msg = "s: تم تحديث بيانات العنصر بنجاح ", close = 1 };
        }

        public static object UpdateStatusSuccessResult()
        {
            return new { status = 1, msg = "s: تم تحديث الحالة  بنجاح ", close = 1 };
        }

        public static object DeleteSuccessResult()
        {
            return new { status = 1, msg = "s: تم حذف العنصر بنجاح", close = 1 };
        }

    
    }
}
