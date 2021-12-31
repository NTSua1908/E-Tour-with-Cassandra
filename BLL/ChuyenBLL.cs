using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tour
{
    class ChuyenBLL
    {
        ChuyenDAL dalChuyen;
        public ChuyenBLL()
        {
            dalChuyen = new ChuyenDAL();
        }
        public bool LoadComboBox(ComboBox cb)
        {
            return dalChuyen.LoadComboBox(cb);
        }
        public DataTable getAllChuyen()
        {
            return dalChuyen.getAllChuyen();
        }
        public DataTable FindChuyen(string route)
        {
            return dalChuyen.FindChuyen(route);
        }
        public bool InsertChuyen(tblChuyen route)
        {
            return dalChuyen.InsertChuyen(route);
        }
        public bool UpdateChuyen(tblChuyen route)
        {
            return dalChuyen.UpdateChuyen(route);
        }
        public bool DeleteChuyen(tblChuyen route)
        {
            return dalChuyen.DeleteChuyen(route);
        }
    }
}
