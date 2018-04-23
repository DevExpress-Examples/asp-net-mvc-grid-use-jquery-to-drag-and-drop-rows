using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace dragDropMvc.Models {

    public class GridModel {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

    public class DataProvider {
        private const string droppableSource = "firstDS";
        private const string draggableSource = "secondDS";

        public DataTable GetFirstGridData() {
            if (HttpContext.Current.Session[draggableSource] == null) {
                var command = "SELECT CategoryID, CategoryName, Description FROM Categories";
                var connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + HttpContext.Current.Server.MapPath(@"~/App_Data/Categories + products.mdb");
                var adapter = new System.Data.OleDb.OleDbDataAdapter(command, connectionString);
                var dt = new DataTable();
                adapter.Fill(dt);
                HttpContext.Current.Session[draggableSource] = dt;
            }
            return HttpContext.Current.Session[draggableSource] as DataTable;
        }
        public DataTable GetSecondGridData() {
            if (HttpContext.Current.Session[droppableSource] == null) {
                var dt = new DataTable();
                dt.Columns.Add("CategoryID", typeof(Int32));
                dt.Columns.Add("CategoryName", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                HttpContext.Current.Session[droppableSource] = dt;
            }
            return HttpContext.Current.Session[droppableSource] as DataTable;
        }
        public void Update(int key, bool leftToRight) {
            var source = leftToRight ? GetFirstGridData() : GetSecondGridData();
            var target = leftToRight ? GetSecondGridData() : GetFirstGridData();

            //update target datasource
            var sourceRow = source.AsEnumerable()
                .Where(x => x.Field<Int32>("CategoryID") == key)
                .SingleOrDefault();
            target.ImportRow(sourceRow);

            //remove source data
            source.Rows.Remove(sourceRow);
        }
    }
}