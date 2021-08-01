using AnyCAD.Platform;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EPunch.Tubebend
{
    public class BendHelper
    {
        public TopoShape Sweep;
        public TopoShape CenterLine;
    }
    public class Bending
    {
        [XmlAttribute]
        public int Index;
        public double Direction;
        public double Angle;
        public double Radius;
        public double Length;

        public Bending() { }
        public Bending(Bending previousB)
        {
            Index = previousB.Index;
            Direction = previousB.Direction;
            Angle = previousB.Angle;
            Radius = previousB.Radius;
            Length = previousB.Length;
        }
    }

    [XmlRoot("BendingGroup", IsNullable = false)]
    public class BendingGroup
    {

        public TopoShape SecShape { get; set; }
        public double Thickness { get; set; }

        [XmlArray("Bendings")]
        public List<Bending> Bendings = new List<Bending>();

        public BendingGroup() { }
        public BendingGroup(BendingGroup previousBG)
        {
            SecShape = previousBG.SecShape;
            Thickness = previousBG.Thickness;
            var temp = new List<Bending>();
            foreach(var m in previousBG.Bendings)
            {
                temp.Add(new Bending(m));
            }
            Bendings = temp;
        }
        public void AddBending (Bending bending)
        {
            #region 总体编号
            if (Bendings.Count() == 0)
            {
                bending.Index = 0;
            }
            else
            {
                bending.Index = Bendings.Last().Index + 1;
            }
            Bendings.Add(bending);
            #endregion
        }
        public void SetBendingGroup(BendingGroup bendingGroup)
        {
            SecShape = bendingGroup.SecShape;
            Thickness = bendingGroup.Thickness;
            var temp = new List<Bending>();
            foreach (var m in bendingGroup.Bendings)
            {
                temp.Add(new Bending(m));
            }
            Bendings = temp;
        }
        public void SetBendingGroup(DataManage dataSet)
        {
            var ben = new List<Bending>();
            foreach(DataRow item in dataSet.BendingSet.Tables["Bendings"].Rows)
            {
                Bending temp = new Bending
                {
                    Angle = item.Field<double>("Angle"),
                    Direction = item.Field<double>("Direction"),
                    Index = item.Field<int>("BendingID"),
                    Length = item.Field<double>("Length"),
                    Radius = item.Field<double>("Radius")
                };
                ben.Add(temp);
            }
            Bendings = ben;
        }
    }
    class ExportXml
    {
        public static void GenerateXml (BendingGroup bendings,string file)
        {
            XmlSerializer writer = new XmlSerializer(typeof(BendingGroup));
            var path = new System.IO.StreamWriter(file);
            writer.Serialize(path, bendings);
            path.Close();
            MessageBox.Show("输出成功！", "输出提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static BendingGroup ReadXml(string file)
        {
            XmlSerializer reader = new XmlSerializer(typeof(BendingGroup));
            var path = new System.IO.StreamReader(file);
            BendingGroup bendings = reader.Deserialize(path) as BendingGroup;
            path.Close();
            return bendings;
        }
    }
}
