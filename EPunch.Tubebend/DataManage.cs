using AnyCAD.Platform;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPunch.Tubebend
{
    public class DataManage
    {
        public DataSet BendingSet { get; }

        public delegate void DataChangeHandler();
        public event DataChangeHandler DataChange;

        protected virtual void OnDataChange()
        {
            DataChange?.Invoke();
        }
        public DataManage() 
        {
            BendingSet = new DataSet("BendingSet");
            DataTable bendingTable = BendingSet.Tables.Add("Bendings");

            DataColumn pkBendingID 
                = bendingTable.Columns.Add("BendingID", typeof(int));
;           bendingTable.Columns.Add("Direction", typeof(double));
            bendingTable.Columns.Add("Angle", typeof(double));
            bendingTable.Columns.Add("Radius", typeof(double));
            bendingTable.Columns.Add("Length", typeof(double));
            bendingTable.PrimaryKey = new DataColumn[] { pkBendingID };
            bendingTable.Columns["BendingID"].ReadOnly = true;
            bendingTable.Columns["BendingID"].AutoIncrement = true;
        }
        public void AddBending(Bending bending)
        {
            DataRow row;
            row = BendingSet.Tables["Bendings"].NewRow();
            row["BendingID"] = BendingSet.Tables["Bendings"].Rows.Count;
            row["Direction"] = bending.Direction;
            row["Angle"] = bending.Angle;
            row["Radius"] = bending.Radius;
            row["Length"] = bending.Length;
            BendingSet.Tables["Bendings"].Rows.Add(row);
        }
        public void AddBending(DataRow row)
        {
            DataRow newRow;
            newRow = BendingSet.Tables["Bendings"].NewRow();
            newRow["BendingID"] = BendingSet.Tables["Bendings"].Rows.Count;
            newRow["Direction"] = row["Direction"];
            newRow["Angle"] = row["Angle"];
            newRow["Radius"] = row["Radius"];
            newRow["Length"] = row["Length"];
            BendingSet.Tables["Bendings"].Rows.Add(newRow);
        }
        public DataRow ConvertToRow(Bending bending)
        {
            DataRow row;
            row = BendingSet.Tables["Bendings"].NewRow();
            //row["BendingID"] = BendingSet.Tables["Bendings"].Rows.Count;
            row["Direction"] = bending.Direction;
            row["Angle"] = bending.Angle;
            row["Radius"] = bending.Radius;
            row["Length"] = bending.Length;
            return row;
        }
        public void UpdateIndex()
        {
            var temp = BendingSet.Tables[0].Copy();
            BendingSet.Tables[0].Rows.Clear();
            foreach (DataRow item in temp.Rows)
            {
                this.AddBending(item);
            }
        }
        public void DeleteBending(int id)
        {
            DataRow row;
            row = BendingSet.Tables["Bendings"].Rows.Find(id);
            BendingSet.Tables["Bendings"].Rows.Remove(row);
        }
        public void DeleteBending(int[] ids)
        {
            DataRow row;
            row = BendingSet.Tables["Bendings"].Rows.Find(ids);
            BendingSet.Tables["Bendings"].Rows.Remove(row);
        }
        public void EditBending(int id, Bending bending)
        {
            var row = BendingSet.Tables["Bendings"].Rows.Find(id);
            row.BeginEdit();
            row["BendingID"] = bending.Index;
            row["Direction"] = bending.Direction;
            row["Angle"] = bending.Angle;
            row["Radius"] = bending.Radius;
            row["Length"] = bending.Length;
            row.EndEdit();
        }
        public void SetBendingGroup(BendingGroup group)
        {
            BendingSet.Tables[0].Rows.Clear();
            foreach(var item in group.Bendings)
            {
                this.AddBending(item);
            }
        }

        public void Clear()
        {
            foreach(DataTable item in BendingSet.Tables)
            {
                item.Clear();
            }
        }
        public void AcceptChanges()
        {
            BendingSet.AcceptChanges();
            OnDataChange();
        }
    }
}
